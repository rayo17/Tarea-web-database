using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Rest.Models;
using API_Rest.Models.Views;
namespace API_Rest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
        
        //Tables
        public DbSet<Paciente> paciente { get; set; }
        public DbSet<Paciente_Patologia> paciente_patologia { get; set; }
        public DbSet<DireccionPaciente> DireccionPaciente { get; set; }

        //Views
 
        public DbSet<vPaciente> vpaciente { get; set; }
        public DbSet<vPaciente_Patologia> vpaciente_patologia { get; set; }
        
        public DbSet<vReservacion> vReservacion { get; set; }
        public DbSet<Reservacion> Reservacion { get; set; }

    }
}