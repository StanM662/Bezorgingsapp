using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
    async Task Inloggen()
    {

        if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password))
        {
            if (users.ContainsKey(Name) && users[Name] == Password)
            {
                try
                {
                    await Shell.Current.GoToAsync("///WelkomPagina");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Navigatiefout", ex.Message, "OK");
                }
            }

        }
    }

}
