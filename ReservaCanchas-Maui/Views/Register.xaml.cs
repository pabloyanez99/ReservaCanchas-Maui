using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui;

public partial class Register : ContentPage
{
    private readonly UsuarioRepository _usuarioRepository;
    public Register()
	{
		InitializeComponent();
        _usuarioRepository = new UsuarioRepository();
    }
    private async void OnLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private void MostrarPasswordChanged(object sender, CheckedChangedEventArgs e)
    {
        bool isChecked = e.Value;

        PasswordEntry.IsPassword = !isChecked;
        ConfirmarPasswordEntry.IsPassword = !isChecked;
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Validar que los campos no estén vacíos
        if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
            string.IsNullOrWhiteSpace(CorreoEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(ConfirmarPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        if (PasswordEntry.Text != ConfirmarPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        Usuario nuevoUsuario = new Usuario
        {
            NombreUsuario = NombreEntry.Text,
            CorreoUsuario = CorreoEntry.Text,
            PasswordUsuario = PasswordEntry.Text,
            Tipo = TipoDeUsuario.Normal 
        };

        // Guardar el usuario en el archivo JSON
        bool usuarioCreado = _usuarioRepository.CrearUsuario(nuevoUsuario);

        if (!usuarioCreado)
        {
            await DisplayAlert("Error", "El correo ya está registrado.", "OK");
            return;
        }

        await DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");

        await Navigation.PushAsync(new MainPage());
    }
}