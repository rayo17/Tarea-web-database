using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Repositories.Interfaces;
using API_Rest.Services.Interfaces;

namespace API_Rest.Services
{
    public class ReservacionService : IReservacionService
    {
        private readonly IReservacionRepository _reservacionRepository;

        public ReservacionService(IReservacionRepository reservacionRepository)
        {
            _reservacionRepository = reservacionRepository;
        }

        public async Task<IEnumerable<Reservacion>> ObtenerTodasLasReservaciones()
        {
            return await _reservacionRepository.GetReservacionesAsync();
        }

        public Task<IEnumerable<Reservacion>> ObtenerReservacionesPorPaciente(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime> CalcularFechaDeSalida(Reservacion reservacion)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservacion> ObtenerReservacion(int id)
        {
            return await _reservacionRepository.GetReservacionByIdAsync(id);
        }

        public async Task CrearReservacion(Reservacion reservacion)
        {
            await _reservacionRepository.CreateReservacionAsync(reservacion);
        }

        public async Task ModificarReservacion(Reservacion reservacion)
        {
            await _reservacionRepository.UpdateReservacionAsync(reservacion);
        }

        public async Task EliminarReservacion(int id)
        {
            await _reservacionRepository.DeleteReservacionAsync(id);
        }
        
    }
}