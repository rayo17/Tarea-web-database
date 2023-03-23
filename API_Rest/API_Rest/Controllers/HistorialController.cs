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
        // GET: api/<HistorialController>
        [HttpGet]
        public IEnumerable<Historial> Get()
        {
            return context.Historial.ToList();
        }

        [HttpGet("{cedula}")]
        public Historial Get(string cedula)
        { // Eliminar el toString luego de cambiar el tipo de iD (TODO)
            return context.Historial.FirstOrDefault(h => h.Id.ToString() == cedula);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Historial historial)
        {
            try
            {
                context.Historial.Add(historial);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{cedula}")]
        public ActionResult Put(string cedula, [FromBody] Historial historial)
        {
            if (historial.Id.ToString() == cedula) // Eliminar el toString tras cambiar el tipo de Id (TODO)
            {
                context.Entry(historial).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{cedula}")]
        public ActionResult Delete(string cedula)
        {
            var h = context.Historial.FirstOrDefault(t => t.Id.ToString() == cedula);
            if (h != null)
            {
                context.Historial.Remove(h);
                context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }
    }
}