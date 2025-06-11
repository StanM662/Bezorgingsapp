using MAUI_Applicatie.ViewModel;

namespace MAUI_Applicatie;

public partial class MainPage : ContentPage
{
    private int count = 0;
    private int number = 0;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterBtn.Text = $"Clicked {count} time{(count == 1 ? "" : "s")}";
        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void Counter_Clicked(object sender, EventArgs e)
    {
        number++;
        CounterBtn2.Text = $"Clicked {number} time{(number == 1 ? "" : "s")}";
        SemanticScreenReader.Announce(CounterBtn2.Text);
    }
}
