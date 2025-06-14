using MAUI_Applicatie.Models;
using MAUI_Applicatie.ViewModel;

namespace MAUI_Applicatie;

public partial class AccountPagina : ContentPage
{
    public AccountPagina()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Account account = UserSession.LoggedInAccount ?? new Account()
        {
            Username = "Gast",
            Details = "",
            Email = "",
            ProfilePicture = new Image { Source = "zuyd_logo.png" },

        };

        var viewModel = new AccountViewModel(account);
        BindingContext = viewModel;
        AccountLabel.Text = $"Welkom {viewModel.Naam}!";
    }
}
