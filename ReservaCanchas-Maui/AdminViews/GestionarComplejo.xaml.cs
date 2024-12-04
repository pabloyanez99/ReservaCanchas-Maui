using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui.AdminViews;

public partial class GestionarComplejo : ContentPage
{
	public Complejo _complejo;
	public ComplejoRepository _repository;

	public GestionarComplejo(Complejo complejo)
	{
		InitializeComponent();
		_complejo = complejo;
		_repository = new ComplejoRepository();

        NombreComplejoEntry.Text = _complejo.NombreComplejo;
        ImagenComplejoEntry.Text = _complejo.ImagenComplejo;
    }
    private async void OnGuardarCambiosClicked(object sender, EventArgs e)
    {
        // Validar entradas
        if (string.IsNullOrWhiteSpace(NombreComplejoEntry.Text) ||
            string.IsNullOrWhiteSpace(ImagenComplejoEntry.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        // Actualizar los datos del complejo
        _complejo.NombreComplejo = NombreComplejoEntry.Text;
        _complejo.ImagenComplejo = ImagenComplejoEntry.Text;

        // Guardar los cambios en el repositorio
        _repository.ActualizarComplejo(_complejo);

        await DisplayAlert("Éxito", "Los datos del complejo se han actualizado correctamente.", "OK");
        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        await Navigation.PopAsync();
    }
    private async void OnAniadirCanchaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCancha(_complejo));
    }

}