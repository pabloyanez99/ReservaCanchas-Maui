using ReservaCanchas_Maui.Interfaces;
using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Repositories
{
    public class ReservaRepositroy : IReservaRepository
    {
        public string _fileName = Path.Combine(FileSystem.AppDataDirectory, "reservas.json");
        public void CrearReserva(Reserva reserva)
        {
            List<Reserva> listaReservas = new List<Reserva>();
            if (File.Exists(_fileName))
            {
                var contenido = File.ReadAllText(_fileName);
                listaReservas = JsonSerializer.Deserialize<List<Reserva>>(contenido) ?? new List<Reserva>();
            }

            listaReservas.Add(reserva);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(listaReservas, new JsonSerializerOptions { WriteIndented = true }));
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
