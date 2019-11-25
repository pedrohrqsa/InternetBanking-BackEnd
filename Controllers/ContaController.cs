using System.Collections.Generic;
using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ContaController : Controller
    {
        private readonly IContaRepositorio _contaRepositorio;

        public ContaController(IContaRepositorio contaRepo){
            _contaRepositorio = contaRepo;
        }

         [HttpGet]
        public IEnumerable<Conta> GetAll()
        {
            return _contaRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetConta")]
        public IActionResult GetByID(int id)
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

            return new ObjectResult(new ClienteLogin());
        }
        
    }
}