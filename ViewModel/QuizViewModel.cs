namespace FinaleProject.ViewModel;

[QueryProperty("Section", "Section")]
[QueryProperty("Bank", "QuestionBank")]
[QueryProperty(nameof(Quiz), nameof(Quiz))]
public partial class QuizViewModel : BaseViewModel
{
    [ObservableProperty]
    QuestionBank bank;

    [ObservableProperty]
    Quiz quiz;

    [ObservableProperty]
    Section section;

    [RelayCommand]
    async Task SelectQuestion()
    {
        string selectId = await Application.Current.MainPage.DisplayPromptAsync("Enter ID", "Please enter the question ID or type 'random' to select random questions:");

        if (string.IsNullOrEmpty(selectId)) return;

        if (Quiz.QuestionIds.Count >= 20)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "The quiz already has 20 questions. You cannot add more.", "OK");
            return;
        }

        if (selectId.Equals("Random", StringComparison.OrdinalIgnoreCase))
        {
            if (Quiz.QuestionIds.Count > 0)
            {
                Quiz.QuestionIds.Clear();
            }

            await RandomQuestions(20);

            await Application.Current.MainPage.DisplayAlert("Success", "Random questions added to the quiz.", "OK");
        }
        else
        {
            await AddSelectedQuestions(selectId);
        }
        Bank.SaveToFile();
    }

    private async Task AddSelectedQuestions(string selectId)
    {
        if (!int.TryParse(selectId, out int selectedId))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Invalid ID format. Please enter a valid numeric ID.", "OK");
            return;
        }

        Question selectedQuestion = Section.Questions.FirstOrDefault(question => question.Id == selectedId);

        if (selectedQuestion == null)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "No question found with the entered ID.", "OK");
            return;
        }

        if (Quiz.QuestionIds.Contains(selectedQuestion.Id))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "The selected question is already added to the quiz.", "OK");
            return;
        }

        Quiz.QuestionIds.Add(selectedQuestion.Id);
        Quiz.QuestionNames.Add(selectedQuestion.Title);
        await Application.Current.MainPage.DisplayAlert("Success", "Question added to the quiz.", "OK");
    }

    private async Task RandomQuestions(int count)
    {
        var random = new Random();
        var randomQuestions = Section.Questions.OrderBy(q => random.Next()).Take(count);

        foreach (var randomQuestion in randomQuestions)
        {
            if (!Quiz.QuestionIds.Contains(randomQuestion.Id))
            {
                Quiz.QuestionIds.Add(randomQuestion.Id);
                Quiz.QuestionNames.Add(randomQuestion.Title);
            }
        }
    }

    [RelayCommand]
    async Task NavigateBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}