using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Data;
using API_Rest.Models;
using API_Rest.Repositories.Interfaces;
using API_Rest.Services.Interfaces;

namespace API_Rest.Services
{
    public class HistorialClinicoService : IHistorialClinicoService
    {
        private readonly IHistorialClinicoRepository _historialClinicoRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public HistorialClinicoService(IHistorialClinicoRepository historialClinicoRepository)
        {
            _historialClinicoRepository = historialClinicoRepository;
        }

        public async Task<IEnumerable<HistorialClinico>> GetAllHistorialClinicoAsync()
        {
            return await _historialClinicoRepository.GetAllAsync();
        }

        public async Task<HistorialClinico> GetHistorialClinicoByIdAsync(int id)
        {
            return await _historialClinicoRepository.GetByIdAsync(id);
        }

        public async Task AddHistorialClinicoAsync(Paciente paciente, string procedimiento, DateTime fecha, string tratamiento)
        {
            var historialClinico = new HistorialClinico
            {
                Paciente = paciente,
                Procedimiento = procedimiento,
                Fecha = fecha,
                Tratamiento = tratamiento
            };

            await _historialClinicoRepository.AddAsync(historialClinico);
            await _historialClinicoRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateHistorialClinico(string cedula, int id, HistorialClinico historialClinico)
        {
            var paciente = await _pacienteRepository.GetPacienteById(cedula);
            if (paciente == null)
            {
                return false;
            }

            var historial = await _historialClinicoRepository.GetById(id);
            if (historial == null || historial.PacienteId != paciente.Id)
            {
                return false;
            }

            historial.Procedimiento = historialClinico.Procedimiento;
            historial.Fecha = historialClinico.Fecha;
            historial.Tratamiento = historialClinico.Tratamiento;

            await _historialClinicoRepository.Update(historial);

            return true;
        }

        
        

        public async Task DeleteHistorialClinicoAsync(int id)
        {
            var historialClinico = await _historialClinicoRepository.GetByIdAsync(id);

            if (historialClinico == null)
            {
                throw new ArgumentException($"No existe el historial clínico con id {id}");
            }

            await _historialClinicoRepository.DeleteAsync(historialClinico);
            await _historialClinicoRepository.SaveChangesAsync();
        }
    }
}
