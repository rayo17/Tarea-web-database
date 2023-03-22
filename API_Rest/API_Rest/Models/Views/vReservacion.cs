using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_Rest.Models.Views;

public class vReservacion
{
    [Key]
    public int Id_proc { get; set; }
    public DateTime Fecha { get; set; }
    public int Cedula { get; set; }
}