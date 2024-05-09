namespace FinaleProject.View;

public partial class LeaderBoardPage : ContentPage
{
	public LeaderBoardPage(LeaderBoardViewModel LM)
	{
		InitializeComponent();
		BindingContext = LM;
	}
}