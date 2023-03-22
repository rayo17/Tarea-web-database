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
        [Route("api/GetPacientes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente>>> Getpaciente()
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "* "
                + "FROM "
                + "Paciente "
                + "JOIN "
                + "Direcciones_paciente "
                + "On "
                + "Paciente.Cedula = Direcciones_paciente.Cedula_paci "
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
        [Route("api/PostDirPaciente")]
        [HttpPost]
        public async Task<ActionResult> PostDirPaciente([FromBody] DireccionPaciente direccion)
        {
            string query = "INSERT INTO Direcciones_paciente(Cedula_paci, Descripcion) " +
                           $"VALUES ({direccion.CedulaPaciente}, '{direccion.Descripcion}')";

            Console.WriteLine(query);

            await _context.Database.ExecuteSqlRawAsync(query);

            return Ok();
        }
        [Route("api/PostPatologiaPaciente")]
        [HttpPost]
        public async Task<IActionResult> PostPaciTienePat([FromBody] PaciTienePat paciTienePat)
        {
            string query = "INSERT INTO Paci_tiene_pat (Cedula_paci, Id_pat) " +
                           $"VALUES ({paciTienePat.CedulaPaci}, {paciTienePat.IdPat})";

            await _context.Database.ExecuteSqlRawAsync(query);

            return Ok();
        }

        [HttpPost]
        [Route("api/PostPacienteTratamiento")]
        public async Task<ActionResult<PacienteTomaPara>> PostPacienteTomaPara([FromBody] PacienteTomaPara pacienteTomaPara)
        {
            string query = $"INSERT INTO Paciente_toma_para(Cedula_paci, Id_trat, Id_pat, Comentarios_Indicaciones) VALUES " +
                           $"({pacienteTomaPara.Cedula_paci}, {pacienteTomaPara.Id_trat}, {pacienteTomaPara.Id_pat}, '{pacienteTomaPara.Comentarios_Indicaciones}')";
    
            Console.WriteLine(query);

            await _context.Database.ExecuteSqlRawAsync(query);

            return Ok();
        }

        [HttpPost]
        [Route("api/PostTelefono")]
        public async Task<ActionResult> PostTelPaciente([FromBody] TelefonosPaciente telefono)
        {
            string query = "INSERT INTO Telefonos_paciente (Cedula_paci, Numero) " +
                           $"VALUES ({telefono.Cedula_Paci}, {telefono.Numero})";
            Console.WriteLine(query);
            await _context.Database.ExecuteSqlRawAsync(query);
            return Ok();
        }
    }
}
