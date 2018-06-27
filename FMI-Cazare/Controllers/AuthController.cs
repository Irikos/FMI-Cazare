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
using Newtonsoft.Json;

namespace FMI_Cazare.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        public struct Credentials
        {
            public string Email;
            public string Password;
        }

        public static string ComputeHash(string password)
            => BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password))).Replace("-", String.Empty).ToLower();

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<UserModel> Login([FromBody] Credentials credentials)
        {
            if (!HttpContext.Session.IsAvailable)
            {
                Response.StatusCode = 400;
                return null;
            }
            UserModel me = await _context.Users.SingleOrDefaultAsync(m =>
                m.Email.ToUpper() == credentials.Email.ToUpper() &&
                m.PasswordHash == ComputeHash(credentials.Password));

            if (me != null)
            {
                me.PasswordHash = null;
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(me));
                return me;
            }
            else
            {
                Response.StatusCode = 401;
                return null;
            }
        }

        // GET: api/Auth/WhoAmI
        [HttpGet("WhoAmI")]
        public UserModel WhoAmI()
        {
            if (!HttpContext.Session.IsAvailable)
            {
                Response.StatusCode = 400;
                return null;
            }
            string me = HttpContext.Session.GetString("User");
            if (me != null)
            {
                return JsonConvert.DeserializeObject<UserModel>(me);
            }
            else
            {
                Response.StatusCode = 401;
                return null;
            }
        }

        // POST: api/Auth/Logout
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            if (!HttpContext.Session.IsAvailable)
            {
                return BadRequest();
            }
            string me = HttpContext.Session.GetString("User");
            if (me != null)
            {
                HttpContext.Session.Clear();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}