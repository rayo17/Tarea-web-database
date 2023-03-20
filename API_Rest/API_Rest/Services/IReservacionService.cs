using API_Rest.Models;
using System;
using System.Collections.Generic;

namespace API_Rest.Services.Interfaces
{
    public interface IReservacionService
    {
        Task CrearReservacion(Reservacion reservacion);
        Task ModificarReservacion(Reservacion reservacion);
        Task EliminarReservacion(int id);
        Task<Reservacion> ObtenerReservacion(int id);
        Task<IEnumerable<Reservacion>> ObtenerTodasLasReservaciones();
        Task<IEnumerable<Reservacion>> ObtenerReservacionesPorPaciente(Paciente paciente);
        Task<DateTime> CalcularFechaDeSalida(Reservacion reservacion);
    }
}