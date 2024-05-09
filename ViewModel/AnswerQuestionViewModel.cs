namespace FinaleProject.ViewModel;

[QueryProperty("Bank", "QuestionBank")]
[QueryProperty(nameof(Quiz), nameof(Quiz))]
[QueryProperty(nameof(Student), nameof(Student))]
[QueryProperty(nameof(Section), nameof(Section))]
public partial class AnswerQuestionViewModel : BaseViewModel
{
    Random random =new Random();

    [ObservableProperty]
    QuestionBank bank;
    [ObservableProperty]
    Student student;
    [ObservableProperty]
    Quiz quiz;
    [ObservableProperty]
    Section section;

    [ObservableProperty]
    ObservableCollection<Question> questions;

    [ObservableProperty]
    Question currentQuestion;

    [ObservableProperty]
    int index;

    [ObservableProperty]
    int score = 0;

    [ObservableProperty]
    ObservableCollection<string> shuffledAllAnswers = new ObservableCollection<string>();

    [ObservableProperty]
    bool isAnswerCorrect;

    [ObservableProperty]
    bool isStartButtonEnabled = true;

    private bool SubmitAnswer()
    {
        if (Quiz != null && Quiz.QuestionIds != null && Index < Quiz.QuestionIds.Count)
        {
            var correctAnswers = Section.Questions[Index].CorrectAnswer;

            var enteredAnswers = Text.Split(',');

            enteredAnswers = enteredAnswers.Select(answer => answer.Trim()).ToArray();

            return correctAnswers.All(correctAnswer => enteredAnswers.Contains(correctAnswer));
        }
        return false;
    }
    [RelayCommand]
    void StartQuestion()
    {
        Index = 0;
        int questionId = Quiz.QuestionIds[Index];

        Question currentQuestion = Section.Questions.FirstOrDefault(q => q.Id == questionId);

        if (currentQuestion != null)
        {
            List<string> allAnswers = new List<string>(currentQuestion.Answer);
            allAnswers.AddRange(currentQuestion.CorrectAnswer);

            ShuffledAllAnswers = new ObservableCollection<string>(allAnswers.OrderBy(x => random.Next()));

            CurrentQuestion = new Question
            {
                Id = currentQuestion.Id,
                Title = currentQuestion.Title,
                Answer = ShuffledAllAnswers
            };
        }
        IsStartButtonEnabled = false;
    }
    [RelayCommand]
    async Task NextQuestion()
    {
        Index++;
        if (Quiz != null && Quiz.QuestionIds != null && Index < Quiz.QuestionIds.Count)
        {
            List<string> allAnswers = new List<string>(Section.Questions[Index].Answer);
            allAnswers.AddRange(Section.Questions[Index].CorrectAnswer);

            ShuffledAllAnswers = new ObservableCollection<string>(allAnswers.OrderBy(x => random.Next()));

            CurrentQuestion = new Question
            {
                Id = Section.Questions[Index].Id,
                Title = Section.Questions[Index].Title,
                Answer = ShuffledAllAnswers
            };
        }
    }

    [RelayCommand]
    async Task Submit()
    {
        if (SubmitAnswer())
        {
            Score++;
        }

        await NextQuestion();

        if(Index > Quiz.QuestionIds.Count)
        {
            Application.Current?.MainPage?.DisplayAlert("Quiz finish", $"Congratulation! You score: {Score}", "Okazz");

            Attempt Attempt = new Attempt
            {
                Student = Student,
                QuizId = Quiz.Id,
                QuizName = Quiz.Name,
                SectionName = Section.Name,
                Score = Score,
                AttemptDate = DateTime.Now,
            };
            Bank.Attempts.Add(Attempt);
            Quiz.Attempts.Add(Attempt);
            Bank.SaveToFile();

            string attemptDetails = $"Attempt Details:\nStudent: {Attempt.Student.Username}\nQuiz: {Attempt.QuizName}\nScore: {Attempt.Score}\nAttempt Date: {Attempt.AttemptDate}";
            await Application.Current.MainPage.DisplayAlert("Attempt Information", attemptDetails, "Ok");
            await Shell.Current.GoToAsync("../../..");
        }
    }
}