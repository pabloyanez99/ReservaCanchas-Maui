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
        public string _fileName = Path.Combine(AppContext.BaseDirectory,"Data", "complejos.json");
        public ComplejoRepository() 
        {
            string directoryPath = Path.GetDirectoryName(_fileName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directorio creado: {directoryPath}");
            }

            Console.WriteLine($"Ruta completa del archivo JSON: {_fileName}");
        }
        public Complejo ObtenerComplejo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ActualizarComplejo(Complejo complejo)
        {
            throw new NotImplementedException();
        }

        public void CrearComplejo(Complejo complejo)
        {
            List<Complejo> complejos = new List<Complejo>();
            List<Complejo> listaComplejos = ObtenerTodosLosComplejos();

            if (File.Exists(_fileName))
            {
                var contenido = File.ReadAllText(_fileName);
                complejos = JsonSerializer.Deserialize<List<Complejo>>(contenido) ?? new List<Complejo>();
            }

            complejo.IdComplejo = listaComplejos.Count > 0 ? listaComplejos.Max(c => c.IdComplejo) + 1 : 1;

            complejos.Add(complejo);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(complejos, new JsonSerializerOptions { WriteIndented = true }));
            
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
