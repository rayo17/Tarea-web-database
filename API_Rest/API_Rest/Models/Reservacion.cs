namespace API_Rest.Models;

public class Reservacion
{
    public int Id { get; set; }
    public int PacienteId { get; set; } // Identificador del paciente asociado a la reservación
    public DateTime FechaIngreso { get; set; }
    public List<Procedimiento> Procedimientos { get; set; }
    public DateTime FechaSalida { get { return FechaIngreso.AddDays(Procedimientos.Sum(p => p.DiasRequeridos)); } }
}

public class Procedimiento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int DiasRequeridos { get; set; }
    public string Tratamiento { get; set; }
}