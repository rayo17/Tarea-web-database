using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;

namespace API_Rest.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> GetAllPacientes();
        Task<Paciente> GetPacienteById(int id);
        Task<Paciente> AddPaciente(Paciente paciente);
        Task<Paciente> UpdatePaciente(int id, Paciente paciente);
        Task DeletePaciente(int id);
    }
}