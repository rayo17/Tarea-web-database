using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models;
public class Procedimiento_Medico
{
    public Procedimiento_Medico()
    {
    }
    [ForeignKey("Paciente")] 
    
    public int paciente { get; set; }
    public string nombre { get; set; }
    public DateTime Fecha { get; set; }

    
}
