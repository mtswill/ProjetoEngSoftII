using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Controllers.Vacina
{
    public class VacinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CovidIndex()
        {
            return View("../Views/Vacina/Covid/CovidIndex.cshtml");
        }
    }
}
