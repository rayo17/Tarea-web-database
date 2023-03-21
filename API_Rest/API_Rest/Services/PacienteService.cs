using API_Rest.Models;
using API_Rest.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Repositories.Interfaces;

namespace API_Rest.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> GetPacientesAsync()
        {
            return await _pacienteRepository.GetAllPacientes();
        }

        public async Task<Paciente> GetPacienteByIdAsync(string cedula)
        {
            return await _pacienteRepository.GetPacienteById(cedula);
        }

        public async Task<Paciente> CreatePacienteAsync(Paciente paciente)
        {
            try
            {
                Console.WriteLine("llamando al repositorio para añadir paciente a la base");
                return await _pacienteRepository.AddPaciente(paciente);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while creating a new patient en PacienteService: {ex.Message}");
                throw;
            }
        }
        public async Task AddPatologia(string cedula, Patologia patologia)
        {
            try
            {
                await _pacienteRepository.AddPatologia(cedula, patologia);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding patologia to paciente: {ex.Message}");
            }
        }
        
    }
}