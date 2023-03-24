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
        public DateTime Fecha { get; set; }
<<<<<<< HEAD
        [ForeignKey("Procedimiento")] 
        public string Procedimiento { get; set; }
=======
        [ForeignKey("Id_Procedimiento")]
        public int Id_Procedimiento { get; set; }
>>>>>>> f0d9ab4bf738420012ed32835258db7ba5e3e389
    }
}