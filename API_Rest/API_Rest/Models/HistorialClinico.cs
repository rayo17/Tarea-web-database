using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace API_Rest.Models
{
    public class HistorialClinico
    {
        public HistorialClinico()
        {
        }
        [Key]
        public int Cedula { get; set; }
        public int Id_proc { get; set; }

        public DateTime Fecha { get; set; }
        public string Nombre_proc { get; set; }
    }
}