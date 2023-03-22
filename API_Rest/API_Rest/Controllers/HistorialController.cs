using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DetailTEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public HistorialController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PacienteController>
        [HttpGet]
        public IEnumerable<Historial> Get()
        {
            return context.Historial.ToList();
        }
    }
}