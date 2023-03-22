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

        /*protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            modelBuilder.Entity<Direcciones_paciente>()
                .hasKey(p => new {p.Paciente, p.Direccion});
        }*/

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Historial> Historial { get; set; }
        //public DbSet<Direcciones_paciente> Direcciones_paciente { get; set; }
    }
}