using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models
{
    public class Historial
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
    }
}