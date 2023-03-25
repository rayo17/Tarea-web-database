using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetailTEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Paciente_TelefonosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public Paciente_TelefonosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        // GET: api/<Paciente_TelefonosController>
        [HttpGet]
        public IEnumerable<Paciente_Telefonos> Get()
        {
            return context.Paciente_Telefonos.ToList();
        }
    
        // GET: api/<Paciente_TelefonosController>/cedula
        // Needs some work and changes
        /*
        [HttpGet("{cedula}")]
        public Paciente_Telefonos Get(string cedula)
        {
            return context.Paciente_Telefonos.FirstOrDefault(pT => pT.Paciente == cedula);
        }
        */
        
        // GET: api/<Paciente_TelefonosController>/cedula/telefono
        [HttpGet("{cedula}/{telefono}")]
        public Paciente_Telefonos Get(string cedula, int telefono)
        {
            return context.Paciente_Telefonos.FirstOrDefault(pT => pT.Paciente == cedula && pT.Telefono == telefono);
        }
    
        // POST: api/<Paciente_DireccionesController>
        [HttpPost]
        public ActionResult Post([FromBody] Paciente_Telefonos paciente_telefonos)
        {
            try
            {
                context.Paciente_Telefonos.Add(paciente_telefonos);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT: api</Paciente_TelefonosController>
        // Not necessary alaik
        /*
        [HttpPut("{cedula}/{telefono}")]
        public ActionResult Put(string cedula, int telefono, [FromBody] Paciente_Telefonos paciente_telefonos)
        {
            if (paciente_telefonos.Paciente == cedula && paciente_telefonos.Telefono == telefono)
            {
                context.Entry(paciente_telefonos).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        */
    
        // DELETE: api/<Paciente_TelefonosController>
        [HttpDelete("{cedula}/{telefono}")]
        public ActionResult Delete(string cedula, int telefono)
        {
            var pT = context.Paciente_Telefonos.FirstOrDefault(pT => pT.Paciente == cedula && pT.Telefono == telefono);
            if (pT != null)
            {
                context.Paciente_Telefonos.Remove(pT);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}