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
        [ForeignKey("Id_Procedimiento")]
<<<<<<< HEAD
        public string Id_Procedimiento { get; set; }
=======
        public int Id_Procedimiento { get; set; }
>>>>>>> ff6b413adbc56db45a10e7c48f977836a33b8daf
    }
}