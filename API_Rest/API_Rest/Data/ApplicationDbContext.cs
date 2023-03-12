using Microsoft.EntityFrameworkCore;
using API_Rest.Models;

namespace API_Rest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<HistorialClinico> HistorialClinicos { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define las restricciones de clave foránea
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.HistorialClinico)
                .WithOne(h => h.Paciente)
                .HasForeignKey(h => h.Id);
        }
    }
}