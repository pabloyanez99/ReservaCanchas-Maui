using ReservaCanchas_Maui.AdminViews;
using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;
using System.Text.Json;

namespace ReservaCanchas_Maui.Views;

public partial class CanchasPage : ContentPage
{
    public Usuario _usuario;
	public CanchaRepository _repository;
	public List<Cancha> _canchas;
	public Complejo _complejo;

    public CanchasPage(Complejo complejo, Usuario usuario)
    {
        InitializeComponent();
        _complejo = complejo;
        _repository = new CanchaRepository();
        _usuario = usuario;
        Title = $"Canchas de {_complejo.NombreComplejo}";
        CargarCanchas();
        GenerarBotonAdministrador();
    }
    private void CargarCanchas()
    {
		_canchas = _repository.ObtenerTodasLasCanchas();
        CanchasCollection.ItemsSource = _canchas.Where(c => c.IdComplejo == _complejo.IdComplejo).ToList();
    }
    private async void OnCanchaSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Cancha seleccionada)
        {
            await Navigation.PushAsync(new ReservasPage(seleccionada, _usuario));
        }
    }
    private void GenerarBotonAdministrador()
    {
        // Botón específico para adminstrador
        if (_usuario.Tipo == TipoDeUsuario.Administrador &&
            _usuario.ComplejosAdministrados.Contains(_complejo.IdComplejo))
        {
            var botonAdmin = new Button
            {
                Text = "Editar Complejo",
                BackgroundColor = Colors.Purple,
                TextColor = Colors.White,
                Margin = new Thickness(0, 10),
            };

            botonAdmin.Clicked += OnAdministracionComplejoAdmin;

            CanchasDetails.Children.Add(botonAdmin);
        }
    }

    private async void OnAdministracionComplejoAdmin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GestionarComplejo(_complejo));
    }
}