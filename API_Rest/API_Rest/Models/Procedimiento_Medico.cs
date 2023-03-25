using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest.Models;
public class Procedimiento_Medico
{
    public Procedimiento_Medico()
    {
    }
    [Key]
    public string nombre { get; set; }

    
}
