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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente_Direcciones>()
                .HasKey(p => new {p.Paciente, p.Ubicacion});
            modelBuilder.Entity<Paciente_Telefonos>()
                .HasKey(p => new {p.Paciente, p.Telefono});
        }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Paciente_Direcciones> Paciente_Direcciones { get; set; }
        public DbSet<Paciente_Telefonos> Paciente_Telefonos { get; set; }
        public DbSet<Historial> Historial { get; set; }
        public DbSet<Reservacion> Reservacion { get; set; }
        public DbSet<Patologia> Patologia { get; set; }
        public DbSet<Cama> Cama { get; set; }
        //public DbSet<Direcciones_paciente> Direcciones_paciente { get; set; }
    }
}