using MAUI_Applicatie.ViewModel;

namespace MAUI_Applicatie;

public partial class WelkomPagina : ContentPage
{

    public WelkomPagina()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}
