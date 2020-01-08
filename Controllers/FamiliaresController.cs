using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;
namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class FamiliaresController : Controller
    {
        private readonly IFamiliaresRepositorio _FamiliaresRepositorio;
        public FamiliaresController(IFamiliaresRepositorio familiaresRepo)
        {
            _FamiliaresRepositorio = familiaresRepo;
        }

        [HttpGet]
        public IEnumerable<Familiares> GetAll()
        {
            return _FamiliaresRepositorio.GetAll();
        }

        [HttpGet("{fam}", Name = "GetFamiliares")]
        public IActionResult GetByFamiliares(int fam)
        {
            var familiares = _FamiliaresRepositorio.FindByFam(fam);
            if (familiares == null) return NotFound();
            return new ObjectResult(familiares);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Familiares familiares)
        {
            if (familiares == null) return BadRequest();

            _FamiliaresRepositorio.AddFamiliares(familiares);
            return new ObjectResult(_FamiliaresRepositorio.FindByFam(familiares.idCliente));
        }

        [HttpPut("{cpf}")]
        public IActionResult Update([FromBody] Familiares familiares, string cpf)
        {
            if (familiares == null) return NotFound();

            int idCliente = _FamiliaresRepositorio.FindByIdCliente(cpf);
            var _familiares = _FamiliaresRepositorio.FindByFam(idCliente);

            _FamiliaresRepositorio.Update(familiares,_familiares);
            return new NoContentResult();
        }
    }
}