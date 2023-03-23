using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

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

        // GET: api/<PacienteController>/cedula
        [HttpGet("{cedula}")]
        public Paciente Get(string cedula)
        {
            return context.Paciente.FirstOrDefault(p => p.Cedula == cedula);
        }

        // POST: api/<PacienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Paciente paciente)
        {
            try
            {
                context.Paciente.Add(paciente);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT: api</PacienteController>
        [HttpPut("{cedula}")]
        public ActionResult Put(string cedula, [FromBody] Paciente paciente)
        {
            if (paciente.Cedula == cedula)
            {
                context.Entry(paciente).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/<PacienteController>
        [HttpDelete("{cedula}")]
        public ActionResult Delete(string cedula)
        {
            var paciente = context.Paciente.FirstOrDefault(p => p.Cedula == cedula);
            if (paciente != null)
            {
                
                context.Paciente.Remove(paciente);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}