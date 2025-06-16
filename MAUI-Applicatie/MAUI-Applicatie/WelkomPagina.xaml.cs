using Plugin.Firebase.CloudMessaging;
using MAUI_Applicatie.ViewModel;

namespace MAUI_Applicatie;

public partial class WelkomPagina : ContentPage
{
    public WelkomPagina()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsEnabled = true, IsVisible = false });
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
    }

    private async void OnSendPushClicked(object sender, EventArgs e)
    {
        try
        {
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();

            if (string.IsNullOrWhiteSpace(token))
            {
                await DisplayAlert("Error", "Device token is null or empty.", "OK");
                return;
            }

            await FcmSender.SendPushAsync(token);

            await DisplayAlert("Success", "Push notification sent!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to send notification:\n{ex.Message}", "OK");
        }
    }
}
