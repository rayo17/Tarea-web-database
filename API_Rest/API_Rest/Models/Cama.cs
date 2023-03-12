namespace API_Rest.Models;

public class Cama
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public bool Disponible { get; set; }
    public int HospitalId { get; set; }
}