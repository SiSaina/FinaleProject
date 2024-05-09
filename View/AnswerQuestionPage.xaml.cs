namespace FinaleProject.View;

public partial class AnswerQuestionPage : ContentPage
{
	public AnswerQuestionPage(AnswerQuestionViewModel VM)
	{
		InitializeComponent();
		BindingContext = VM;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        DisplayAlert("Excited", "Are you ready??\n" +
                                "Make sure to enter the exact answer\n" +
                                "If you think the question have multiple answers\n" +
                                "Enter comma to separate answer", "OKazz");
    }
}