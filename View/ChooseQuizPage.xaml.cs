namespace FinaleProject.View;

public partial class ChooseQuizPage : ContentPage
{
	public ChooseQuizPage(ChooseQuizViewModel VM)
	{
		InitializeComponent();
		BindingContext = VM;
	}
}