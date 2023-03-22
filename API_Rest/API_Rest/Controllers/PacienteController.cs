using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DetailTEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PacienteController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PacienteController>
        [HttpGet]
        public IEnumerable<Paciente> Get()
        {
            return context.Paciente.ToList();
        }
    }
}