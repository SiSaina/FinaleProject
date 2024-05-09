namespace FinaleProject.ViewModel;

[QueryProperty("Bank", "QuestionBank")]
[QueryProperty(nameof(Student), nameof(Student))]

public partial class StudentViewModel : BaseViewModel
{
    [ObservableProperty]
    QuestionBank bank;

    [ObservableProperty]
    Student student;

    [RelayCommand]
    private async Task NavigateToSection()
    {
        await Shell.Current.GoToAsync(nameof(ChooseSectionPage), new Dictionary<string, object>
        {
            {"QuestionBank", Bank },
            {"Student", Student },
        });
    }
    [RelayCommand]
    private async Task NavigateToHistory()
    {
        await Shell.Current.GoToAsync(nameof(HistoryPage), new Dictionary<string, object>
        {
            {"QuestionBank", Bank },
            {"Student", Student }
        });
    }
    [RelayCommand]
    private async Task NavigateToLeaderBoard()
    {
        await Shell.Current.GoToAsync($"{nameof(ChooseSectionPage)}?IsStudentIncluded=true", new Dictionary<string, object>
        {
            {"QuestionBank", Bank }
        });
    }
    [RelayCommand]
    private async Task NavigateToSetting()
    {
        await Shell.Current.GoToAsync(nameof(SettingPage), new Dictionary<string, object>
        {
            {"QuestionBank", Bank},
            {"Student", Student }
        });
    }
    [RelayCommand]
    private async Task NavigateLogOut()
    {
        await Shell.Current.GoToAsync("..");
    }
}