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
using ProjetoEngSoftII.Repositories.PacienteRespository;

namespace ProjetoEngSoftII.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ILogger<PacienteController> _logger;
        private readonly PacienteRepository _repository;

        public PacienteController(ILogger<PacienteController> logger, PacienteRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        #region Views

        public IActionResult Index()
            => View(_repository.FindAll().ToList());
        
        public IActionResult Create()
            => View();
        
        public IActionResult Edit(string cpf)
        {
            if (cpf.Equals(null))
                return RedirectToAction(nameof(ErrorViewModel), new { message = "ID não especificado" });

            var paciente = _repository.FindByCpf(cpf);

            if (paciente.Equals(null))
                return RedirectToAction(nameof(ErrorViewModel), new { message = "ID não encontrado" });

            return View(paciente);
        }

        #endregion Views

        #region Cadastros

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(paciente);
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return RedirectToAction(nameof(ErrorViewModel), new { message = "ID não corresponde" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(paciente);
                }
                catch (Exception ex)
                {
                    if (!ExistePaciente(paciente.Cpf))
                    {
                        return RedirectToAction(nameof(ErrorViewModel), new { message = ex.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }

        #endregion Cadastros

        #region Funções
        
        public bool ExistePaciente(string cpf)
            => _repository.Exists(cpf);
        
        #endregion Funções
    }
}
