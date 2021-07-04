using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEngSoftII.Models;

namespace ProjetoEngSoftII.Data
{
    public class ProjectContext : DbContext
    {
        protected ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().HasKey(p => p.Id);
            modelBuilder.Entity<Paciente>().HasOne(p => p.CarteiraVacinacao);
            //modelBuilder.Entity<Paciente>().HasOne(p => p.Endereco);

            //modelBuilder.Entity<Endereco>().HasKey(end => new { end.Cep, end.Numero });

            modelBuilder.Entity<CarteiraVacinacao>().HasKey(cv => cv.Id);

            modelBuilder.Entity<Vacina>().HasKey(v => v.Id);
        }

        public DbSet<ProjetoEngSoftII.Models.Paciente> Paciente { get; set; }
    }
}
