namespace MAUI_Applicatie;

public partial class WachtwoordLogin : ContentPage
{
	public WachtwoordLogin(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
    }

}