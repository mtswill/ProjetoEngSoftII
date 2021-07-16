using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Helpers;
using ProjetoEngSoftII.Models.Pdf;
using System;
using ProjetoEngSoftII.Models.Vacinas;

namespace ProjetoEngSoftII.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var teste = new PdfCreator();
            var vacinado = new VacinadoPdfModel
            {
                Cpf = "462.604.568-59",
                Nome = "Matheus Willian Polato",
                DataVacinacao = DateTime.Now,
                DataRetorno = DateTime.Now,
                Dose = Doses.PrimeiraDose.ToString(),
                MarcaVacina = "teste"
            };

            //teste.CreatePdf(vacinado);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
