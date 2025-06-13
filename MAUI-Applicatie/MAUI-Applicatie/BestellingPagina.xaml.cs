using MAUI_Applicatie.ViewModel;
namespace MAUI_Applicatie;

public partial class BestellingPagina : ContentPage
{
    public BestellingPagina(PageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}