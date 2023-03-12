using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Data;
using API_Rest.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Rest.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PacienteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Paciente>> GetPacientesAsync()
        {
            return await _dbContext.Pacientes.ToListAsync();
        }

        public async Task<Paciente> GetPacienteByIdAsync(int id)
        {
            return await _dbContext.Pacientes.FindAsync(id);
        }

        public async Task<Paciente> CreatePacienteAsync(Paciente paciente)
        {
            _dbContext.Pacientes.Add(paciente);
            await _dbContext.SaveChangesAsync();
            return paciente;
        }

        public async Task UpdatePacienteAsync(Paciente paciente)
        {
            //_dbContext.Entry(paciente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePacienteAsync(int id)
        {
            var paciente = await _dbContext.Pacientes.FindAsync(id);
            _dbContext.Pacientes.Remove(paciente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HistorialClinico>> GetHistorialClinicoByPacienteIdAsync(int pacienteId)
        {
            return await _dbContext.HistorialClinicos
                .Where(hc => hc.PacienteId == pacienteId)
                .ToListAsync();
        }

        public async Task<HistorialClinico> CreateHistorialClinicoAsync(int pacienteId, HistorialClinico historialClinico)
        {
            historialClinico.CedulaPaciente = pacienteId;
            _dbContext.HistorialClinicos.Add(historialClinico);
            await _dbContext.SaveChangesAsync();
            return historialClinico;
        }
    }
}
