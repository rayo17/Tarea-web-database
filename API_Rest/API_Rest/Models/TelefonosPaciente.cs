using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class TelefonosPaciente
{
    [Key]
    public int Cedula_Paci { get; set; }
    public List<TelefonosPaciente> Numero { get; set; }
}