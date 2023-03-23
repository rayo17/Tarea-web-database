using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DetailTEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Paciente_DireccionesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public Paciente_DireccionesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        // GET: api/<Paciente_DireccionesController>
        [HttpGet]
        public IEnumerable<Paciente_Direcciones> Get()
        {
            return context.Paciente_Direcciones.ToList();
        }
    
        // GET: api/<Paciente_DireccionesController>/cedula
        [HttpGet("{cedula}")]
        public Paciente_Direcciones Get(string paciente)
        {
            return context.Paciente_Direcciones.FirstOrDefault(pD => pD.Paciente == paciente);
        }
    
        // POST: api/<Paciente_DireccionesController>
        [HttpPost]
        public ActionResult Post([FromBody] Paciente_Direcciones paciente_direcciones)
        {
            try
            {
                context.Paciente_Direcciones.Add(paciente_direcciones);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT: api</Paciente_DireccionesController>
        [HttpPut("{cedula}")]
        public ActionResult Put(string paciente, [FromBody] Paciente_Direcciones paciente_direcciones)
        {
            if (paciente_direcciones.Paciente == paciente)
            {
                context.Entry(paciente).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    
        // DELETE: api/<PacienteController>
        [HttpDelete("{cedula}")]
        public ActionResult Delete(string paciente)
        {
            var pD = context.Paciente_Direcciones.FirstOrDefault(pD => pD.Paciente == paciente);
            if (pD != null)
            {
                
                context.Paciente_Direcciones.Remove(pD);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}