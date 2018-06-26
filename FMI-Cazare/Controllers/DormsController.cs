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
    [Route("api/Dorms")]
    public class DormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dorms
        [HttpGet]
        public IEnumerable<DormModel> GetDormModel()
        {
            return _context.DormModel;
        }

        // GET: api/Dorms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDormModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dormModel = await _context.DormModel.SingleOrDefaultAsync(m => m.DormId == id);

            if (dormModel == null)
            {
                return NotFound();
            }

            return Ok(dormModel);
        }

        // PUT: api/Dorms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDormModel([FromRoute] long id, [FromBody] DormModel dormModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dormModel.DormId)
            {
                return BadRequest();
            }

            _context.Entry(dormModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DormModelExists(id))
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

        // POST: api/Dorms
        [HttpPost]
        public async Task<IActionResult> PostDormModel([FromBody] DormModel dormModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DormModel.Add(dormModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDormModel", new { id = dormModel.DormId }, dormModel);
        }

        // DELETE: api/Dorms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDormModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dormModel = await _context.DormModel.SingleOrDefaultAsync(m => m.DormId == id);
            if (dormModel == null)
            {
                return NotFound();
            }

            _context.DormModel.Remove(dormModel);
            await _context.SaveChangesAsync();

            return Ok(dormModel);
        }

        private bool DormModelExists(long id)
        {
            return _context.DormModel.Any(e => e.DormId == id);
        }
    }
}