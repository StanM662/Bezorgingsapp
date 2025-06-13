namespace MAUI_Applicatie
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.GoToAsync(nameof(NaamLogin));
            });
        }
    }


}
