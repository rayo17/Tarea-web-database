using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;

namespace API_Rest.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> GetAllPacientes();
        Task<Paciente> GetPacienteById(string id);
        Task<Paciente> AddPaciente(Paciente paciente);
        Task<Paciente> UpdatePaciente(string id, Paciente paciente);
        Task DeletePaciente(string id);
    }
}