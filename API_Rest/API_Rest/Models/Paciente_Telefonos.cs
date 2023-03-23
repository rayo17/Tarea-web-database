using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models
{
    public class Paciente_Telefonos
    {
        [ForeignKey("Paciente")]
        public string Paciente { get; set; }
        public int Telefono { get; set; }
    }
}