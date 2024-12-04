using ReservaCanchas_Maui.AdminViews;
using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;
using System.Text.Json;

namespace ReservaCanchas_Maui.Views;

public partial class ComplejosPage : ContentPage
{
    public ComplejoRepository _repository;
    public List<Complejo> _complejos;
    public Usuario _usuario;
	public ComplejosPage(Usuario usuario)
	{
		InitializeComponent();
        _repository = new ComplejoRepository();
        _usuario = usuario;
        CargarComplejos();
        GenerarBotonSuperUsuario();

    }
    private void CargarComplejos()
    {
        ComplejosCollection.ItemsSource = _repository.ObtenerTodosLosComplejos();
    }
    private async void OnComplejoSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Complejo seleccionado)
        {
            // Navega a la página de listado de canchas asociadas
            await Navigation.PushAsync(new CanchasPage(seleccionado, _usuario));
        }
    }
    private void GenerarBotonSuperUsuario()
    {
         // Botón específico para superusuarios
        if (_usuario.Tipo == TipoDeUsuario.Superusuario)
        {
            var botonSuperusuario = new Button
            {
                Text = "Gestionar Complejos",
                BackgroundColor = Colors.Purple,
                TextColor = Colors.White,
                Margin = new Thickness(0, 10),
            };

            botonSuperusuario.Clicked += OnAdministracionComplejoSuperUser;

            Complejitos.Children.Add(botonSuperusuario);
        }
    }

    private async void OnAdministracionComplejoSuperUser(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddComplejo());
    }
}