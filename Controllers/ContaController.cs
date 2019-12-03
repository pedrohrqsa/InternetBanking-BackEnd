using System.Collections.Generic;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ContaController : Controller
    {
        private readonly IContaRepositorio _contaRepositorio;

        public ContaController(IContaRepositorio ContaRepositorio)
        {
            _contaRepositorio = ContaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Conta> GetAll()
        {
            return _contaRepositorio.GetAll();
        }

        
        [HttpGet("{conta}", Name = "GetConta")]
        public IActionResult GetByCont(int id)
        {
            var conta = _contaRepositorio.FindByConta(id);

            if (conta == null) return NotFound();
            return new ObjectResult(conta);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Conta conta)
        {
            if (conta == null) return BadRequest();
            
            _contaRepositorio.AddConta(conta);
            return new ObjectResult(new ContaCorrente());
        }
    }
}