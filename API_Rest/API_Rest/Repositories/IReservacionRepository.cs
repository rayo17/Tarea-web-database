using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;

namespace API_Rest.Repositories.Interfaces
{
    public interface IReservacionRepository
    {
        Task<IEnumerable<Reservacion>> GetReservacionesAsync();
        Task<Reservacion> GetReservacionByIdAsync(int id);
        Task<IEnumerable<Reservacion>> GetReservacionesByFechaAsync(DateTime fecha);
        Task<IEnumerable<Reservacion>> GetReservacionesByCamaIdAsync(int id);
        Task<IEnumerable<Reservacion>> GetReservacionesByPacienteIdAsync(int id);
        Task CreateReservacionAsync(Reservacion reservacion);
        Task UpdateReservacionAsync(Reservacion reservacion);
        Task DeleteReservacionAsync(int id);
    }
}