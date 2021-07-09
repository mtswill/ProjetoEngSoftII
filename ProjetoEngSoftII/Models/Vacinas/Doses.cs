using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.Vacinas
{
    public static class Doses
    {
        public const string PrimeiraDose = "1ª dose";
        public const string SegundaDose = "2ª dose";

        public static List<string> GetDoses()
        {
            return new List<string>
            {
                PrimeiraDose,
                SegundaDose
            };
        }
    }
}
