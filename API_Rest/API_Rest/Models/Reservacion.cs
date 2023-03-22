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
    public int IdReservacion { get; set; }
    public DateTime Fechaingreso { get; set; }
    public DateTime Fechasalida { get; set; }
    public int Idpaciente { get; set; }
    public int Idcama { get; set; }
    public string Nombre { get; set; }
}