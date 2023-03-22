using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace API_Rest.Models.Views;

public class vReservGNombre
{
    [Key]
    public string Nombre { get; set; }

}