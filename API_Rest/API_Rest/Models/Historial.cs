using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models
{
    public class Historial
    {
        [Key]
        public int Id { get; set; }
        public string Procedimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Tratamiento { get; set; }
    }
}