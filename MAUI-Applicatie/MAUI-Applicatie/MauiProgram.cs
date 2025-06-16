using Microsoft.Extensions.Logging;
using MAUI_Applicatie.ViewModel;
using Plugin.Firebase.CloudMessaging;
using Plugin.Firebase.Core;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase;


#if ANDROID
using Plugin.Firebase.CloudMessaging.Platforms.Android;
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

            // ViewModels and Pages
            builder.Services.AddSingleton<BestellingPagina>();
            builder.Services.AddSingleton<NaamLogin>();
            builder.Services.AddSingleton<WachtwoordLogin>();
            builder.Services.AddSingleton<PageViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();

            // Android-specific Firebase initialization
            builder.ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android =>
                    android.OnCreate((activity, _) =>
                        Firebase.FirebaseApp.InitializeApp(activity)
                    ));

#endif
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
