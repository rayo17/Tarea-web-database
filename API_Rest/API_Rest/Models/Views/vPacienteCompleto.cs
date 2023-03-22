using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models.Views;

public class vPacienteCompleto
{
    [Key]
    public int cedula { get; set; }
    public string nombre { get; set; }
    public List<TelefonosPaciente> telefono { get; set; }
    public List<DireccionPaciente> direcciones { get; set; }
    public List<Paciente_Patologia> patologia { get; set; }
    //public string tratamiento { get; set; }
}