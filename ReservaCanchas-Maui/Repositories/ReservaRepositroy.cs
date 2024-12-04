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
            List<Reserva> reservas = new List<Reserva>();
            List<Reserva> listaReservas= ObtenerTodasLasReservas();

            if (File.Exists(_fileName))
            {
                var contenido = File.ReadAllText(_fileName);
                reservas = JsonSerializer.Deserialize<List<Reserva>>(contenido) ?? new List<Reserva>();
            }

            reserva.IdCancha = listaReservas.Count > 0 ? listaReservas.Max(c => c.IdCancha) + 1 : 1;
            reservas.Add(reserva);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(reservas, new JsonSerializerOptions { WriteIndented = true }));
        }

        public bool EstaDisponible(int idCancha, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            throw new NotImplementedException();
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
