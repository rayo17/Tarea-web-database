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
        public DbSet<Cama> Camas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define las restricciones de clave foránea
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.HistorialClinico)
                .WithOne(h => h.Paciente)
                .HasForeignKey(h => h.Id);

            modelBuilder.Entity<Reservacion>()
                .HasOne(r => r.Cama)
                .WithMany(c => c.Reservaciones)
                .HasForeignKey(r => r.CamaId);
            
            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Cama)
                .WithOne(c => c.Paciente)
                .HasForeignKey<Cama>(c => c.PacienteId);

            modelBuilder.Entity<Cama>()
                .HasOne(c => c.Paciente)
                .WithOne(p => p.Cama)
                .HasForeignKey<Paciente>(p => p.CamaId);
        }
    }
}