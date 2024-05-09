namespace FinaleProject.View;

public partial class ChooseSectionPage : ContentPage
{
	public ChooseSectionPage(ChooseSectionViewModel VM)
	{
		InitializeComponent();
		BindingContext = VM;
	}
}