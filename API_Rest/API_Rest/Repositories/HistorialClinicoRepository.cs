using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Data;
using API_Rest.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Rest.Repositories
{
    public class HistorialClinicoRepository : IHistorialClinicoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HistorialClinicoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<HistorialClinico>> GetAllHistorialClinico()
        {
            return await _dbContext.HistorialClinico.ToListAsync();
        }

        public async Task<HistorialClinico> GetHistorialClinicoById(int id)
        {
            return await _dbContext.HistorialClinico.FindAsync(id);
        }
        public async Task<HistorialClinico> AddHistorialClinico(HistorialClinico historialClinico)
        {
            _dbContext.HistorialClinico.Add(historialClinico);
            await _dbContext.SaveChangesAsync();
            return historialClinico;
        }
        public async Task UpdateHistorialClinico(int id, HistorialClinico historialClinico)
        {
            //_dbContext.Entry(historialClinico).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteHistorialClinico(int id)
        {
            var historialclinico = await _dbContext.HistorialClinico.FindAsync(id);
            _dbContext.HistorialClinico.Remove(historialclinico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveChangesHistorialClinico()
        {
            try
            {
                return await _dbContext.SaveChangesHistorialClinico;
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("An error occurred while saving changes.", ex);
            }
        }
    }
    
}

