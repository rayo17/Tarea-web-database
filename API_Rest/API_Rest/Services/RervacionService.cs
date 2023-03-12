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

        public async Task<IEnumerable<Reservacion>> GetReservacionesAsync()
        {
            return await _reservacionRepository.GetReservacionesAsync();
        }

        public async Task<Reservacion> GetReservacionByIdAsync(int id)
        {
            return await _reservacionRepository.GetReservacionByIdAsync(id);
        }

        public async Task CreateReservacionAsync(Reservacion reservacion)
        {
            await _reservacionRepository.CreateReservacionAsync(reservacion);
        }

        public async Task UpdateReservacionAsync(Reservacion reservacion)
        {
            await _reservacionRepository.UpdateReservacionAsync(reservacion);
        }

        public async Task DeleteReservacionAsync(int id)
        {
            await _reservacionRepository.DeleteReservacionAsync(id);
        }

        public Reservacion CrearReservacion(Reservacion reservacion)
        {
            throw new NotImplementedException();
        }

        public Reservacion ModificarReservacion(Reservacion reservacion)
        {
            throw new NotImplementedException();
        }

        public bool EliminarReservacion(int id)
        {
            throw new NotImplementedException();
        }

        public Reservacion ObtenerReservacion(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservacion> ObtenerTodasLasReservaciones()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservacion> ObtenerReservacionesPorPaciente(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public DateTime CalcularFechaDeSalida(Reservacion reservacion)
        {
            throw new NotImplementedException();
        }
    }
}