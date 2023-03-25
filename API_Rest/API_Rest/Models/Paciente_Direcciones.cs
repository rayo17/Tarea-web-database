using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models
{
    public class Paciente_Direcciones
    {
        [ForeignKey("Paciente")]
        public string Paciente { get; set; }
        public string Ubicacion { get; set; }
    }
}