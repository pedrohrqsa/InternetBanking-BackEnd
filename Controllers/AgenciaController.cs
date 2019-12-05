using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace InternetBanking.Controllers
{
    // [Authorize()]
    [Route("api/[Controller]")]
    public class AgenciaController : Controller
    {
        private readonly IAgenciaRepositorio _agenciaRepo;
        public AgenciaController(IAgenciaRepositorio agenciaRepo)
        {
            _agenciaRepo = agenciaRepo;
        }
        [HttpGet]
        public IEnumerable<Agencia> GetAll()
        {
            return _agenciaRepo.GetAll();
        }
        [HttpGet("{agencia}", Name = "GetAgencia")]
        public IActionResult GetByAgencia(int numeroAgencia)
        {
            var agencia = _agenciaRepo.FindByAgencia(numeroAgencia);

            if (agencia == null) return NotFound();
            return new ObjectResult(agencia);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Agencia agencia)
        {
            if (agencia == null) return BadRequest();

            _agenciaRepo.AddAgencia(agencia);
            return new ObjectResult(_agenciaRepo.FindByAgencia(agencia.idAgencia));
        }
    }
}