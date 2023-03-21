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
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int Idprocedimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Tratamiento { get; set; }
    }
}