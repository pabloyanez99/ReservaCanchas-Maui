using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui.Views;

public partial class ReservasPage : ContentPage
{
	public Cancha _cancha;
	public ReservaRepositroy _repository;
    public Reserva _reserva;
	public ReservasPage(Cancha cancha)
	{
		InitializeComponent();
        _repository = new ReservaRepositroy();
		_cancha = cancha;
		BindingContext = this;
        MostrarDetallesCancha();

	}
    private void MostrarDetallesCancha()
    {
        // Cargar detalles de la cancha
        NombreCanchaLabel.Text = _cancha.NombreCancha;
        ImagenCanchaImage.Source = _cancha.ImagenCancha;
        NumeroJugadoresLabel.Text = $"{_cancha.NumeroJugadores} jugadores";
        HorarioLabel.Text = $"{_cancha.HoraApertura:hh\\:mm} - {_cancha.HoraCierre:hh\\:mm}";
        PrecioPorHoraLabel.Text = $"{_cancha.PrecioPorHora:C}";

        // Configurar rango para TimePicker
        HoraInicioPicker.Time = _cancha.HoraApertura;
        HoraFinPicker.Time = _cancha.HoraApertura;
    }
    private async void OnConfirmarReservacionClicked(object sender, EventArgs e)
    {
        // Validar campos de entrada
        if (string.IsNullOrWhiteSpace(UsuarioEntry.Text) || string.IsNullOrWhiteSpace(CorreoEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "Aceptar");
            return;
        }

        if (HoraInicioPicker.Time < _cancha.HoraApertura || HoraFinPicker.Time > _cancha.HoraCierre || HoraInicioPicker.Time >= HoraFinPicker.Time)
        {
            await DisplayAlert("Error", "El horario seleccionado no es válido.", "Aceptar");
            return;
        }

        // Guardar la reservación
        _reserva = new Reserva()
        {
            IdReserva = new Random().Next(1, 1000),
            Usuario = UsuarioEntry.Text,
            Correo = CorreoEntry.Text,
            Fecha = FechaPicker.Date,
            HoraInicio = HoraInicioPicker.Time,
            HoraFin = HoraFinPicker.Time,
            IdCancha = _cancha.IdCancha
        };

        _repository.CrearReserva(_reserva);

        await DisplayAlert("Éxito", "Reservación confirmada.", "Aceptar");
        await Navigation.PopAsync();
    }
}