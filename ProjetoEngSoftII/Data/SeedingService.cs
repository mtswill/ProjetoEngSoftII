using ProjetoEngSoftII.Models.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Data
{
    public class SeedingService
    {
        private readonly ProjectContext _context;

        public SeedingService(ProjectContext context)
        {
            _context = context;
        }

        internal void Seed()
        {
            #region Verificações
            
            if (_context.MarcaVacinaCovid.Any())
            {
                return;
            }

            #endregion Verificações

            #region Preenche marcas vacina

            var pfizer = new MarcaVacinaCovid
            {
                Marca = "Pfizer-BioNTech",
                Tipo = "mRNA"
            };

            var moderna = new MarcaVacinaCovid
            {
                Marca = "Moderna",
                Tipo = "mRNA"
            };

            var sputnik = new MarcaVacinaCovid
            {
                Marca = "Sputnik V",
                Tipo = "Adenovírus"
            };

            var oxford = new MarcaVacinaCovid
            {
                Marca = "Oxford-AstraZeneca",
                Tipo = "Adenovírus"
            };

            var covishield = new MarcaVacinaCovid
            {
                Marca = "Covidshield",
                Tipo = "Adenovírus"
            };

            var janssen = new MarcaVacinaCovid
            {
                Marca = "Janssen",
                Tipo = "Adenovírus"
            };

            var cansino = new MarcaVacinaCovid
            {
                Marca = "Cansino",
                Tipo = "Adenovírus"
            };

            _context.MarcaVacinaCovid.AddRange(pfizer, moderna, sputnik, oxford, covishield, janssen, cansino);

            #endregion Preenche marcas vacina

            _context.SaveChanges();
        }
    }
}
