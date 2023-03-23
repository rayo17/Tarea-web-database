using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models
{
    public class Historial
    {
        [Key] [ForeignKey("Id")]
        public int Id { get; set; }
        [ForeignKey("Procedimiento")]
        public string Procedimiento { get; set; }
        [ForeignKey("Fecha")]
        public DateTime Fecha { get; set; }
        [ForeignKey("Tratamiento")]
        public string Tratamiento { get; set; }
    }
}