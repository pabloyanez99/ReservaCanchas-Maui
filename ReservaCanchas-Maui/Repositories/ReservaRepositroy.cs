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
        public string _fileName = Path.Combine(AppContext.BaseDirectory, "Data", "reservas.json");
        public ReservaRepositroy()
        {
            string directoryPath = Path.GetDirectoryName(_fileName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directorio creado: {directoryPath}");
            }

            Console.WriteLine($"Ruta completa del archivo JSON: {_fileName}");
        }
        public void CrearReserva(Reserva reserva)
        {
            List<Reserva> reservas = ObtenerTodasLasReservas();

            // Incrementar el ID de la reserva
            reserva.IdReserva = reservas.Count > 0 ? reservas.Max(r => r.IdReserva) + 1 : 1;

            // Agregar la nueva reserva a la lista
            reservas.Add(reserva);

            // Guardar las reservas en el archivo JSON
            File.WriteAllText(_fileName, JsonSerializer.Serialize(reservas, new JsonSerializerOptions { WriteIndented = true }));
        }


        public bool EstaDisponible(int idCancha, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            var reservas = ObtenerTodasLasReservas();

            foreach (var reserva in reservas)
            {
                // Verificar si es la misma cancha y misma fecha
                if (reserva.IdCancha == idCancha && reserva.Fecha.Date == fecha.Date)
                {
                    // Verificar superposición de horarios
                    if ((horaInicio < reserva.HoraFin && horaFin > reserva.HoraInicio) ||
                        (horaInicio == reserva.HoraInicio && horaFin == reserva.HoraFin))
                    {
                        return false; // Hay una reserva que se superpone
                    }
                }
            }

            return true; // No hay superposición
        }


        public List<Reserva> ObtenerTodasLasReservas()
        {
            List<Reserva> listaReservas;
            if (File.Exists(_fileName))
            {
                string contenidoJson = File.ReadAllText(_fileName);
                listaReservas = JsonSerializer.Deserialize<List<Reserva>>(contenidoJson) ?? new List<Reserva>();
                return listaReservas;
            }
            else
            {
                return new List<Reserva>();
            }
        }
    }
}
