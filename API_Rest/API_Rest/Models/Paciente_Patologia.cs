using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class Paciente_Patologia
{
    public Paciente_Patologia()
    {
    }

    [Key]
    public int Idpaciente { get; set; }
    public int Idpatologia { get; set; }
    public string Tratamiento { get; set; } 
}