using Microsoft.AspNetCore.Mvc;
using ProjetoEngSoftII.Repositories.CovidRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Controllers.Covid
{
    public class CovidController : Controller
    {
        private readonly CovidRepository _repository;

        public CovidController(CovidRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VacinacaoIndex()
        {
            return View();
        }

        public IActionResult InserirVacinado()
        {
            return View();
        }

        public IActionResult LeitosIndex()
        {
            return View();
        }
    }
}
