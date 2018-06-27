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
    [Route("api/DormPreferences")]
    public class DormPreferencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DormPreferencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DormPreferences
        [HttpGet]
        public IEnumerable<DormPreferenceModel> GetDormPreferenceModel()
        {
            return _context.DormPreferences;
        }

        // GET: api/DormPreferences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDormPreferenceModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dormPreferenceModel = await _context.DormPreferences.SingleOrDefaultAsync(m => m.DormPreferenceId == id);

            if (dormPreferenceModel == null)
            {
                return NotFound();
            }

            return Ok(dormPreferenceModel);
        }

        // PUT: api/DormPreferences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDormPreferenceModel([FromRoute] long id, [FromBody] DormPreferenceModel dormPreferenceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dormPreferenceModel.DormPreferenceId)
            {
                return BadRequest();
            }

            _context.Entry(dormPreferenceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DormPreferenceModelExists(id))
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

        // POST: api/DormPreferences
        [HttpPost]
        public async Task<IActionResult> PostDormPreferenceModel([FromBody] DormPreferenceModel dormPreferenceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DormPreferences.Add(dormPreferenceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDormPreferenceModel", new { id = dormPreferenceModel.DormPreferenceId }, dormPreferenceModel);
        }

        // DELETE: api/DormPreferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDormPreferenceModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dormPreferenceModel = await _context.DormPreferences.SingleOrDefaultAsync(m => m.DormPreferenceId == id);
            if (dormPreferenceModel == null)
            {
                return NotFound();
            }

            _context.DormPreferences.Remove(dormPreferenceModel);
            await _context.SaveChangesAsync();

            return Ok(dormPreferenceModel);
        }

        private bool DormPreferenceModelExists(long id)
        {
            return _context.DormPreferences.Any(e => e.DormPreferenceId == id);
        }
    }
}