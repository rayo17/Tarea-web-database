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
        // Needs some work and changes
        /*
        [HttpGet("{cedula}")]
        public Paciente_Direcciones Get(string cedula)
        {
            return context.Paciente_Direcciones.FirstOrDefault(pD => pD.Paciente == cedula);
        }
        */
        
        // GET: api/<Paciente_DireccionesController>/cedula/ubicacion
        [HttpGet("{cedula}/{ubicacion}")]
        public Paciente_Direcciones Get(string cedula, string ubicacion)
        {
            return context.Paciente_Direcciones.FirstOrDefault(pD => pD.Paciente == cedula && pD.Ubicacion == ubicacion);
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
        // Not necessary alaik
        /*
        [HttpPut("{cedula}/{ubicacion}")]
        public ActionResult Put(string cedula, string ubicacion, [FromBody] Paciente_Direcciones paciente_direcciones)
        {
            if (paciente_direcciones.Paciente == cedula && paciente_direcciones.Ubicacion == ubicacion)
            {
                context.Entry(paciente_direcciones).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        */
    
        // DELETE: api/<Paciente_DireccionesController>
        [HttpDelete("{cedula}/{ubicacion}")]
        public ActionResult Delete(string cedula, string ubicacion)
        {
            var pD = context.Paciente_Direcciones.FirstOrDefault(pD => pD.Paciente == cedula && pD.Ubicacion == ubicacion);
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