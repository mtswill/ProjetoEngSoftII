using Microsoft.EntityFrameworkCore;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Models.Vacinas;
using ProjetoEngSoftII.Models.Enderecos;

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

            modelBuilder.Entity<MarcaVacinaCovid>().HasKey(mv => mv.Id);

            modelBuilder.Entity<Vacinado>().HasKey(v => v.Id);
            modelBuilder.Entity<Vacinado>().HasOne(v => v.MarcaVacinaCovid).WithOne();
            modelBuilder.Entity<Vacinado>().HasOne(v => v.Paciente).WithOne();
            modelBuilder.Entity<Vacinado>().HasOne(v => v.Vacinador).WithOne();

            modelBuilder.Entity<Vacinador>().HasKey(v => v.RegistroProfissional);
        }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<MarcaVacinaCovid> MarcaVacinaCovid { get; set; }
        public DbSet<Vacinado> Vacinado { get; set; }
        public DbSet<Vacinador> Vacinador { get; set; }
    }
}
