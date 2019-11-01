using System;
using System.Text;
using test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Cliente request)
        {
            if (request.CPF == "47958664818" && request.Senha == "TESTE")
            {
                var claims = new[]
                {
                    new Claim (ClaimTypes.Name, request.CPF)
                };

                IdentityModelEventSource.ShowPII = true;

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InternetBanking.net",
                    audience: "InternetBanking.net",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
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