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
        public ContaController(IContaRepositorio ContaRepositorio){
            _contaRepositorio = ContaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Conta> GetAll()
        {
            return _contaRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Conta conta){
            if (conta == null) return BadRequest();
            
            _contaRepositorio.AddConta(conta);
            return new ObjectResult(_contaRepositorio.FindByConta(conta.idCliente));
        }
    }
}