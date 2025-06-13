using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Xml.Linq;

public partial class LoginViewModel : ObservableObject
{
    Dictionary<string, string> users = new()
    {
        { "admin", "admin" },
        { "Stan", "Stan123" },
        { "Sander", "Sander123" },
        { "Rick", "Rick123" }
    };

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string password;

    [RelayCommand]
    async Task VerifyName()
    {
        if (users.ContainsKey(name))
        {
            await Shell.Current.GoToAsync("WachtwoordLogin");
        }
        else
        {
            await Shell.Current.DisplayAlert("Fout", "Gebruikersnaam bestaat niet", "OK");
        }
    }

    [RelayCommand]
    async Task VerifyPassword()
    {
        if (users.ContainsValue(password))
        {
            await Shell.Current.GoToAsync("WelkomPagina");
        }
        else
        {
            await Shell.Current.DisplayAlert("Fout", "Wachtwoord is onjuist", "OK");
        }
    }
}
