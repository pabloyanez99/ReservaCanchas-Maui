using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;
using System.Text.Json;

namespace ReservaCanchas_Maui.Views;

public partial class CanchasPage : ContentPage
{
	public CanchaRepository _repository;
	public List<Cancha> _canchas;
	public Complejo _complejo;

	public CanchasPage(Complejo complejo)
	{
		InitializeComponent();
        _complejo = complejo;
        _repository = new CanchaRepository();
        Title = $"Canchas de {_complejo.NombreComplejo}";
        CargarCanchas();
    }
    private void CargarCanchas()
    {
		_canchas = _repository.ObtenerCanchasPorComplejo();
        CanchasCollection.ItemsSource = _canchas.Where(c => c.IdComplejo == _complejo.IdComplejo).ToList();
    }
    private async void OnCanchaSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Cancha seleccionada)
        {
            await Navigation.PushAsync(new ReservasPage(seleccionada));
        }
    }
}