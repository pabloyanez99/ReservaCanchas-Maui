namespace ReservaCanchas_Maui;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}
    private async void OnLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}