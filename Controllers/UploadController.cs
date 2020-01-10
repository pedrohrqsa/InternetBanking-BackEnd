using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Authorization;
using System;
using System.IO;
using System.Net.Http.Headers;


namespace InternetBanking.Controllers
{
    // [Authorize()]
    [Route("api/[Controller]")]
    public class UploadController : Controller
    {
        private readonly IFotoRepositorio _fotoRepositorio;
        public UploadController(IFotoRepositorio fotoRepositorio)
        {
            _fotoRepositorio = fotoRepositorio;
        }
        // [HttpGet]
        // public IEnumerable<Foto> GetAll()
        // {
        //     return _fotoRepositorio.GetAll();
        // }
        // [HttpGet("{foto}", Name = "GetFoto")]
        // public IActionResult GetByFoto(int idFoto)
        // {
        //     var Foto = _fotoRepositorio.FindByFoto(idFoto);

        //     if (Foto == null) return NotFound();
        //     return new ObjectResult(Foto);
        // }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
        
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
        
                    return Ok(new { dbPath });
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