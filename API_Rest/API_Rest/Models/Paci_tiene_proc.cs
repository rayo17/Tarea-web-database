using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class Paci_tiene_proc
{
    public Paci_tiene_proc()
    {
    }

    [Key]
    public int Cedula { get; set; }
    public string Id_proc { get; set; }
    public DateTime Fecha { get; set; }
}