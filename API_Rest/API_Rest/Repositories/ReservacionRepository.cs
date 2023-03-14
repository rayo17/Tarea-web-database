using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Data;
using API_Rest.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Rest.Repositories
{
    public class ReservacionRepository : IReservacionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReservacionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Reservacion>> GetReservacionesAsync()
        {
            return await _dbContext.Reservaciones.ToListAsync();
        }

        public async Task<Reservacion> GetReservacionByIdAsync(int id)
        {
            return await _dbContext.Reservaciones.FindAsync(id);
        }

        public async Task<Reservacion> CreateReservacionAsync(Reservacion reservacion)
        {
            _dbContext.Reservaciones.Add(reservacion);
            await _dbContext.SaveChangesAsync();
            return reservacion;
        }

        public async Task UpdateReservacionAsync(Reservacion reservacion)
        {
            //_dbContext.Entry(reservacion).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteReservacionAsync(int id)
        {
            var reservacion = await _dbContext.Reservaciones.FindAsync(id);
            _dbContext.Reservaciones.Remove(reservacion);
            await _dbContext.SaveChangesAsync();
        }

    }
}

