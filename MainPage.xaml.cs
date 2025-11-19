namespace VaidaGeorgeLab7
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterTxt.Text = $"Clicked {count} time";
            else
                CounterTxt.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterTxt.Text);
        }
    }
}
