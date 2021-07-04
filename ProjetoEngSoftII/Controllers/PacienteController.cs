using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoEngSoftII.Data;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Repositories;

namespace ProjetoEngSoftII.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ILogger<PacienteController> _logger;
        private readonly IRepository<Paciente> _repository;

        public PacienteController(ILogger<PacienteController> logger, IRepository<Paciente> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.FindAll().ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }
    }
}
