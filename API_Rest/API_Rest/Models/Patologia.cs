using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models;

/*
     * Representa la relación que tiene in paciente con
     * sus propias patologias. Cada una de ellas tiene
     * un tratamiento propio dependiendo del paciente.
     * El Paciente o los Doctores, al dar de alta el nuevo
     * Paciente, ingresan sus patologias propias.
     */
public class Patologia
{
    public Patologia()
    {
    }

    [Key]
    public int paciente { get; set; }
    public string nombre { get; set; }
    public string tratamiento { get; set; } 
}