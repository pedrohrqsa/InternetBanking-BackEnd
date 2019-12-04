using System.Collections.Generic;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class TransferenciaController : Controller
    {
        private readonly ITransferenciaRepositorio _transferenciaRepositorio;
        
        public TransferenciaController(ITransferenciaRepositorio ContaRepositorio){
            _transferenciaRepositorio = ContaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Transferencia> GetAll()
        {
            return _transferenciaRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transferencia transferencia){
            if (transferencia == null) return BadRequest();
            
            _transferenciaRepositorio.AddTransferencia(transferencia);
            return new ObjectResult(_transferenciaRepositorio.FindByID(transferencia.idTransferencia));
        }
    }
}