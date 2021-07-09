using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Models.Vacinas;

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
            modelBuilder.Entity<Paciente>().HasKey(p => p.Cpf);
            modelBuilder.Entity<Paciente>().HasOne(p => p.Endereco).WithOne();
            
            modelBuilder.Entity<Endereco>().HasKey(end => end.Id);

            modelBuilder.Entity<CarteiraVacinacao>().HasKey(cv => cv.Id);
            modelBuilder.Entity<CarteiraVacinacao>().HasOne(cv => cv.Paciente);

            modelBuilder.Entity<Vacina>().HasKey(v => v.Id);

            modelBuilder.Entity<MarcaVacinaCovid>().HasKey(mv => mv.Id);

            modelBuilder.Entity<Vacinado>().HasKey(v => v.Id);
            modelBuilder.Entity<Vacinado>().HasOne(v => v.MarcaVacinaCovid).WithOne();
            modelBuilder.Entity<Vacinado>().HasOne(v => v.Paciente).WithOne();
        }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<MarcaVacinaCovid> MarcaVacinaCovid { get; set; }
        public DbSet<Vacinado> Vacinado { get; set; }
    }
}
