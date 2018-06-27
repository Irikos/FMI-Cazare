using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FMI_Cazare.Models;

namespace FMI_Cazare.Controllers
{
    [Produces("application/json")]
    [Route("api/Generate")]
    public class GenerateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenerateController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("Licenta1")]
        public async Task<IActionResult> DummyDataAsync()
        {
            try
            {
                /*_context.Documents.RemoveRange(_context.Documents);
                _context.DormCategories.RemoveRange(_context.DormCategories);
                _context.DormPreferences.RemoveRange(_context.DormPreferences);
                _context.Dorms.RemoveRange(_context.Dorms);
                _context.Forms.RemoveRange(_context.Forms);
                _context.Histories.RemoveRange(_context.Histories);
                _context.Messages.RemoveRange(_context.Messages);
                _context.Notifications.RemoveRange(_context.Notifications);
                _context.RoomatePreferences.RemoveRange(_context.RoomatePreferences);
                _context.Rooms.RemoveRange(_context.Rooms);
                _context.Sessions.RemoveRange(_context.Sessions);
                _context.Spots.RemoveRange(_context.Spots);
                _context.Users.RemoveRange(_context.Users);*/

                await _context.Database.EnsureDeletedAsync();

                await _context.Database.EnsureCreatedAsync();

                await _context.Users.AddRangeAsync(
                    new UserModel
                    {
                        Email = "admin@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("admin"),
                        Role = UserModel.UserRole.Admin
                    },
                    new UserModel
                    {
                        Email = "management@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("management"),
                        Role = UserModel.UserRole.Management
                    },
                    new UserModel
                    {
                        Email = "teacher@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("teacher"),
                        Role = UserModel.UserRole.Teacher
                    },
                    new UserModel
                    {
                        Email = "student@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("student"),
                        Role = UserModel.UserRole.Student
                    }
                );

                await _context.Sessions.AddRangeAsync(
                    new SessionModel
                    {
                        SessionId = 1,
                        Name = "Sesiune 1",
                        Description = "Prima sesiune de test",

                    }
                );

                await _context.SaveChangesAsync();

                return Ok("Success.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Generate
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Generate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Generate
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Generate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
