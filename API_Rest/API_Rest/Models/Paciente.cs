namespace API_Rest.Models;

public class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public int Cedula { get; set; }
    public List<string> Telefonos { get; set; }
    public List<string> Direcciones { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public List<Patologia> Patologias { get; set; }
    public List<HistorialClinico> HistorialClinico { get; set; }  // propiedad de navegación

}

public class Patologia
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Tratamiento { get; set; }
}