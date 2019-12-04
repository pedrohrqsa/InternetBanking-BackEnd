using System.Collections.Generic;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class TransacaoController : Controller
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;
        
        public TransacaoController(ITransacaoRepositorio ContaRepositorio)
        {
            _transacaoRepositorio = ContaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Transacao> GetAll()
        {
            return _transacaoRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transacao deposito)
        {
            if (deposito == null) return BadRequest();
            
            _transacaoRepositorio.Deposito(deposito);
            return new ObjectResult(_transacaoRepositorio.FindByID(deposito.idTransacao));
        }
    }
}