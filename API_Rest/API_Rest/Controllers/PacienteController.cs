using Microsoft.AspNetCore.Mvc;
using API_Rest.Models;
using API_Rest.Services.Interfaces;


namespace API_Rest.Controllers
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
        public async Task<IActionResult> CrearPaciente([FromBody] Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            try
            {
                Console.WriteLine("Creando paciente...");
                await _pacienteService.CreatePacienteAsync(paciente);
                return Ok("Paciente creado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error en el servidor al crear el paciente: " + ex.Message);
            }
        }


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

        [HttpPost("AgregarPaciente")]
        public async Task<IActionResult> AgregarPaciente([FromBody] Paciente paciente)
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
        [HttpPost("{cedula}/patologias")]
        public ActionResult<Paciente> AgregarPatologia(string cedula, [FromBody] Patologia patologia)
        {
            _pacienteService.AddPatologia(cedula, patologia);
            return Ok();
        }
        
    }
}
