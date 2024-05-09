using Microsoft.Extensions.Logging;

namespace FinaleProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<TeacherDashBoard>();
            builder.Services.AddSingleton<TeacherViewModel>();

            builder.Services.AddTransient<SectionPage>();
            builder.Services.AddTransient<SectionViewModel>();

            builder.Services.AddTransient<QuizPage>();
            builder.Services.AddTransient<QuizViewModel>();

            builder.Services.AddTransient<QuestionPage>();
            builder.Services.AddTransient<QuestionViewModel>();

            builder.Services.AddTransient<StudentDashBoard>();
            builder.Services.AddTransient<StudentViewModel>();

            builder.Services.AddTransient<ChooseSectionPage>();
            builder.Services.AddTransient<ChooseSectionViewModel>();

            builder.Services.AddTransient<ChooseQuizPage>();
            builder.Services.AddTransient<ChooseQuizViewModel>();

            builder.Services.AddTransient<AnswerQuestionPage>();
            builder.Services.AddTransient<AnswerQuestionViewModel>();

            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<HistoryViewModel>();

            builder.Services.AddTransient<LeaderBoardPage>();
            builder.Services.AddTransient<LeaderBoardViewModel>();

            builder.Services.AddTransient<SettingPage>();
            builder.Services.AddTransient<SettingViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
