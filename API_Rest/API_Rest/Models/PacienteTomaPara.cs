namespace API_Rest.Models;

public class PacienteTomaPara
{
    public int Id { get; set; }
    public int Cedula_paci { get; set; }
    public int Id_trat { get; set; }
    public int Id_pat { get; set; }
    public string Comentarios_Indicaciones { get; set; }
}