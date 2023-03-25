using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DetailTEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatologiaController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PatologiaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Patologia
        [HttpGet]
        public IEnumerable<Patologia> Get()
        {
            return context.Patologia.ToList();
        }

        // GET: api/Patologia/5
        [HttpGet("{paciente}")]
        public ActionResult<Patologia> Get(int paciente)
        {
            var patologia = context.Patologia.FirstOrDefault(p => p.paciente == paciente);

            if (patologia == null)
            {
                return NotFound();
            }

            return patologia;
        }

        // POST: api/Patologia
        [HttpPost]
        public ActionResult<Patologia> Post(Patologia patologia)
        {
            try
            {
                context.Patologia.Add(patologia);
                context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { paciente = patologia.paciente }, patologia);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Patologia/5
        [HttpPut("{paciente}")]
        public IActionResult Put(int paciente, Patologia patologia)
        {
            if (paciente != patologia.paciente)
            {
                return BadRequest();
            }

            context.Entry(patologia).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatologiaExists(paciente))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Patologia/5
        [HttpDelete("{paciente}")]
        public IActionResult Delete(int paciente)
        {
            var patologia = context.Patologia.FirstOrDefault(p => p.paciente == paciente);

            if (patologia == null)
            {
                return NotFound();
            }

            context.Patologia.Remove(patologia);
            context.SaveChanges();

            return NoContent();
        }

        private bool PatologiaExists(int paciente)
        {
            return context.Patologia.Any(p => p.paciente == paciente);
        }
    }
}