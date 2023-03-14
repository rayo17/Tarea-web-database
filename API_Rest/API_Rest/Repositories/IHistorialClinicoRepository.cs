using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;

namespace API_Rest.Repositories.Interfaces
{
    public class IHistorialClinicoRepository
    {
        Task<List<HistorialClinico>> GetAllHistorialClinico();
        Task<HistorialClinico> GetHistorialClinicoById(int id);
        Task<HistorialClinico> AddHistorialClinico(Paciente paciente, string procedimiento, DateTime fecha, string tratamiento);
        Task<Paciente> UpdateHistorialClinico(int id, Paciente paciente, );
        Task DeleteHistorialClinico(int id);
    }
    
}

