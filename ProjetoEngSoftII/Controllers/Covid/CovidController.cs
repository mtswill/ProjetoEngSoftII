using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Controllers.Covid
{
    public class CovidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VacinacaoIndex()
        {
            return View();
        }

        public IActionResult InserirVacinadoView()
        {
            return View();
        }

        public IActionResult LeitosIndex()
        {
            return View();
        }
    }
}
