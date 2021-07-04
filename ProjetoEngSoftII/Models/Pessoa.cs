using ProjetoEngSoftII.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

        [Column("endereco")]
        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
    }
}
