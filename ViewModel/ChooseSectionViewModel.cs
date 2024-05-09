namespace FinaleProject.ViewModel;

[QueryProperty("Bank", "QuestionBank")]
[QueryProperty(nameof(Student), nameof(Student))]
[QueryProperty("IsStudentIncluded", "IsStudentIncluded")]
public partial class ChooseSectionViewModel : BaseViewModel
{
    [ObservableProperty]
    QuestionBank bank;
    [ObservableProperty]
    Student student;
    [ObservableProperty]
    bool isStudentIncluded;

    [RelayCommand]
    async Task NavigateToQuiz(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        Section section = Bank.Sections.FirstOrDefault(s => s.Name == name);

        if (section == null) return;

        if(!IsStudentIncluded)
        {
            await Shell.Current.GoToAsync(nameof(ChooseQuizPage), new Dictionary<string, object>
            {
                {"Section", section },
                {"QuestionBank", Bank },
                {"Student", Student }
            });
        }
        else
        {
            await Shell.Current.GoToAsync($"{nameof(ChooseQuizPage)}?IsStudentIncluded={true}", new Dictionary<string, object>
            {
                {"QuestionBank", Bank },
                {"Section", section }
            });
        }
    }
    [RelayCommand]
    async Task NavigateToChooseQuiz(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        Section section = Bank.Sections.FirstOrDefault(s => s.Name == name);

        if (section == null) return;


    }
    [RelayCommand]
    async Task NavigateToDashBoard()
    {
        await Shell.Current.GoToAsync("..");
    }
}