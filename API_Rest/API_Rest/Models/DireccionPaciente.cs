using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class DireccionPaciente
{
    [Key]
    public int CedulaPaciente { get; set; }
    public string Descripcion { get; set; }
}