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
    [Route("api/RoomatePreferences")]
    public class RoomatePreferencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomatePreferencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomatePreferences
        [HttpGet]
        public IEnumerable<RoomatePreferenceModel> GetRoomatePreferenceModel()
        {
            return _context.RoomatePreferences;
        }

        // GET: api/RoomatePreferences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomatePreferenceModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomatePreferenceModel = await _context.RoomatePreferences.SingleOrDefaultAsync(m => m.RoommatePreferenceId == id);

            if (roomatePreferenceModel == null)
            {
                return NotFound();
            }

            return Ok(roomatePreferenceModel);
        }

        // PUT: api/RoomatePreferences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomatePreferenceModel([FromRoute] long id, [FromBody] RoomatePreferenceModel roomatePreferenceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomatePreferenceModel.RoommatePreferenceId)
            {
                return BadRequest();
            }

            _context.Entry(roomatePreferenceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomatePreferenceModelExists(id))
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

        // POST: api/RoomatePreferences
        [HttpPost]
        public async Task<IActionResult> PostRoomatePreferenceModel([FromBody] RoomatePreferenceModel roomatePreferenceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoomatePreferences.Add(roomatePreferenceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomatePreferenceModel", new { id = roomatePreferenceModel.RoommatePreferenceId }, roomatePreferenceModel);
        }

        // DELETE: api/RoomatePreferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomatePreferenceModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomatePreferenceModel = await _context.RoomatePreferences.SingleOrDefaultAsync(m => m.RoommatePreferenceId == id);
            if (roomatePreferenceModel == null)
            {
                return NotFound();
            }

            _context.RoomatePreferences.Remove(roomatePreferenceModel);
            await _context.SaveChangesAsync();

            return Ok(roomatePreferenceModel);
        }

        private bool RoomatePreferenceModelExists(long id)
        {
            return _context.RoomatePreferences.Any(e => e.RoommatePreferenceId == id);
        }
    }
}