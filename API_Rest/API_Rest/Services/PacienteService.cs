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

        public async Task<IEnumerable<Paciente>> ObtenerTodosLosPacientes()
        {
            return await _pacienteRepository.GetAllPacientes();
        }

        public async Task<Paciente> ObtenerPacientePorCedula(string cedula)
        {
            return await _pacienteRepository.GetPacienteById(cedula);
        }

        public async Task<Paciente> CrearPaciente(Paciente paciente)
        {
            return await _pacienteRepository.AddPaciente(paciente);
        }

        public async Task<HistorialClinico> AgregarHistorialClinico(string cedula, HistorialClinico historialClinico)
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

        public async Task<IEnumerable<HistorialClinico>> ObtenerHistorialClinicoPorCedula(string cedula)
        {
            var paciente = await _pacienteRepository.GetPacienteById(cedula);

            if (paciente == null)
            {
                throw new KeyNotFoundException($"No se encontró ningún paciente con la cédula: {cedula}");
            }

            return paciente.HistorialClinico;
        }

        public Task<IEnumerable<Paciente>> GetPacientesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetPacienteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetPacienteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreatePacienteAsync(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePacienteAsync(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task DeletePacienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HistorialClinico>> GetHistorialClinicoByPacienteIdAsync(int pacienteId)
        {
            throw new NotImplementedException();
        }

        public Task CreateHistorialClinicoAsync(int pacienteId, HistorialClinico historialClinico)
        {
            throw new NotImplementedException();
        }

        public Task CreateHistorialClinicoAsync(string pacienteId, HistorialClinico historialClinico)
        {
            throw new NotImplementedException();
        }
    }
}