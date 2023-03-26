using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models
{
    public class Paciente_Usuario
    {
        [Key] [ForeignKey("Paciente")]
        public string Paciente { get; set; }
        public string Password { get; set; }
    }
}