using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace MAUI_Applicatie.WinUI
{
    public partial class App : MauiWinUIApplication
    {
        public App()
        {
            InitializeComponent(); 
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}