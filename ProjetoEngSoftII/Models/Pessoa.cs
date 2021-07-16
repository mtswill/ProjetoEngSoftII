using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoEngSoftII.Models.Enderecos;

namespace ProjetoEngSoftII.Models
{
    public class Pessoa : BaseEntity
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "RG")]
        public string Rg { get; set; }

        [ForeignKey("endereco_id")]
        [Display(Name = "Endereço")]
        public long EnderecoId { get; set; }

        //Classes externas
        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
    }
}
