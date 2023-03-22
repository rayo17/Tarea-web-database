using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
public class vHistorialClinico 
{
    public vHistorialClinico()
    {

    }
    [Key]
    public int Cedula { get; set; }
    public int Id { get; set; }

    public DateTime Fecha { get; set; }
    public string Nombre_proc { get; set; }
}