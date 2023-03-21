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
                + "* "
                + "FROM "
                + "Paciente"
                + ";";
            
            //Retorna todos los objetos obtenidos
            return await _context.vpaciente.FromSqlRaw(query).ToListAsync();
        }

    }
}
