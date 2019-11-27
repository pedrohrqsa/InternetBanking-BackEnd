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
        public TransacaoController(ITransacaoRepositorio ContaRepositorio){
            _transacaoRepositorio = ContaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Transacao> GetAll()
        {
            return _transacaoRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transacao transacao){
            if (transacao == null) return BadRequest();
            
            _transacaoRepositorio.AddTransacao(transacao);
            return new ObjectResult(_transacaoRepositorio.FindByID(transacao.idTransacao));
        }
    }
}