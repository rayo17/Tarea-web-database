using API_Rest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Rest.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(string id);
        Task<Paciente> CreatePacienteAsync(Paciente paciente);
        Task AddPatologia(string cedula, Patologia patologia);
    }
}
