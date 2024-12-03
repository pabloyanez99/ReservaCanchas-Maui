using ReservaCanchas_Maui.Interfaces;
using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Repositories
{
    public class ReservaRepositroy : IReservaRepository
    {
        public void CrearReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public bool EstaDisponible(int idCancha, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ObtenerTodasLasReservas()
        {
            throw new NotImplementedException();
        }
    }
}
