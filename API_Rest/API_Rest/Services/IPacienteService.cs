using API_Rest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Rest.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(int id);
        Task CreatePacienteAsync(Paciente paciente);
        Task UpdatePacienteAsync(Paciente paciente);
        Task DeletePacienteAsync(int id);
        Task<IEnumerable<HistorialClinico>> GetHistorialClinicoByPacienteIdAsync(int pacienteId);
        Task CreateHistorialClinicoAsync(int pacienteId, HistorialClinico historialClinico);
    }
}
