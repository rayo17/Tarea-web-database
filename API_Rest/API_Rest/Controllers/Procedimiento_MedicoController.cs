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

        // POST: api/ProcedimientoMedico
        [HttpPost]
        public ActionResult<Procedimiento_Medico> Post(Procedimiento_Medico procedimientoMedico)
        {
            try
            {
                _context.Procedimiento_Medico.Add(procedimientoMedico);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ProcedimientoMedico/5
        [HttpDelete("{paciente}")]
        public IActionResult Delete(string procedimiento)
        {
            var procedimientoMedico = _context.Procedimiento_Medico.FirstOrDefault(p => p.nombre == procedimiento);

            if (procedimientoMedico == null)
            {
                return NotFound();
            }

            _context.Procedimiento_Medico.Remove(procedimientoMedico);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
