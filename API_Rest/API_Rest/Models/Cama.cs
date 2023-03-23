using Microsoft.EntityFrameworkCore;

namespace API_Rest.Models;

[Keyless]
public class Cama
{
    public int Cantidad { get; set; }
}