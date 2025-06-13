using Microsoft.Extensions.Logging;
using MAUI_Applicatie.ViewModel;

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

            // Paginas tovoegen
            builder.Services.AddSingleton<BestellingPagina>();
            builder.Services.AddSingleton<NaamLogin>();
            builder.Services.AddSingleton<WachtwoordLogin>();

            // ViewModels toevoegen
            builder.Services.AddSingleton<PageViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
