using Microsoft.Extensions.Logging;
using MAUI_Applicatie.ViewModel;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase; 
using Shiny;

#if ANDROID
using Firebase;
#endif

namespace MAUI_Applicatie
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

#if ANDROID
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddAndroid(android =>
                    android.OnCreate((activity, _) =>
                        FirebaseApp.InitializeApp(activity)
                    ));
            });
#endif

            builder.Services.AddSingleton<BestellingPagina>();
            builder.Services.AddSingleton<NaamLogin>();
            builder.Services.AddSingleton<WachtwoordLogin>();
            builder.Services.AddSingleton<PageViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
