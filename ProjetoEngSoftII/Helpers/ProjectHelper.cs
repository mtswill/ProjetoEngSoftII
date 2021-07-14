using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Helpers
{
    public static class ProjectHelper
    {
        public static string RemovePontoEHifem(this string obj)
            => obj.Replace(".", string.Empty).Replace("-", string.Empty);
    }
}
