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
            return await _historialClinicoRepository.GetAllHistorialClinico();
        }

        public async Task<HistorialClinico> GetHistorialClinicoByIdAsync(int id)
        {
            return await _historialClinicoRepository.GetHistorialClinicoById(id);
        }

        public async Task AddHistorialClinicoAsync(String cedulaPaciente, string procedimiento, DateTime fecha, string tratamiento)
        {
            var paciente = await _pacienteRepository.GetPacienteById(cedulaPaciente);
            
            if (paciente == null)
            {
                throw new Exception("Paciente no encontrado");
            }
            var historialClinico = new HistorialClinico
            {
                CedulaPaciente = cedulaPaciente,
                Procedimiento = procedimiento,
                Fecha = fecha,
                Tratamiento = tratamiento
            };

            await _historialClinicoRepository.AddHistorialClinico(historialClinico);
            _historialClinicoRepository.SaveChangesHistorialClinico();
        }

        public async Task UpdateHistorialClinicoAsync(int id, HistorialClinico historialupdate)
        {
            var historialClinico = await _historialClinicoRepository.GetHistorialClinicoById(id);

            if (historialClinico == null)
            {
                throw new ArgumentException($"No existe el historial clínico con id {id}");
            }

            historialClinico = historialupdate;
            _historialClinicoRepository.SaveChangesHistorialClinico();
        }
        
        

        public async Task DeleteHistorialClinicoAsync(int id)
        {
            var historialClinico = await _historialClinicoRepository.GetHistorialClinicoById(id);

            if (historialClinico == null)
            {
                throw new ArgumentException($"No existe el historial clínico con id {id}");
            }

            await _historialClinicoRepository.DeleteHistorialClinico(id);
            _historialClinicoRepository.SaveChangesHistorialClinico();
        }
    }
}
