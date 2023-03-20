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
            return await _pacienteRepository.AddPaciente(paciente);
        }

        public Task UpdatePacienteAsync(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task DeletePacienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HistorialClinico> CreateHistorialClinicoAsync(string cedula, HistorialClinico historialClinico)
        {
            var paciente = await _pacienteRepository.GetPacienteById(cedula);

            if (paciente == null)
            {
                throw new KeyNotFoundException($"No se encontró ningún paciente con la cédula: {cedula}");
            }

            paciente.HistorialClinico.Add(historialClinico);

            await _pacienteRepository.UpdatePaciente(cedula,paciente);

            return historialClinico;
        }

        public async Task<IEnumerable<HistorialClinico>> GetHistorialClinicoByPacienteIdAsync(string cedula)
        {
            var paciente = await _pacienteRepository.GetPacienteById(cedula);

            if (paciente == null)
            {
                throw new KeyNotFoundException($"No se encontró ningún paciente con la cédula: {cedula}");
            }

            return paciente.HistorialClinico;
        }
    }
}