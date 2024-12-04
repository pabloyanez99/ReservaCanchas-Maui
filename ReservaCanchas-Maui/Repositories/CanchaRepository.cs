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
    public class CanchaRepository : ICanchaRepository
    {
        public string _fileName = Path.Combine(AppContext.BaseDirectory, "Data", "canchas.json");
        public CanchaRepository()
        {
            string directoryPath = Path.GetDirectoryName(_fileName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directorio creado: {directoryPath}");
            }

            Console.WriteLine($"Ruta completa del archivo JSON: {_fileName}");
        }
        public void ActualizarCancha(Cancha cancha)
        {
            throw new NotImplementedException();
        }

        public void CrearCancha(Cancha cancha)
        {
            List<Cancha> canchas = new List<Cancha>();
            List<Cancha> listaCanchas = ObtenerTodasLasCanchas();

            if (File.Exists(_fileName))
            {
                var contenido = File.ReadAllText(_fileName);
                canchas = JsonSerializer.Deserialize<List<Cancha>>(contenido) ?? new List<Cancha>();
            }

            cancha.IdCancha = listaCanchas.Count > 0 ? listaCanchas.Max(c => c.IdCancha) + 1 : 1;
            canchas.Add(cancha);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(canchas, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void EliminarCancha(int idCancha)
        {
            throw new NotImplementedException();
        }

        public Cancha ObtenerCanchaPorId(int idCancha)
        {
            throw new NotImplementedException();
        }

        public List<Cancha> ObtenerCanchasPorComplejo()
        {
            throw new NotImplementedException();
        }

        public List<Cancha> ObtenerTodasLasCanchas()
        {
            List<Cancha> _canchas;
            if (File.Exists(_fileName))
            {
                string contenidoJson = File.ReadAllText(_fileName);
                _canchas = JsonSerializer.Deserialize<List<Cancha>>(contenidoJson) ?? new List<Cancha>();
                return _canchas;
            }
            else
            {
                return new List<Cancha>();
            }
        }
    }
}
