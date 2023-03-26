using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DetailTEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Paciente_UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        
        public Paciente_UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        // POST: api/<PacienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Paciente_Usuario paciente_usuario)
        {
            try
            {
                context.Paciente_Usuario.Add(paciente_usuario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}