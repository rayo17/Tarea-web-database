using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
public class vPaciente_Patologia
{
    public vPaciente_Patologia()
    {
    }

    [Key]
    public int idpaciente_patologia { get; set; }
    public int idpaciente { get; set; }
    public string patologia { get; set; }
    public int idpatologia { get; set; }
    public string tratamiento { get; set; }
}