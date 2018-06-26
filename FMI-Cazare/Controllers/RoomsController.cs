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
    [Route("api/Rooms")]
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<RoomModel> GetRoomModel()
        {
            return _context.RoomModel;
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomModel = await _context.RoomModel.SingleOrDefaultAsync(m => m.RoomId == id);

            if (roomModel == null)
            {
                return NotFound();
            }

            return Ok(roomModel);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomModel([FromRoute] long id, [FromBody] RoomModel roomModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomModel.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(roomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomModelExists(id))
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

        // POST: api/Rooms
        [HttpPost]
        public async Task<IActionResult> PostRoomModel([FromBody] RoomModel roomModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoomModel.Add(roomModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomModel", new { id = roomModel.RoomId }, roomModel);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomModel = await _context.RoomModel.SingleOrDefaultAsync(m => m.RoomId == id);
            if (roomModel == null)
            {
                return NotFound();
            }

            _context.RoomModel.Remove(roomModel);
            await _context.SaveChangesAsync();

            return Ok(roomModel);
        }

        private bool RoomModelExists(long id)
        {
            return _context.RoomModel.Any(e => e.RoomId == id);
        }
    }
}