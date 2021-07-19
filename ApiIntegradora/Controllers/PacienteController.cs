using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Repositories.PacienteRespository;

namespace ApiIntegradora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ILogger<PacienteController> _logger;
        private readonly PacienteRepository _pacienteRepository;

        public PacienteController(ILogger<PacienteController> logger, PacienteRepository pacienteRepository)
        {
            _logger = logger;
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet("{cpf}")]
        public IActionResult Get(string cpf)
        {
            //if (string.IsNullOrWhiteSpace(cpf))
            //    return BadRequest();

            //var paciente = _pacienteRepository.FindByCpf(cpf);

            //if (paciente == null)
            //    return NotFound();

            //return Ok(paciente);
            return StatusCode(501);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Paciente paciente)
        {
            //if (paciente == null)
            //    return BadRequest();

            //return Ok(_pacienteRepository.Create(paciente));
            return StatusCode(501);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Paciente paciente)
        {
            //if (paciente == null)
            //    return BadRequest();

            //return Ok(_pacienteRepository.Update(paciente));
            return StatusCode(501);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return StatusCode(501);
        }
    }
}
