using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace API_Rest.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    
    public class HistorialClinicoController : ControllerBase
    {
        private readonly IHistorialClinicoService _historialService;

        public HistorialClinicoController(IHistorialClinicoService historialService)
        {
            _historialService = historialService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerHistorialPorID(int id)
        {
            var historial = await _historialService.GetHistorialClinicoByIdAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return Ok(historial);
        }

        [HttpPost("AgregarHistorial")]
        public async Task<IActionResult> AgregarPaciente(string pacienteid, string procedimiento, DateTime fecha, string tratamiento)
        {
            try
            {
                _historialService.AddHistorialClinicoAsync(pacienteid, procedimiento, fecha, tratamiento);
                return Ok("Paciente agregado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("EliminarHistorial")]
        public async Task<IActionResult> DeleteHistorial(int id)
        {
            _historialService.DeleteHistorialClinicoAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            return Ok("Historial eliminado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHistorialClinico(string pacienteid, int id, HistorialClinico historialClinico)
        {
            if (id != historialClinico.Id || pacienteid != historialClinico.CedulaPaciente)
            {
                return BadRequest();
            }

            var existingHistorialClinico = await _historialService.GetHistorialClinicoByIdAsync(id);

            if (existingHistorialClinico == null)
            {
                return NotFound();
            }

            await _historialService.UpdateHistorialClinicoAsync(id, historialClinico);

            return NoContent();
        } 
    }
    
}

