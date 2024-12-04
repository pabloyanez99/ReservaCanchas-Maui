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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _fileName = Path.Combine(AppContext.BaseDirectory, "Data", "usuarios.json");

        // 
        public UsuarioRepository()
        {
            string directoryPath = Path.GetDirectoryName(_fileName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directorio creado: {directoryPath}");
            }

            Console.WriteLine($"Ruta completa del archivo JSON: {_fileName}");
        }

        public bool CrearUsuario(Usuario usuario)
        {
            List<Usuario> usuarios = ObtenerTodosLosUsuarios();

            // Validar si el correo ya existe
            if (usuarios.Any(u => u.CorreoUsuario.Equals(usuario.CorreoUsuario, StringComparison.OrdinalIgnoreCase)))
            {
                return false; 
            }

            usuario.IdUsuario = usuarios.Count > 0 ? usuarios.Max(u => u.IdUsuario) + 1 : 1;

            usuarios.Add(usuario);

            string contenidoJson = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_fileName, contenidoJson);

            return true; 
        }

        public void EliminarUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
        public void ActualizarUsuario(Usuario usuarioActualizado)
        {
            if (File.Exists(_fileName))
            {
                // Leer el archivo JSON existente
                string contenidoJson = File.ReadAllText(_fileName);
                var usuarios = JsonSerializer.Deserialize<List<Usuario>>(contenidoJson) ?? new List<Usuario>();

                // Encontrar y actualizar el usuario correspondiente
                var usuarioExistente = usuarios.FirstOrDefault(u => u.IdUsuario == usuarioActualizado.IdUsuario);
                if (usuarioExistente != null)
                {
                    usuarioExistente.ComplejosAdministrados = usuarioActualizado.ComplejosAdministrados;
                }

                // Guardar los cambios de nuevo en el archivo JSON
                string nuevoJson = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_fileName, nuevoJson);
            }
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            if (!File.Exists(_fileName))
            {
                File.WriteAllText(_fileName, "[]");
                return new List<Usuario>();
            }

            string contenidoJson = File.ReadAllText(_fileName);
            return JsonSerializer.Deserialize<List<Usuario>>(contenidoJson) ?? new List<Usuario>();
        }

        public Usuario ObtenerUsuario(int idUsuario)
        {
            List<Usuario> usuarios = ObtenerTodosLosUsuarios();
            return usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void ActualizarTipoDeUsuario(int idUsuario, TipoDeUsuario nuevoTipo)
        {
            List<Usuario> usuarios = ObtenerTodosLosUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario != null)
            {
                usuario.Tipo = nuevoTipo;
                File.WriteAllText(_fileName, JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true }));
            }
        }
    }
}
