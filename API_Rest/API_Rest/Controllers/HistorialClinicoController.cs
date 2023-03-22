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
using Newtonsoft.Json;

namespace API_Rest.Controllers 
{
    [ApiController]
    public class HistorialClinicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistorialClinicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("api/getHistorialesClinicos")] // Revisar <<*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vHistorialClinico>>> GetHistorial()
        {
            string query =
            "SELECT "
            + "Paciente.Cedula, Procedimiento_medico.Id, Paci_tiene_proc.Fecha, Procedimiento_medico.Nombre_proc "
            + "FROM "
            + "Paciente "
            + "JOIN "
            + "Paci_tiene_proc "
            + "On "
            + "Paciente.Cedula = Paci_tiene_proc.Cedula "
            + "JOIN "
            + "Procedimiento_medico "
            + "On "
            + "Paci_tiene_proc.Id_proc = Procedimiento_medico.Id"
            + ";";

            return await _context.vhistorial_clinico.FromSqlRaw(query).ToListAsync();
        }

        /*
        [Route("api/getHistorialClinico/{cedula}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vHistorialClinico>>> getHistorialClinicoC(int cedula)
        {
            string query =
                "SELECT "
                + "* "
                + "FROM"
        }*/


    }
}