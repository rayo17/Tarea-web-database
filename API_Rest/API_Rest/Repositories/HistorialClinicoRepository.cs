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

        public PacienteRepository(ApplicationDbContext dbContext)
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
        public async Task<HistorialClinico> AddHistorialClinico(Paciente paciente, string procedimiento, DateTime fecha, string tratamiento)
        {
            return await _dbContext.HistorialClinico.;
        }
    }
    
}

