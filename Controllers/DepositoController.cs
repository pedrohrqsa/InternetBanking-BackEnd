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
        public DepositoController(IDepositoRepositorio ContaRepositorio){
            _depositoRepositorio = ContaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Deposito> GetAll()
        {
            return _depositoRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Deposito deposito){
            if (deposito == null) return BadRequest();
            
            _depositoRepositorio.AddDeposito(deposito);
            return new ObjectResult(_depositoRepositorio.FindByID(deposito.idDeposito));
        }
    }
}