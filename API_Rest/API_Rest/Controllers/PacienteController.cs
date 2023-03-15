using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API_Rest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CrearPaciente(Paciente paciente)
        {
            try
            {
               await _pacienteService.CreatePacienteAsync(paciente);
                return Ok("Paciente creado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{cedula}")]
        public async Task<IActionResult> ObtenerPacientePorCedula(string cedula)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(cedula);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }
        [Authorize]
        [HttpPost("AgregarPaciente")]
        public async Task<IActionResult> AgregarPaciente(Paciente paciente)
        {
            try
            {
                await _pacienteService.CreatePacienteAsync(paciente);
                return Ok("Paciente agregado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("AgregarHistorialClinico")]
        public async Task<IActionResult> AgregarHistorialClinico(string cedula, HistorialClinico historialClinico)
        {
            try
            {
                _pacienteService.CreateHistorialClinicoAsync(cedula, historialClinico);
                return Ok("Historial clínico agregado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
