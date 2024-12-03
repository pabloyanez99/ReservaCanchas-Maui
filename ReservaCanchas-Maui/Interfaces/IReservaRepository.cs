using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Interfaces
{
    public interface IReservaRepository
    {
        List<Reserva> ObtenerTodasLasReservas(); 
        bool EstaDisponible(int idCancha, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin); 
        void CrearReserva(Reserva reserva); 
    }
}
