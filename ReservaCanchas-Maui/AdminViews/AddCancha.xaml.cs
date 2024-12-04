using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui.AdminViews;

public partial class AddCancha : ContentPage
{
	public Complejo _complejo;
	public Cancha _cancha;
	public CanchaRepository _repository;
	public AddCancha(Complejo complejo)
	{
		InitializeComponent();
		_complejo = complejo;
		_repository = new CanchaRepository();
	}
    private async void OnAniadirCanchaClicked(object sender, EventArgs e)
	{
		_cancha = new Cancha()
		{
            NombreCancha = NombreCanchaEntry.Text,
            NumeroJugadores = int.TryParse(NumeroJugadoresEntry.Text, out int jugadores) ? jugadores : 0,
            PrecioPorHora = decimal.TryParse(PrecioPorHoraEntry.Text, out decimal precio) ? precio : 0,
            HoraApertura = HoraAperturaPicker.Time,
            HoraCierre = HoraCierrePicker.Time,
            ImagenCancha = ImagenCanchaEntry.Text,
            IdComplejo = _complejo.IdComplejo
        };
		_repository.CrearCancha(_cancha);
        await DisplayAlert("Éxito", "Cancha guardado correctamente.", "OK");
        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        await Navigation.PopAsync();
    }
    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Regresa a la página anterior
    }
}