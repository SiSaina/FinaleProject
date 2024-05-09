namespace FinaleProject.ViewModel;

[QueryProperty("Bank", "QuestionBank")]
[QueryProperty(nameof(Student), nameof(Student))]
public partial class HistoryViewModel : BaseViewModel
{
    [ObservableProperty]
    QuestionBank? bank;
    [ObservableProperty]
    Student? student;

    [ObservableProperty]
    ObservableCollection<Attempt>? att;
    
    [RelayCommand]
    async Task NavigateToSectionPage()
    {
        await Shell.Current.GoToAsync(nameof(ChooseSectionPage));
    }
    [RelayCommand]
    async Task NavigateToDashBoard()
    {
        await Shell.Current.GoToAsync("..");
    }


    [RelayCommand]
    void Refresh()
    {
        Att = [];
        if (Bank != null)
        {
            foreach (Attempt attempt in Bank.Attempts)
            {
                if (attempt.Student.Username == Student?.Username)
                {
                    Attempt newAttempt = new Attempt
                    {
                        Student = new Student
                        {
                            Username = attempt.Student.Username
                        },
                        QuizName = attempt.QuizName,
                        SectionName = attempt.SectionName,
                        AttemptDate = attempt.AttemptDate,
                        Score = attempt.Score
                    };
                    Att.Add(newAttempt);
                }
            }
        }
    }
}