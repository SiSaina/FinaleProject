namespace FinaleProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TeacherDashBoard), typeof(TeacherDashBoard));
            Routing.RegisterRoute(nameof(SectionPage), typeof(SectionPage));
            Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage));
            Routing.RegisterRoute(nameof(QuestionPage), typeof(QuestionPage));

            Routing.RegisterRoute(nameof(StudentDashBoard), typeof(StudentDashBoard));
            Routing.RegisterRoute(nameof(ChooseSectionPage), typeof(ChooseSectionPage));
            Routing.RegisterRoute(nameof(ChooseQuizPage), typeof(ChooseQuizPage));
            Routing.RegisterRoute(nameof(AnswerQuestionPage), typeof(AnswerQuestionPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
            Routing.RegisterRoute(nameof(LeaderBoardPage), typeof(LeaderBoardPage));
            Routing.RegisterRoute(nameof(SettingPage), typeof(SettingPage));
        }
    }
}
