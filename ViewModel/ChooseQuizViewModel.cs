namespace FinaleProject.ViewModel;

[QueryProperty("Bank", "QuestionBank")]
[QueryProperty(nameof(Section),nameof(Section))]
[QueryProperty(nameof(Student), nameof(Student))]
[QueryProperty("IsStudentIncluded", "IsStudentIncluded")]
public partial class ChooseQuizViewModel : BaseViewModel
{

    [ObservableProperty]
    Section section;
    [ObservableProperty]
    QuestionBank bank;
    [ObservableProperty]
    Student student;
    [ObservableProperty]
    bool isStudentIncluded;

    [RelayCommand]
    async Task NavigateToAnswerQuestion(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        Quiz quiz = Section.Quizzes.FirstOrDefault(s => s.Name == name);

        if (quiz == null) return;

        if(quiz.QuestionIds.Count < 20)
        {
            await Application.Current.MainPage.DisplayAlert("Technical issus", "The quiz didn't have enough questions", "Okazz");
            return;
        }
        if(!IsStudentIncluded)
        {
            await Shell.Current.GoToAsync(nameof(AnswerQuestionPage), new Dictionary<string, object>
            {
                {"Quiz", quiz },
                {"QuestionBank", Bank },
                {"Section", Section },
                {"Student", Student }
            });
        }
        else
        {
            await Shell.Current.GoToAsync(nameof(LeaderBoardPage), new Dictionary<string, object>
            {
                {"QuestionBank", Bank },
                {"Section",Section },
                {"Quiz", quiz }
            });
        }
    }
    [RelayCommand]
    async Task NavigateToDashBoard()
    {
        await Shell.Current.GoToAsync("../..");
    }
}