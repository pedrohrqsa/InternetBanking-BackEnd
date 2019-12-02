using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class DepositoController : Controller
    {
        private readonly IDepositoRepositorio _depositoRepositorio;
        // private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public DepositoController(IDepositoRepositorio depositoRepositorio)
        {
            _depositoRepositorio = depositoRepositorio;
        }

        [HttpGet]
        public IEnumerable<Deposito> GetAll()
        {
            return _depositoRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetDeposito")]
        public IActionResult GetById(int idDeposito)
        {
            var deposito = _depositoRepositorio.FindByDeposito(idDeposito);

            if (deposito == null) return NotFound();
            
            return new ObjectResult(deposito);
        }
    }
}