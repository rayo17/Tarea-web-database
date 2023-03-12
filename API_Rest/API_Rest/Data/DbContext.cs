using Microsoft.EntityFrameworkCore;
using API_Rest.Models;

namespace API_Rest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<HistorialClinico> HistorialClinicos { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.HistorialClinico)
                .WithOne(hc => hc.Paciente)
                .HasForeignKey(hc => hc.Paciente);
        }
    }
}