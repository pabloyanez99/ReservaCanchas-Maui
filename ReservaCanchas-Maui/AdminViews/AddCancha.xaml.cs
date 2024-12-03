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
    private void OnAniadirCanchaClicked(object sender, EventArgs e)
	{
		_cancha = new Cancha()
		{
            IdCancha = new Random().Next(1, 1000), // Generación automática del ID
            NombreCancha = NombreCanchaEntry.Text,
            NumeroJugadores = int.TryParse(NumeroJugadoresEntry.Text, out int jugadores) ? jugadores : 0,
            PrecioPorHora = decimal.TryParse(PrecioPorHoraEntry.Text, out decimal precio) ? precio : 0,
            HoraApertura = HoraAperturaPicker.Time,
            HoraCierre = HoraCierrePicker.Time,
            ImagenCancha = ImagenCanchaEntry.Text,
            IdComplejo = _complejo.IdComplejo
        };
		_repository.CrearCancha(_cancha);
        Console.WriteLine($"Cancha añadida: {_cancha.NombreCancha}");
    }
    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Regresa a la página anterior
    }
}