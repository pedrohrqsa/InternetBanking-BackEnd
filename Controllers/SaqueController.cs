using System.Collections.Generic;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class SaqueController : Controller
    {
        private readonly ISaqueRepositorio _saqueRepositorio;
        
        public SaqueController(ISaqueRepositorio ContaRepositorio){
            _saqueRepositorio = ContaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Saque> GetAll()
        {
            return _saqueRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Saque saque){
            if (saque == null) return BadRequest();
            
            _saqueRepositorio.AddSaque(saque);
            return new ObjectResult(_saqueRepositorio.FindByID(saque.idSaque));
        }
    }
}