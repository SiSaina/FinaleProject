namespace FinaleProject.ViewModel;

[QueryProperty("Bank", "QuestionBank")]
[QueryProperty(nameof(Quiz), nameof(Quiz))]
[QueryProperty(nameof(Section), nameof(Section))]
public partial class LeaderBoardViewModel : BaseViewModel
{
    [ObservableProperty]
    QuestionBank? bank;
    [ObservableProperty]
    Quiz? quiz;
    [ObservableProperty]
    Section? section;

    [ObservableProperty]
    ObservableCollection<Attempt>? att;

    [RelayCommand]
    void Refresh()
    {
        Att = [];
        if (Bank != null)
        {
            foreach (Attempt attempt in Bank.Attempts)
            {
                if (attempt.SectionName == Section?.Name && attempt.QuizName == Quiz?.Name)
                {
                    Attempt newAttempt = new()
                    {
                        Student = new Student
                        {
                            Username = attempt.Student.Username
                        },
                        QuizName = Quiz.Name,
                        SectionName = Section.Name,
                        AttemptDate = attempt.AttemptDate,
                        Score = attempt.Score
                    };
                    Att.Add(newAttempt);
                }
            }
        }

        ObservableCollection<Attempt> top20Students = new ObservableCollection<Attempt>(
            Att.OrderByDescending(a => a.Score)
               .ThenByDescending(a => a.AttemptDate)
               .Take(20)
        );
        Att.Clear();
        foreach (var attempt in top20Students)
        {
            Att.Add(attempt);
        }
    }
}