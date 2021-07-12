using Npgsql;
using ProjetoEngSoftII.Data;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Models.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return AddEnderecoAoPaciente(paciente);
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
            catch
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
                    _ = UpdateEndereco(paciente.Endereco);

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

        public Endereco GetEnderecoById(long id)
            => _context.Endereco.SingleOrDefault(e => e.Id.Equals(id));

        public Endereco UpdateEndereco(Endereco endereco)
        {
            var result = _context.Endereco.SingleOrDefault(e => e.Id.Equals(endereco.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(endereco);
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
        public bool ExistsEndereco(long id)
            => _context.Endereco.Any(e => e.Id.Equals(id));

        private Paciente AddEnderecoAoPaciente(Paciente paciente)
        {
            if (!paciente.Equals(null))
            {
                var endereco = _context.Endereco.SingleOrDefault(e => e.Id.Equals(paciente.EnderecoId));
                if (!endereco.Equals(null))
                {
                    paciente.Endereco = endereco;
                    paciente.EnderecoId = endereco.Id;
                }
            }

            return paciente;
        }
    }
}
