using MAUI_Applicatie.ViewModel;

namespace MAUI_Applicatie;

public partial class LoginPagina : ContentPage
{
	public LoginPagina(PageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}