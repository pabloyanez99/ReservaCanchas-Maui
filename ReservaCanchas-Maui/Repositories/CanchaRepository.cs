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
        public string _fileName = Path.Combine(FileSystem.AppDataDirectory, "canchas.json");
        public void ActualizarCancha(Cancha cancha)
        {
            throw new NotImplementedException();
        }

        public void CrearCancha(Cancha cancha)
        {
            List<Cancha> listaCanchas = new List<Cancha>();
            if (File.Exists(_fileName))
            {
                var contenido = File.ReadAllText(_fileName);
                listaCanchas = JsonSerializer.Deserialize<List<Cancha>>(contenido) ?? new List<Cancha>();
            }

            listaCanchas.Add(cancha);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(listaCanchas, new JsonSerializerOptions { WriteIndented = true }));
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

        public List<Cancha> ObtenerTodasLasCanchas()
        {
            throw new NotImplementedException();
        }
    }
}
