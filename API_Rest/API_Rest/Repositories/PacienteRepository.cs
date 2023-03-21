using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Data;
using API_Rest.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API_Rest.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PacienteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), "El contexto de base de datos no se ha inicializado correctamente.");
        }

        public async Task<List<Paciente>> GetAllPacientes()
        {
            return await _dbContext.Pacientes.ToListAsync();
        }

        public async Task<Paciente> GetPacienteById(string id)
        {
            return await _dbContext.Pacientes.FindAsync(id);
        }

        public async Task<Paciente> AddPaciente(Paciente paciente)
        {
            try
            {
                _dbContext.Pacientes.Add(paciente);
                await _dbContext.SaveChangesAsync();
                return paciente;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while adding a new patient en PacienteRepository: {ex.Message}");
                throw;
            }
        }
        public async Task UpdatePaciente(string id, Paciente paciente)
        {
            _dbContext.Entry(paciente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePaciente(string id)
        {
            var paciente = await _dbContext.Pacientes.FindAsync(id);
            _dbContext.Pacientes.Remove(paciente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HistorialClinico>> GetHistorialClinicoByPacienteIdAsync(string pacienteId)
        {
            return await _dbContext.HistorialClinicos
                .Where(hc => hc.CedulaPaciente == pacienteId)
                .ToListAsync();
        }

        public async Task<HistorialClinico> CreateHistorialClinicoAsync(string? pacienteId,
            HistorialClinico historialClinico)
        {
            historialClinico.CedulaPaciente = pacienteId;
            _dbContext.HistorialClinicos.Add(historialClinico);
            await _dbContext.SaveChangesAsync();
            return historialClinico;
        }
    }
}
