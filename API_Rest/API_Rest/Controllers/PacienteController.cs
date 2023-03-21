using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Rest.Data;
using API_Rest.Models;
using API_Rest.Models.Views;

namespace API_Rest.Controllers
{
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        /*
        * GET: "api/GetPacientes"
        * Obtiene todos los pacientes en la base de datos
        */
        [Route("api/Paciente")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente>>> Getpaciente()
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "nombre, "
                + "cedula "
                + "FROM "
                + "Paciente"
                + ";";
            
            //Retorna todos los objetos obtenidos
            return await _context.vpaciente.FromSqlRaw(query).ToListAsync();
        }
        /*
         * GET: "api/GetPacienteC/cedula"
         * Obtiene solo el paciente con la cedula indicado
         */
        [Route("api/Paciente/{cedula}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente>>> GetPacienteC(int cedula)
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "* "
                + "FROM "
                + "Paciente "
                + "WHERE "
                + "cedula = " + cedula.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente.FromSqlRaw(query).ToListAsync();
        }
        /*
         * POST: "api/PostPaciente"
         * Agregar un paciente nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostPaciente")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<vPaciente>>> PostPaciente([FromBody] Paciente paciente)
        {
            /*_context.paciente.Add(paciente);
            await _context.SaveChangesAsync();*/

            string query = "INSERT INTO Paciente("
                           +"Nombre, "
                           + "Primer_apellido, " +"Segundo_apellido, " 
                           +"Cedula, " + "Fecha_nacimiento) "
                           + "VALUES (" 
                           + $"'{paciente.Nombre}', '{paciente.Primer_apellido}', "
                           + $"'{paciente.Segundo_apellido}', {paciente.Cedula}, "
                           + $"'{paciente.Fecha_nacimiento.ToString("yyyy-MM-dd")}'"
                           + ");";
            
            Console.WriteLine(query);

            await _context.Database.ExecuteSqlRawAsync(query);

            Task<ActionResult<IEnumerable<vPaciente>>> paciente_wid = GetPacienteC(paciente.Cedula);

            return await paciente_wid; //CreatedAtAction("GetPaciente", new { id = paciente.cedula }, paciente);
        }

    }
}
