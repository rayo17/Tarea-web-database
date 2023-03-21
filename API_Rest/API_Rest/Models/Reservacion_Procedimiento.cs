using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class Reservacion_Procedimiento
{
    public Reservacion_Procedimiento()
    {
    }

    [Key]
    public int idreservacion_procedimiento { get; set; }
    public int idreservacion { get; set; }
    public int idprocedimiento { get; set; }
}