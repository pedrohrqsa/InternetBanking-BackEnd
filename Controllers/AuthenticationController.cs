using System;
using System.Text;
using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using InternetBanking.Repositorio;
namespace InternetBanking.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IClienteLoginRepositorio _clienteLoginRepositorio;

        public TokenController(IConfiguration configuration,
         IClienteLoginRepositorio clienteRepo)
        {
            _configuration = configuration;
            _clienteLoginRepositorio = clienteRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Token([FromBody] ClienteLogin request)
        {
            var cli = _clienteLoginRepositorio.FindByCpf(request.cpf);
            if (cli != null && cli.senhaAcesso == request.senhaAcesso)
            {
                var claims = new[]
                {
                    new Claim (ClaimTypes.Name, request.cpf)
                };

                IdentityModelEventSource.ShowPII = true;

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InternetBanking.net",
                    audience: "InternetBanking.net",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
                return Ok(new
                {
                     token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Credenciais Inválidas...");
        }
    }
}