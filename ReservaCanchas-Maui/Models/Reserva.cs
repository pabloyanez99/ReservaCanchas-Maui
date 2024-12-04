using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; } 
        public TimeSpan HoraInicio { get; set; } 
        public TimeSpan HoraFin { get; set; } 
        public int IdCancha { get; set; } 
    }
}
