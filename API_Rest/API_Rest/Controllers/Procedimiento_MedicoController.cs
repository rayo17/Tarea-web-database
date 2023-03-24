using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DetailTEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientoMedicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProcedimientoMedicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProcedimientoMedico
        [HttpGet]
        public ActionResult<IEnumerable<Procedimiento_Medico>> Get()
        {
            return _context.Procedimiento_Medico.ToList();
        }

        // GET: api/ProcedimientoMedico/5
        [HttpGet("{paciente}")]
        public ActionResult<Procedimiento_Medico> Get(int paciente)
        {
            var procedimientoMedico = _context.Procedimiento_Medico.FirstOrDefault(p => p.paciente == paciente);

            if (procedimientoMedico == null)
            {
                return NotFound();
            }

            return procedimientoMedico;
        }

        // POST: api/ProcedimientoMedico
        [HttpPost]
        public ActionResult<Procedimiento_Medico> Post(Procedimiento_Medico procedimientoMedico)
        {
            try
            {
                _context.Procedimiento_Medico.Add(procedimientoMedico);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { paciente = procedimientoMedico.paciente }, procedimientoMedico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/ProcedimientoMedico/5
        [HttpPut("{paciente}")]
        public IActionResult Put(int paciente, Procedimiento_Medico procedimientoMedico)
        {
            if (paciente != procedimientoMedico.paciente)
            {
                return BadRequest();
            }

            _context.Entry(procedimientoMedico).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedimientoMedicoExists(paciente))
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

        // DELETE: api/ProcedimientoMedico/5
        [HttpDelete("{paciente}")]
        public IActionResult Delete(int paciente)
        {
            var procedimientoMedico = _context.Procedimiento_Medico.FirstOrDefault(p => p.paciente == paciente);

            if (procedimientoMedico == null)
            {
                return NotFound();
            }

            _context.Procedimiento_Medico.Remove(procedimientoMedico);
            _context.SaveChanges();

            return NoContent();
        }

        private bool ProcedimientoMedicoExists(int paciente)
        {
            return _context.Procedimiento_Medico.Any(p => p.paciente == paciente);
        }
    }
}
