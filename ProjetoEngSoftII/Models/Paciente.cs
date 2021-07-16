﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models
{
    [Table("paciente")]
    public class Paciente : Pessoa
    {
        [Display(Name = "CNS")]
        public string Cns { get; set; }
    }
}
