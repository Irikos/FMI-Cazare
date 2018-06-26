using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using FMI_Cazare.Models;
using Microsoft.EntityFrameworkCore;

namespace FMI_Cazare.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public AuthController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        public struct Credentials
        {
            public string Username;
            public string Password;
        }

        private static string ComputeHash(string password)
            => BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password))).Replace("-", String.Empty).ToLower();

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Credentials credentials)
        {
            IActionResult response = Unauthorized();

            UserModel user = await _context.Users.SingleOrDefaultAsync(m =>
                m.Username.ToUpper() == credentials.Username.ToUpper() &&
                m.PasswordHash == ComputeHash(credentials.Password));

            if (user != null)
            {
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"], 
                    audience: _config["Jwt:Issuer"], 
                    expires: new DateTime?(DateTime.Now.AddMinutes(Convert.ToInt64(_config["Jwt:Timeout"]))), 
                    signingCredentials: creds);

                response = Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return response;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}