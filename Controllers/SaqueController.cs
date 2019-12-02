using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;
using System;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class SaqueController : Controller
    {
        private readonly ISaqueRepositorio _saqueRepositorio;
        // private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public SaqueController(ISaqueRepositorio saqueRepositorio)
        {
            _saqueRepositorio = saqueRepositorio;
        }

        [HttpGet]
        public IEnumerable<Saque> GetAll()
        {
            var x = _saqueRepositorio.GetAll();
            return x;
        }

        [HttpGet("{id}", Name = "GetSaque")]
        public IActionResult GetById(int idSaque)
        {
            var y = _saqueRepositorio.validaSaque(12, 5000);
            
            return new ObjectResult(y);
        }
    }
}