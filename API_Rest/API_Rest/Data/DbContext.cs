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
        public DbSet<Cama> Camas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.HistorialClinico)
                .WithOne(hc => hc.Paciente)
                .HasForeignKey(hc => hc.Paciente);

            modelBuilder.Entity<Reservacion>()
                .HasOne(r => r.cama)
                .WithMany(c => c.Reservaciones)
                .HasForeignKey(r => r.CamaId);

            modelBuilder.Entity<Reservacion>()
                .HasOne(r => r.Paciente)
                .WithMany(p => p.Reservaciones)
                .HasForeignKey(r => r.PacienteId);
        }
    }
}