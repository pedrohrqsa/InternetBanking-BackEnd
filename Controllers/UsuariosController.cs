using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repositorio;
namespace test.Controllers
{

    [Route("api/[Controller]")]
    [Authorize()]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuariosController(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null) return NotFound();

            return new ObjectResult(usuario);
        }

        [HttpPost]
        public IActionResult Create ([FromBody] Usuario usuario){
            if (usuario == null) return BadRequest();

            _usuarioRepositorio.Add(usuario);
            return CreatedAtRoute("GetUsuario", new {id=usuario.UsuarioId}, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update (long id, [FromBody] Usuario usuario){
            if (usuario==null)
            return NotFound();

            var _usuario = _usuarioRepositorio.Find(id);

            _usuario.Nome = usuario.Nome;
            _usuario.Senha = usuario.Senha;
            _usuario.Email = usuario.Email;
        
            _usuarioRepositorio.Update(_usuario);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (long id){
            var usuario = _usuarioRepositorio.Find(id);

            if (usuario==null) return NotFound();

            _usuarioRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}