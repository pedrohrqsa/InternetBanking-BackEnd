using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Authorization;
namespace InternetBanking.Controllers
{
     [Route("api/[Controller]")]
     [Authorize()]
    public class ContatoController : Controller
    {
    private readonly IContatoRepositorio _contatoRep;
    public ContatoController(IContatoRepositorio contatoRepo)
        {
            _contatoRep = contatoRepo;
        }

        [HttpPost]
        public IActionResult Create ([FromBody] Contato contatos){
            if (contatos == null) return BadRequest();

            _contatoRep.AddContato(contatos);
            return CreatedAtRoute("GetContato", new {id=contatos.ID_CLIENTE}, contatos);
        }
    }
}