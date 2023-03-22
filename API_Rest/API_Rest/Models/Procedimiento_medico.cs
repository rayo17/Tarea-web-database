using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class Procedimiento_medico
{
    public Procedimiento_medico()
    {
    }

    [Key]
    public int Id { get; set; }
    public string Nombre_proc { get; set; }
    public int Dias_minimos { get; set; }
}