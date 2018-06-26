using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FMI_Cazare;
using FMI_Cazare.Models;

namespace FMI_Cazare.Controllers
{
    [Produces("application/json")]
    [Route("api/Sessions")]
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sessions
        [HttpGet]
        public IEnumerable<SessionModel> GetSessionModel()
        {
            return _context.SessionModel;
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessionModel = await _context.SessionModel.SingleOrDefaultAsync(m => m.SessionId == id);

            if (sessionModel == null)
            {
                return NotFound();
            }

            return Ok(sessionModel);
        }

        // PUT: api/Sessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessionModel([FromRoute] long id, [FromBody] SessionModel sessionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessionModel.SessionId)
            {
                return BadRequest();
            }

            _context.Entry(sessionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sessions
        [HttpPost]
        public async Task<IActionResult> PostSessionModel([FromBody] SessionModel sessionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SessionModel.Add(sessionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessionModel", new { id = sessionModel.SessionId }, sessionModel);
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessionModel = await _context.SessionModel.SingleOrDefaultAsync(m => m.SessionId == id);
            if (sessionModel == null)
            {
                return NotFound();
            }

            _context.SessionModel.Remove(sessionModel);
            await _context.SaveChangesAsync();

            return Ok(sessionModel);
        }

        private bool SessionModelExists(long id)
        {
            return _context.SessionModel.Any(e => e.SessionId == id);
        }
    }
}