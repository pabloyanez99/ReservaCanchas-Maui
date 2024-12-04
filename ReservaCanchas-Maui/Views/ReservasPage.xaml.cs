using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui.Views;

public partial class ReservasPage : ContentPage
{
    public Usuario _usuario;
	public Cancha _cancha;
	public ReservaRepositroy _repository;
    public Reserva _reserva;
	public ReservasPage(Cancha cancha, Usuario usuario)
	{
		InitializeComponent();
        _repository = new ReservaRepositroy();
		_cancha = cancha;
        _usuario = usuario;
        FechaPicker.MinimumDate = DateTime.Now.Date;
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
        UsuarioName.Text = _usuario.NombreUsuario;
        UsuarioCorreo.Text = _usuario.CorreoUsuario;


        // Configurar rango para TimePicker
        HoraInicioPicker.Time = _cancha.HoraApertura;
        HoraFinPicker.Time = _cancha.HoraCierre;
    }

    private async void OnConfirmarReservacionClicked(object sender, EventArgs e)
    {
        if (HoraInicioPicker.Time < _cancha.HoraApertura || HoraFinPicker.Time > _cancha.HoraCierre || HoraInicioPicker.Time >= HoraFinPicker.Time)
        {
            await DisplayAlert("Error", "El horario seleccionado no es válido.", "Aceptar");
            return;
        }

        if (!_repository.EstaDisponible(_cancha.IdCancha, FechaPicker.Date, HoraInicioPicker.Time, HoraFinPicker.Time))
        {
            await DisplayAlert("Error", "El horario seleccionado ya está reservado.", "Aceptar");
            return;
        }

        // Crear la reserva
        _reserva = new Reserva()
        {
            IdUsuario = _usuario.IdUsuario,
            Fecha = FechaPicker.Date,
            HoraInicio = HoraInicioPicker.Time,
            HoraFin = HoraFinPicker.Time,
            IdCancha = _cancha.IdCancha
        };

        // Guardar la reserva
        _repository.CrearReserva(_reserva);

        await DisplayAlert("Éxito", "Reservación confirmada.", "Aceptar");
        await Navigation.PopAsync();
    }

}