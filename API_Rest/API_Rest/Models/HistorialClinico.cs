using System;

namespace API_Rest.Models
{
    public class HistorialClinico
    {
        public int Id { get; set; }
        public string? Procedimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string? Tratamiento { get; set; }
        public string? CedulaPaciente { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}