using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models.Views;

public class vPacienteCompleto
{
    [Key]
    public int cedula { get; set; }
    public string nombre { get; set; }
    public string telefono { get; set; }
    public string direccion { get; set; }
    public string patologia { get; set; }
    //public string tratamiento { get; set; }
}