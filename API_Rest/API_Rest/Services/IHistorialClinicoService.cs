using API_Rest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Rest.Services.Interfaces
{
    public interface IHistorialClinicoService
    {
        Task<IEnumerable<HistorialClinico>> GetAllHistorialClinicoAsync();
        Task<HistorialClinico> GetHistorialClinicoByIdAsync(int id);
        Task AddHistorialClinicoAsync(Paciente paciente, string procedimiento, DateTime fecha, string tratamiento);
        Task DeleteHistorialClinicoAsync(int id);
        Task UpdateHistorialClinicoAsync(string pacienteid, int id, HistorialClinico historialClinico);
    }
}