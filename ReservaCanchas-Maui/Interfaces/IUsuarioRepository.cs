using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ObtenerTodosLosUsuarios();
        Usuario ObtenerUsuario(int idUsuario);
        void CrearUsuario(Usuario usuario);
        void EliminarUsuario(int idUsuario);
    }
}
