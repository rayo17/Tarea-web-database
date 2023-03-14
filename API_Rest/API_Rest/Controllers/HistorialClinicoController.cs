using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Services.Interfaces;


namespace API_Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class HistorialClinicoController : ControllerBase
    {
        private readonly IHistorialService _historialService;

        public HistorialClinicoController(IHistorialService historialService)
        {
            _historialService = historialService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearHistorial(HistorialClinico historial)
        {
            try
            {
                await _historialService.CreateHistorialAsync(historial);
                return Ok("Historial Clinico creado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerHistorialPorID(string id)
        {
            var historial = await _historialService.GetHistorialByIdAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return Ok(historial);
        }
        [HttpPost("AgregarHistorial")]
        public async Task<IActionResult> AgregarHistorial(Paciente paciente)
        {
            try
            {
                await _historialService.CreateHistorialAsync(paciente);
                return Ok("Historial agregado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AgregarPaciente")]
        public async Task<IActionResult> AgregarPaciente(string id, Paciente paciente)
        {
            try
            {
                _historialService.CreatePacienteAsync(id, paciente);
                return Ok("Paciente agregado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}

