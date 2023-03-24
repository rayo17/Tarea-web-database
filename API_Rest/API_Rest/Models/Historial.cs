using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models
{
    public class Historial
    {
        [Key] [ForeignKey("Paciente")]
        public string Paciente { get; set; }
        [ForeignKey("Procedimiento")]
        public string Procedimiento { get; set; }
        [ForeignKey("Fecha")]
        public DateTime Fecha { get; set; }
        
        public string Tratamiento { get; set; }
    }
}