using ReservaCanchas_Maui.Interfaces;
using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Repositories
{
    public class ComplejoRepository : IComplejoRepository
    {
        public string _fileName = Path.Combine(FileSystem.AppDataDirectory, "complejos.json");

        public Complejo ObtenerComplejo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ActualizarComplejo(Complejo complejo)
        {
            throw new NotImplementedException();
        }

        public void CrearComplejo(Complejo complejo)
        {
            List<Complejo> listaComplejos = new List<Complejo>();
            if (File.Exists(_fileName))
            {
                var contenido = File.ReadAllText(_fileName);
                listaComplejos = JsonSerializer.Deserialize<List<Complejo>>(contenido) ?? new List<Complejo>();
            }

            listaComplejos.Add(complejo);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(listaComplejos, new JsonSerializerOptions { WriteIndented = true }));
            
        }

        public void EliminarComplejo(int idComplejo)
        {
            throw new NotImplementedException();
        }

        public List<Complejo> ObtenerTodosLosComplejos()
        {
            List<Complejo> _complejos;
            if (File.Exists(_fileName))
            {
                string contenidoJson = File.ReadAllText(_fileName);
                _complejos = JsonSerializer.Deserialize<List<Complejo>>(contenidoJson) ?? new List<Complejo>();
                return _complejos;
            } else
            {
                return new List<Complejo>();
            }
            
        }
    }
}
