using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui.AdminViews;

public partial class AddComplejo : ContentPage
{
    public ComplejoRepository _repository;
    public Complejo _complejo;
    public AddComplejo()
	{
		InitializeComponent();
        _repository = new ComplejoRepository();
        _complejo = new Complejo();
    }
    private async void OnGestionarCanchasClicked(object sender, EventArgs e)
    {
        // Navega a la página de gestión de canchas y pasa el Complejo actual
        await Navigation.PushAsync(new AddCancha(_complejo));
    }
    private async void OnGuardarComplejoClicked(object sender, EventArgs e)
    {
        // Asignar los datos ingresados
        _complejo.IdComplejo = new Random().Next(1, 1000); // Generación automática del ID
        _complejo.NombreComplejo = NombreComplejoEntry.Text;
        _complejo.ImagenComplejo = ImagenComplejoEntry.Text;
        _complejo.IdAdministrador = int.TryParse(IdAdministradorEntry.Text, out int idAdmin) ? idAdmin : 0;

        _repository.CrearComplejo(_complejo);

        Console.WriteLine($"Complejo creado: {_complejo.NombreComplejo} con {(_complejo.Canchas.Count)} canchas.");

        await DisplayAlert("Éxito", "Complejo guardado correctamente.", "OK");
        await Navigation.PopAsync();
    }
}