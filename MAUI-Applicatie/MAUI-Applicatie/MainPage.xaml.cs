namespace MAUI_Applicatie
{
    public partial class MainPage : ContentPage
    {
        private int count = 0;
        private int number = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void Counter_Clicked(object sender, EventArgs e)
        {
            number++;
            
            if (number == 1)
                CounterBtn2.Text = $"Clicked {number} time";
            else
                CounterBtn2.Text = $"Clicked {number} times";

            SemanticScreenReader.Announce(CounterBtn2.Text);
        }
    }

}
