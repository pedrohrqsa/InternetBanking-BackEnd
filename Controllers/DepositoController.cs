using System.Collections.Generic;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class DepositoController : Controller
    {
        private readonly IDepositoRepositorio _depositoRepositorio;
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public DepositoController(IDepositoRepositorio depositoRepositorio, IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _depositoRepositorio = depositoRepositorio;
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        [HttpGet]
        public IEnumerable<Deposito> GetAll()
        {
            return _depositoRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Deposito deposito)
        {
            if (deposito == null) return BadRequest();

            _contaCorrenteRepositorio.Deposito(deposito.valor);

            _depositoRepositorio.AddDeposito(deposito);
            return new ObjectResult(_depositoRepositorio.FindByID(deposito.idDeposito));
        }
    }
}