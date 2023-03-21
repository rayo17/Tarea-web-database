using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class Paciente
{
    public Paciente()
    {
    }
    
    [Key]
    public int Cedula { get; set; }
    public string Nombre { get; set; }
    public string Primer_apellido { get; set; }
    public string Segundo_apellido { get; set; }
    public DateTime Fecha_nacimiento { get; set; }
}

