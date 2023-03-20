using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Rest.Models;
namespace API_Rest.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                string connectionString = configuration.GetConnectionString("HospitalDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasKey(p => p.Cedula);
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Telefonos)
                .WithOne()
                .HasForeignKey(t => t)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Direcciones)
                .WithOne()
                .HasForeignKey(d => d)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<HistorialClinico> HistorialClinicos { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }
        
        
        public async Task<int> SaveChangesHistorialClinico()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is HistorialClinico && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((HistorialClinico)entry.Entity).UltimaModificacion = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    ((HistorialClinico)entry.Entity).FechaCreacion = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
        
    }
}