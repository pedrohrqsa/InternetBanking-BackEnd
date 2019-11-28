using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class SaqueController : Controller
    {
        private readonly ISaqueRepositorio _saqueRepositorio;
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public SaqueController(ISaqueRepositorio saqueRepositorio)
        {
            _saqueRepositorio = saqueRepositorio;
        }

        [HttpGet]
        public IEnumerable<Saque> GetAll()
        {
            return _saqueRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetSaque")]
        public IActionResult GetById(int idSaque)
        {
            var saque = _saqueRepositorio.FindBySaque(idSaque);

            if (saque == null) return NotFound();
            
            return new ObjectResult(saque);
        }
    }
}