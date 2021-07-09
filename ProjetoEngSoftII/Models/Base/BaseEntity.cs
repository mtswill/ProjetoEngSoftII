using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models
{
    public class BaseEntity
    {
        [ForeignKey("id")]
        public long Id { get; set; }
    }
}
