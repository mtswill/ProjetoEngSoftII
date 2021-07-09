using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoEngSoftII.Models.Enderecos;

namespace ProjetoEngSoftII.Models
{
    public class Pessoa : BaseEntity
    {
        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("data_nascimento")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("cpf")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Column("rg")]
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
