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
    [Route("api/Histories")]
    public class HistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Histories
        [HttpGet]
        public IEnumerable<HistoryModel> GetHistoryModel()
        {
            return _context.Histories;
        }

        // GET: api/Histories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoryModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historyModel = await _context.Histories.SingleOrDefaultAsync(m => m.HistoryId == id);

            if (historyModel == null)
            {
                return NotFound();
            }

            return Ok(historyModel);
        }

        // PUT: api/Histories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryModel([FromRoute] long id, [FromBody] HistoryModel historyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historyModel.HistoryId)
            {
                return BadRequest();
            }

            _context.Entry(historyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryModelExists(id))
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

        // POST: api/Histories
        [HttpPost]
        public async Task<IActionResult> PostHistoryModel([FromBody] HistoryModel historyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Histories.Add(historyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoryModel", new { id = historyModel.HistoryId }, historyModel);
        }

        // DELETE: api/Histories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historyModel = await _context.Histories.SingleOrDefaultAsync(m => m.HistoryId == id);
            if (historyModel == null)
            {
                return NotFound();
            }

            _context.Histories.Remove(historyModel);
            await _context.SaveChangesAsync();

            return Ok(historyModel);
        }

        private bool HistoryModelExists(long id)
        {
            return _context.Histories.Any(e => e.HistoryId == id);
        }
    }
}