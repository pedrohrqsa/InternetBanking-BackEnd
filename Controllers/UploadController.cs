using Microsoft.AspNetCore.Mvc;
using InternetBanking.Repositorio;
using System;
using System.IO;
using System.Net.Http.Headers;
using InternetBanking.Models;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class UploadController : Controller
    {
        private readonly IFotoRepositorio _fotoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IFotoRepositorio _foto;
        public UploadController(IFotoRepositorio fotoRepositorio,
         IClienteRepositorio clientes,
         IFotoRepositorio foto)
        {
            _fotoRepositorio = fotoRepositorio;
            _clienteRepositorio = clientes;
            _foto = foto;
        }

        [HttpPost("{cpf}", Name = "Foto"), DisableRequestSizeLimit]
        public IActionResult Upload(string cpf, Cliente cliente, Foto photo)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("RG", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    photo.caminhoFoto = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // cpf = "47958664818";
                    // cliente.cpf = cpf;

                    var clientes = _clienteRepositorio.FindByCpf(cliente.cpf);
                    if (clientes != null)
                    {   
                        photo.idCliente = clientes.idCliente;
                        _foto.AddFoto(photo);
                    }

                     return Ok(new { photo.caminhoFoto });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}