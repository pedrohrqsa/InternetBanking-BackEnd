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

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Familiares familiares)
        {
            if (familiares == null) return NotFound();

            var _familiares = _FamiliaresRepositorio.FindByFam(id);

            _familiares.nomeMae = familiares.nomeMae;
            _familiares.sobrenomeMae = familiares.sobrenomeMae;
            _familiares.nomePai = familiares.nomePai;
            _familiares.sobrenomePai = familiares.sobrenomePai;

            _FamiliaresRepositorio.Update(_familiares);
            return new NoContentResult();
        }
    }
}