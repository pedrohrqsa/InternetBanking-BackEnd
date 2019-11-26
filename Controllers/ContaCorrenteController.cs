using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ContaCorrenteController : Controller
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        public ContaCorrenteController(IContaCorrenteRepositorio contaCorrenteRepositorio){
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        [HttpGet]
        public IEnumerable<ContaCorrente> GetAll()
        {
            return _contaCorrenteRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContaCorrente contaCorrente){
            if (contaCorrente == null) return BadRequest();
            _contaCorrenteRepositorio.AddContaCorrente(contaCorrente);
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrente(contaCorrente.idContaCorrente));
        }
    }
}