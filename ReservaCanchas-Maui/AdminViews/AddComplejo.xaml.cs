using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;
using System.Text.Json;

namespace ReservaCanchas_Maui.AdminViews;

public partial class AddComplejo : ContentPage
{
    public ComplejoRepository _complejoRepository;
    public Complejo _complejo;
    public UsuarioRepository _userRepository;
    public List<Usuario> _administradores;
    public AddComplejo()
	{
		InitializeComponent();
        _complejoRepository = new ComplejoRepository();
        _complejo = new Complejo();
        _userRepository = new UsuarioRepository();
        _administradores = CargarAdministradores();

        AdministradorPicker.ItemsSource = _administradores;
    }
    private List<Usuario> CargarAdministradores()
    {
        List<Usuario> _listaAdministradores = new List<Usuario>();
        _listaAdministradores = _userRepository.ObtenerTodosLosUsuarios();

        return _listaAdministradores?.Where(u => u.Tipo == TipoDeUsuario.Administrador).ToList() ?? new List<Usuario>();
    }
    private async void OnGuardarComplejoClicked(object sender, EventArgs e)
    {
        // Validar que se haya seleccionado un administrador
        if (AdministradorPicker.SelectedItem is not Usuario administradorSeleccionado)
        {
            await DisplayAlert("Error", "Seleccione un administrador válido.", "OK");
            return;
        }

        // Asignar los datos ingresados
        _complejo.NombreComplejo = NombreComplejoEntry.Text;
        _complejo.ImagenComplejo = ImagenComplejoEntry.Text;
        _complejo.IdAdministrador = administradorSeleccionado.IdUsuario;

        _complejoRepository.CrearComplejo(_complejo);

        // Actualizar lista de complejos de administrador
        administradorSeleccionado.ComplejosAdministrados.Add(_complejo.IdComplejo);
        _userRepository.ActualizarUsuario(administradorSeleccionado);

        Console.WriteLine($"Complejo creado: {_complejo.NombreComplejo} con {(_complejo.Canchas.Count)} canchas.");

        await DisplayAlert("Éxito", "Complejo guardado correctamente.", "OK");
        await Navigation.PopAsync();
    }
}