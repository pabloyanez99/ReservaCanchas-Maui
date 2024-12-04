using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ReservaCanchas_Maui.AdminViews
{
    public partial class GestionarUsers : ContentPage
    {
        private readonly UsuarioRepository _usuarioRepository;
        public ObservableCollection<Usuario> Usuarios { get; set; }

        public ICommand EliminarUsuarioCommand { get; private set; }

        public GestionarUsers()
        {
            InitializeComponent();

            _usuarioRepository = new UsuarioRepository();
            Usuarios = new ObservableCollection<Usuario>(_usuarioRepository.ObtenerTodosLosUsuarios());
            EliminarUsuarioCommand = new Command<int>(EliminarUsuario);

            BindingContext = this;
        }

        private void EliminarUsuario(int idUsuario)
        {
            try
            {
                // Llama al repositorio para eliminar el usuario
                _usuarioRepository.EliminarUsuario(idUsuario);

                // Elimina de la colección observable
                var usuario = Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
                if (usuario != null)
                {
                    Usuarios.Remove(usuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
