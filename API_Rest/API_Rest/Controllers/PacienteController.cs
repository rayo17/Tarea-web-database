using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Models;
using API_Rest.Services.Interfaces;
namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

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

        [HttpGet("{cedula}")]
        public async Task<IActionResult> VerHistorialClinico(int cedula)
        {
            try
            {
                IEnumerable<HistorialClinico> historialClinico = await _pacienteService.GetHistorialClinicoByPacienteIdAsync(cedula);
                return Ok(historialClinico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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

        [HttpPost("AgregarHistorialClinico")]
        public async Task<IActionResult> AgregarHistorialClinico(int cedula, HistorialClinico historialClinico)
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
