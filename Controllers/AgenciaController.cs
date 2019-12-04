using System.Collections.Generic;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class AgenciaController : Controller
    {
        private readonly IAgenciaRepositorio _agenciaRepositorio;

        public AgenciaController(IAgenciaRepositorio AgenciaRepositorio)
        {
            _agenciaRepositorio = AgenciaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Agencia> GetAll()
        {
            return _agenciaRepositorio.GetAll();
        }

        
        [HttpGet("{agencia}", Name = "GetAgencia")]
        public IActionResult GetByCont(int id)
        {
            var agencia = _agenciaRepositorio.FindByAgencia(id);

            if (agencia == null) return NotFound();
            return new ObjectResult(agencia);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Agencia agencia)
        {
            if (agencia == null) return BadRequest();
            
            _agenciaRepositorio.AddAgencia(agencia);
            return new ObjectResult(new Agencia());
        }
    }
}