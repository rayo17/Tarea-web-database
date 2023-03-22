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
using Microsoft.EntityFrameworkCore.Storage;

namespace API_Rest.Controllers
{
    [ApiController]
    public class ReservacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReservacionController(ApplicationDbContext context)
        {
            _context = context;
        }
        /*
         * POST: "api/PostReservacion"
         * Crear una nueva reservacion nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/Reservacion/{cedula}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vReservacion>>> GetReservacion(int cedula)
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "* "
                + "FROM "
                + "Paci_tiene_proc "
                + "WHERE "
                + "Paci_tiene_proc.Cedula = " + cedula.ToString()
                + ";";
            return await _context.vReservacion.FromSqlRaw(query).ToListAsync();
        }
    }
}