using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservacionController : ControllerBase
    {
        private readonly IReservacionService _reservacionService;

        public ReservacionController(IReservacionService reservacionService)
        {
            _reservacionService = reservacionService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Reservacion>> CrearReservacion(Reservacion reservacion)
        {
            try
            {
                Reservacion reservacionCreada = _reservacionService.CrearReservacion(reservacion);
                return CreatedAtAction(nameof(CrearReservacion), new { id = reservacionCreada.Id }, reservacionCreada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarReservacion(int id, Reservacion reservacion)
        {
            if (id != reservacion.Id)
            {
                return BadRequest();
            }

            try
            {
                _reservacionService.ModificarReservacion(reservacion);
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName ==
                    "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, ex.Message);
                }
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReservacion(int id)
        {
            try
            {
                _reservacionService.EliminarReservacion(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerReservacion(int id)
        {
            
            var reservacion = _reservacionService.ObtenerReservacion(id);
                
            if (reservacion == null)
            { 
                return NotFound();
            }
                
            return Ok(reservacion);
            
        } 
    }
}
