using Npgsql;
using ProjetoEngSoftII.Data;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Repositories.PacienteRespository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ProjectContext _context;

        public PacienteRepository(ProjectContext context)
        {
            _context = context;
        }
        public Paciente FindByCpf(string cpf)
        {
            var paciente = _context.Paciente.SingleOrDefault(p => p.Cpf.Equals(cpf));
            return GetEndereco(paciente);
        }

        public List<Paciente> FindAll()
            => _context.Paciente.ToList();

        public Paciente Create(Paciente paciente)
        {
            try
            {
                _context.Paciente.Add(paciente);
                _context.SaveChanges();
                return paciente;
            }
            catch (PostgresException ex)
            {
                throw;
            }
        }

        public Paciente Update(Paciente paciente)
        {
            var result = _context.Paciente.SingleOrDefault(p => p.Cpf.Equals(paciente.Cpf));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(paciente);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(string cpf)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string cpf)
            => _context.Paciente.Any(p => p.Cpf.Equals(cpf));

        private Paciente GetEndereco(Paciente paciente)
        {
            if (!paciente.Equals(null))
            {
                var endereco = _context.Endereco.SingleOrDefault(e => e.Id.Equals(paciente.EnderecoId));
                if (!endereco.Equals(null))
                    paciente.Endereco = endereco;
            }

            return paciente;
        }
    }
}
