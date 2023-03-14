using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;

namespace API_Rest.Repositories.Interfaces
{
    public interface IHistorialClinicoRepository
    {
        Task<IEnumerable<HistorialClinico>> GetAllHistorialClinico();
        Task<HistorialClinico> GetHistorialClinicoById(int id);
        Task<HistorialClinico> AddHistorialClinico(HistorialClinico historialClinico);
        Task<int> SaveChangesHistorialClinico();
        Task UpdateHistorialClinico(int id, HistorialClinico historialClinico);
        Task DeleteHistorialClinico(int id);
    }
    
}

