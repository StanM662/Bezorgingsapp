namespace MAUI_Applicatie
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Preferences.Get("IsLoggedIn", false)) { MainPage = new AppShell(); }
            else { MainPage = new LoginPagina(new LoginViewModel()); }

        }
    }
}
