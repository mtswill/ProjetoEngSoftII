using Microsoft.AspNetCore.Mvc;
using ProjetoEngSoftII.Helpers;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Models.Vacinas;
using ProjetoEngSoftII.Models.ViewModels;
using ProjetoEngSoftII.Repositories.CovidRepository;
using ProjetoEngSoftII.Repositories.PacienteRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Controllers.Covid
{
    public class CovidController : Controller
    {
        private readonly CovidRepository _covidRepository;
        private readonly PacienteRepository _pacienteRepository;

        public CovidController(CovidRepository covidRepository, PacienteRepository pacienteRepository)
        {
            _covidRepository = covidRepository;
            _pacienteRepository = pacienteRepository;
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
            var model = new InserirVacinadoViewModel(_covidRepository.GetAllMarcasVacinaCovid());
            return View(model);
        }
        public IActionResult CadastrarVacinador()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InserirVacinado(Vacinado vacinado)
        {

            if (ModelState.IsValid)
            {
                _covidRepository.InserirVacinado(TrataVacinado(vacinado));
                return RedirectToAction(nameof(Index));
            }

            var model = new InserirVacinadoViewModel(_covidRepository.GetAllMarcasVacinaCovid());
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarVacinador(Vacinador vacinador)
        {
            if (ModelState.IsValid)
            {
                _covidRepository.CadastrarVacinador(vacinador);
                return RedirectToAction(nameof(IndexVacinadores));
            }

            var model = new InserirVacinadoViewModel(_covidRepository.GetAllMarcasVacinaCovid());
            return View(model);
        }

        public IActionResult IndexVacinados()
        {
            var model = _covidRepository.GetAllVacinados();

            foreach (var item in model)
            {
                item.MarcaVacinaCovid = _covidRepository.GetMarcaVacinaCovidById(item.MarcaVacinaCovidId);
                item.Paciente = _pacienteRepository.FindByCpf(item.PacienteCpf);
                item.Vacinador = _covidRepository.GetVacinadorByRegistro(item.VacinadorRegistroProfissional);
            }

            return View(model);
        }
        
        public IActionResult IndexVacinadores()
        {
            var model = _covidRepository.GetAllVacinadores();
            return View(model);
        }

        public IActionResult EditarVacinador(string registroProfissional)
        {
            if (registroProfissional == null)
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Registro profissional não especificado" });

            long.TryParse(registroProfissional, out long registro);
            var vacinador = _covidRepository.GetVacinadorByRegistro(registro);

            if (vacinador == null)
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Registro profissional não encontrado" });

            return View(vacinador);
        }
        
        public IActionResult DeletarVacinador(string registroProfissional)
        {
            if (registroProfissional == null)
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Registro profissional não especificado" });

            long.TryParse(registroProfissional, out long registro);
            var vacinador = _covidRepository.GetVacinadorByRegistro(registro);

            if (vacinador == null)
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Registro profissional não encontrado" });

            return View(vacinador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarVacinador(Vacinador vacinador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _covidRepository.UpdateVacinador(vacinador);
                }
                catch (Exception ex)
                {
                    if (!(_covidRepository.ExisteVacinador(vacinador.RegistroProfissional)))
                    {
                        return RedirectToAction(nameof(ErrorViewModel), new { message = ex.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction(nameof(IndexVacinadores));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarRegistroVacinador(string registroProfissional)
        {
            if (!string.IsNullOrWhiteSpace(registroProfissional))
            {
                try
                {
                    long.TryParse(registroProfissional, out long registro);
                    _covidRepository.RemoverVacinador(registro);
                }
                catch
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(IndexVacinadores));
        }

        public IActionResult LeitosIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetInformacoesPaciente(string cpf)
        {
            cpf = cpf.RemovePontoEHifem();
            var paciente = _pacienteRepository.FindByCpf(cpf);

            if (paciente == null)
                return BadRequest();

            var model = new
            {
                Valid = true,
                Paciente = new
                {
                    Nome = paciente.Nome,
                    Cpf = paciente.Cpf,
                    Rg = paciente.Rg,
                    Cns = paciente.Cns
                }
            };           

            return Ok(model);
        }

        public Vacinado TrataVacinado(Vacinado vacinado)
        {
            vacinado.PacienteCpf = vacinado.PacienteCpf.RemovePontoEHifem();
            return vacinado;
        }
    }
}
