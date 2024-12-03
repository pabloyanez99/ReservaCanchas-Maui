using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservaCanchas_Maui.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string PasswordUsuario { get; set; }
        public TipoDeUsuario Tipo { get; set; }
        public List<int> ComplejosAdministrados { get; set; } = new List<int>();
    }

    public enum TipoDeUsuario
    {
        Normal, 
        Administrador, 
        Superusuario
    }
}
