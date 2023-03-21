using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class Procedimiento
{
    public Procedimiento()
    {
    }

    [Key]
    public int Idprocedimiento { get; set; }
    public string Nombre { get; set; }
    public int DiasRecuperacion { get; set; }
}