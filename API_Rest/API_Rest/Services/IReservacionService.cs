using API_Rest.Models;
using System;
using System.Collections.Generic;

namespace API_Rest.Services.Interfaces
{
    public interface IReservacionService
    {
        Reservacion CrearReservacion(Reservacion reservacion);
        Reservacion ModificarReservacion(Reservacion reservacion);
        bool EliminarReservacion(int id);
        Reservacion ObtenerReservacion(int id);
        IEnumerable<Reservacion> ObtenerTodasLasReservaciones();
        IEnumerable<Reservacion> ObtenerReservacionesPorPaciente(Paciente paciente);
        DateTime CalcularFechaDeSalida(Reservacion reservacion);
    }
}