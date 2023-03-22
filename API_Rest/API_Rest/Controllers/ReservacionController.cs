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
using Newtonsoft.Json;

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
        [Route("api/GetProcedimiento/{cedula}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vProcedimiento>>> GetProcedimiento(int cedula)
        {
            //SP Store procedure Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "* "
                + "FROM "
                + "Paci_tiene_proc "
                + "WHERE "
                + "Paci_tiene_proc.Cedula = " + cedula.ToString()
                + ";";
            return await _context.vProcedimiento.FromSqlRaw(query).ToListAsync();
        }
        [Route("api/GetNombre/{cedula}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vReservGNombre>>> GetNombre(int cedula)
        {
            string query =
                "SELECT "
                + "Nombre "
                + "FROM "
                + "Paciente "
                + "WHERE "
                + "Paciente.Cedula = " + cedula.ToString()
                + ";";
            return await _context.vReservGNombre.FromSqlRaw(query).ToListAsync();
        }

        [Route("api/GetReservacion/{cedula}")]
        [HttpGet]
        public async Task<string> GetReservacion(int cedula)
        {
            string query = "Select P.Cedula, P.Nombre, PC.Id_proc,PC.Fecha " +
                           "from Paci_tiene_proc PC " +
                           "join Paciente P ON P.Cedula = PC.Cedula " +
                           "where PC.Cedula = " + cedula;

            var resultado = await _context.vReservacion.FromSqlRaw(query).ToListAsync();

            if (resultado.Count > 0)
            {
                var reservas = resultado.Select(r => new {
                    Nombre = r.Nombre,
                    Id_proc = r.Id_proc,
                    Fecha = r.Fecha
                });
                return JsonConvert.SerializeObject(reservas);
            }
            else
            {
                Console.WriteLine("No se encontraron resultados.");
            }
            // Devolver una respuesta
            return JsonConvert.SerializeObject(resultado);

        }

    }
}