using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Interfaces
{
    public interface IComplejoRepository
    {
        List<Complejo> ObtenerTodosLosComplejos();
        Complejo ObtenerComplejo { get; set; }
        void CrearComplejo(Complejo complejo); 
        void ActualizarComplejo(Complejo complejo); 
        void EliminarComplejo(int idComplejo); 
    }
}
