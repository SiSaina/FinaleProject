namespace FinaleProject.View;

public partial class HistoryPage : ContentPage
{
	public HistoryPage(HistoryViewModel VM)
	{
		InitializeComponent();
		BindingContext = VM;
	}
}