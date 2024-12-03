namespace ReservaCanchas_Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

    }

}
