using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DetailTEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        
        public ReservacionController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        // GET: api/<ReservacionController>/cedula
        [HttpGet("{cedula}")]
        public Reservacion Get(string cedula)
        {
            return context.Reservacion.FirstOrDefault(r=>r.Paciente == cedula);
        }
        
        // POST: api/<ReservacionController>
        [HttpPost]
        public ActionResult Post([FromBody] Reservacion reservacion)
        {
            try
            {
                context.Reservacion.Add(reservacion);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error saving the entity changes: " + e.InnerException?.Message);
            }
        }
    }
    
}