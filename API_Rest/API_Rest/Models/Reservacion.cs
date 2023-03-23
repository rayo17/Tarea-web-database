using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models
{
    public class Reservacion
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Paciente")] 
        public string Paciente { get; set; }
        [ForeignKey("Fecha")]
        public DateTime Fecha { get; set; }
        [ForeignKey("Procedimiento")]
        public string Procedimiento { get; set; }
    }
}