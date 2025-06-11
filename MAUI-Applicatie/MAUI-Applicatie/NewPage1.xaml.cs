using MAUI_Applicatie.ViewModel;

namespace MAUI_Applicatie;

public partial class NewPage1 : ContentPage
{
	public NewPage1(PageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}