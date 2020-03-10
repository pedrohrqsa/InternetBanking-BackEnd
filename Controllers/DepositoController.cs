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
        private readonly IContaRepositorio _contaRepositorio;

        public DepositoController(IDepositoRepositorio depositoRepositorio,
         IContaRepositorio contaRepositorio)
        {
            _depositoRepositorio = depositoRepositorio;
            _contaRepositorio = contaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Deposito> GetAll()
        {
            return _depositoRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transacao deposito)
        {
            if (deposito == null) return BadRequest();

            _depositoRepositorio.AddDeposito(deposito);
            return new ObjectResult(_depositoRepositorio.FindByID(deposito.idTransacao));
        }
    }
}