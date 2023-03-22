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
    public int IdReservacion { get; set; }
    public DateTime Fechaingreso { get; set; }
    public DateTime Fechasalida { get; set; }
    public int Idpaciente { get; set; }
    public int Idcama { get; set; }
}