using MAUI_Applicatie.ViewModel;
namespace MAUI_Applicatie;

public partial class LoginPagina : ContentPage
{
    public LoginPagina(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

