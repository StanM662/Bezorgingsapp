namespace MAUI_Applicatie;

public partial class LoginPagina : ContentPage
{
    public LoginPagina(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
