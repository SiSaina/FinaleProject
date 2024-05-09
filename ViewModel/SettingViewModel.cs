namespace FinaleProject.ViewModel;

[QueryProperty("Bank", "QuestionBank")]
[QueryProperty(nameof(Student),nameof(Student))]
public partial class SettingViewModel : BaseViewModel
{
    [ObservableProperty]
    QuestionBank? bank;

    [ObservableProperty]
    Student? student;

    [RelayCommand]
    async Task Modify(string property)
    {
        string newValue;
        if (property == Student?.Username)
        {
            newValue = await Application.Current.MainPage.DisplayPromptAsync("Edit Username", "Enter a new username", initialValue: Student.Username);

            if (!string.IsNullOrEmpty(newValue))
            {
                Student.Username = newValue;
            }
        }
        else if (property == Student?.Password)
        {
            newValue = await Application.Current.MainPage.DisplayPromptAsync("Edit Password", "Enter a new password", initialValue: Student.Password);

            if (!string.IsNullOrEmpty(newValue))
            {
                Student.Password = newValue;
            }
        }
        Bank?.SaveToFile();
    }
}