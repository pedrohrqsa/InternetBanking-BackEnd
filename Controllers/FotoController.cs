using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class FotoController : Controller
    {
        private readonly IFotoRepositorio _fotoRepositorio;
        public FotoController(IFotoRepositorio fotoRepositorio)
        {
            _fotoRepositorio = fotoRepositorio;
        }

        [HttpGet]
        public IEnumerable<Foto> GetAll()
        {
            return _fotoRepositorio.GetAll();
        }

        [HttpGet("{foto}", Name = "GetFoto")]
        public IActionResult GeFoto(int id)
        {
            var foto = _fotoRepositorio.FindByFoto(id);

            if (foto == null) return NotFound();
            return new ObjectResult(foto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Foto foto)
        {
            if (foto == null) return BadRequest();

            _fotoRepositorio.AddFoto(foto);
            return new ObjectResult(_fotoRepositorio.FindByFoto(foto.idFoto));
        }

        // [HttpPut("{cpf}")]
        // public IActionResult Update([FromBody] Contato contato, string cpf)
        // {
        //     if (contato == null) return NotFound();

        //     int idCliente = _contatoRep.FindByIdCliente(cpf);
        //     var _contato = _contatoRep.FindByContato(idCliente);
            
        //    _contato.email = contato.email;
        //    _contato.telCel = contato.telCel;
        //    _contato.telResid = contato.telResid;

        //     _contatoRep.Update(_contato);
        //     return new NoContentResult();
        // }
    }
}