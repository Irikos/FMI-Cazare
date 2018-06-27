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
    [Route("api/Spots")]
    public class SpotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Spots
        [HttpGet]
        public IEnumerable<SpotModel> GetSpotModel()
        {
            return _context.Spots;
        }

        // GET: api/Spots/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spotModel = await _context.Spots.SingleOrDefaultAsync(m => m.SpotId == id);

            if (spotModel == null)
            {
                return NotFound();
            }

            return Ok(spotModel);
        }

        // PUT: api/Spots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpotModel([FromRoute] long id, [FromBody] SpotModel spotModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spotModel.SpotId)
            {
                return BadRequest();
            }

            _context.Entry(spotModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpotModelExists(id))
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

        // POST: api/Spots
        [HttpPost]
        public async Task<IActionResult> PostSpotModel([FromBody] SpotModel spotModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Spots.Add(spotModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpotModel", new { id = spotModel.SpotId }, spotModel);
        }

        // DELETE: api/Spots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpotModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spotModel = await _context.Spots.SingleOrDefaultAsync(m => m.SpotId == id);
            if (spotModel == null)
            {
                return NotFound();
            }

            _context.Spots.Remove(spotModel);
            await _context.SaveChangesAsync();

            return Ok(spotModel);
        }

        private bool SpotModelExists(long id)
        {
            return _context.Spots.Any(e => e.SpotId == id);
        }
    }
}