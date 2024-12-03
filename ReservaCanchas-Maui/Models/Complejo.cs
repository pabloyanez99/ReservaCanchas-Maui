using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Models
{
    public class Complejo
    {
        public int IdComplejo { get; set; }
        public string NombreComplejo { get; set; }
        public string ImagenComplejo { get; set; }
        public List<Cancha> Canchas { get; set; } = new List<Cancha>();
        public int IdAdministrador { get; set; }
    }
}
