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
                _context.DocumentModel.RemoveRange(_context.DocumentModel);
                _context.DormCategoryModel.RemoveRange(_context.DormCategoryModel);
                _context.DormPreferenceModel.RemoveRange(_context.DormPreferenceModel);
                _context.DormModel.RemoveRange(_context.DormModel);
                _context.FormModel.RemoveRange(_context.FormModel);
                _context.HistoryModel.RemoveRange(_context.HistoryModel);
                _context.MessageModel.RemoveRange(_context.MessageModel);
                _context.NotificationModel.RemoveRange(_context.NotificationModel);
                _context.RoomatePreferenceModel.RemoveRange(_context.RoomatePreferenceModel);
                _context.RoomModel.RemoveRange(_context.RoomModel);
                _context.SessionModel.RemoveRange(_context.SessionModel);
                _context.SpotModel.RemoveRange(_context.SpotModel);
                _context.Users.RemoveRange(_context.Users);

                await _context.SaveChangesAsync();


                await _context.SaveChangesAsync();

                await _context.SessionModel.AddRangeAsync(
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
