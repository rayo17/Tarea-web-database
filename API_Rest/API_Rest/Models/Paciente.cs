using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class Paciente
{
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Apellidos { get; set; }
    [Key]
    [Required]
    public string Cedula { get; set; }
    public List<String> Telefonos { get; set; }
    public List<String> Direcciones { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public List<Patologia> Patologias { get; set; }

}

