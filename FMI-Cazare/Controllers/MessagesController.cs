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
    [Route("api/Messages")]
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public IEnumerable<MessageModel> GetMessageModel()
        {
            return _context.Messages;
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var messageModel = await _context.Messages.SingleOrDefaultAsync(m => m.MessageId == id);

            if (messageModel == null)
            {
                return NotFound();
            }

            return Ok(messageModel);
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageModel([FromRoute] long id, [FromBody] MessageModel messageModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messageModel.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(messageModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageModelExists(id))
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

        // POST: api/Messages
        [HttpPost]
        public async Task<IActionResult> PostMessageModel([FromBody] MessageModel messageModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Messages.Add(messageModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageModel", new { id = messageModel.MessageId }, messageModel);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var messageModel = await _context.Messages.SingleOrDefaultAsync(m => m.MessageId == id);
            if (messageModel == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(messageModel);
            await _context.SaveChangesAsync();

            return Ok(messageModel);
        }

        private bool MessageModelExists(long id)
        {
            return _context.Messages.Any(e => e.MessageId == id);
        }
    }
}