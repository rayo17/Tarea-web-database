using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

public class Reservacion
{
    public Reservacion()
    {
    }

    [Key]
                                           public int Cedula { get; set; }
                                           public string Nombre { get; set; }
                                           public int Id_proc { get; set; }
                                           public DateTime Fecha { get; set; }
    
}