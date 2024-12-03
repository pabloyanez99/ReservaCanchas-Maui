using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Interfaces
{
    public interface ICanchaRepository
    {
        List<Cancha> ObtenerTodasLasCanchas(); 
        List<Cancha> ObtenerCanchasPorComplejo(); 
        Cancha ObtenerCanchaPorId(int idCancha); 
        void CrearCancha(Cancha cancha); 
        void ActualizarCancha(Cancha cancha); 
        void EliminarCancha(int idCancha); 
    }
}
