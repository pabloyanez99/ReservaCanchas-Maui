using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;
using System.Text.Json;

namespace ReservaCanchas_Maui.Views;

public partial class ComplejosPage : ContentPage
{
    public ComplejoRepository _repository;
    public List<Complejo> _complejos; 
	public ComplejosPage()
	{
		InitializeComponent();
        _repository = new ComplejoRepository();
        CargarComplejos();
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
            await Navigation.PushAsync(new CanchasPage(seleccionado));
        }
    }
}