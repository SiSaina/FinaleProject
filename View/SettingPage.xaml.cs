namespace FinaleProject.View;

public partial class SettingPage : ContentPage
{
	public SettingPage(SettingViewModel VM)
	{
		InitializeComponent();
		BindingContext = VM;
	}
}