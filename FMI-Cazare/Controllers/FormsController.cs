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
    [Route("api/Forms")]
    public class FormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Forms
        [HttpGet]
        public IEnumerable<FormModel> GetFormModel()
        {
            return _context.Forms;
        }

        // GET: api/Forms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formModel = await _context.Forms
                .Include(f => f.User)
                .Include(f => f.RoomatePreferences)
                .Include(f => f.DormPreferences)
                 .ThenInclude(d => d.Dorm)
                .SingleOrDefaultAsync(m => m.UserId == id);

            if (formModel == null)
            {
                return NotFound();
            }

            return Ok(formModel);
        }

        // PUT: api/Forms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormModel([FromRoute] long id, [FromBody] FormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formModel.FormId)
            {
                return BadRequest();
            }

            _context.Entry(formModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormModelExists(id))
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

        // POST: api/Forms
        [HttpPost]
        public async Task<IActionResult> PostFormModel([FromBody] FormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var i = 0;
            formModel.DormPreferences.ToList().ForEach(d =>
            {
                d.Priority = i;
                i++;
                d.Dorm = null;
                if (d.DormPreferenceId == 0)
                    _context.Entry(d).State = EntityState.Added;
                else
                    _context.Entry(d).State = EntityState.Modified;
            });
    

            formModel.Session = null;
            formModel.User = null;

            formModel.SessionId = 1;
            formModel.UserId = 1;

            if (formModel.FormId == 0)
                _context.Forms.Add(formModel);
            else
            {

                _context.Entry(formModel).State = EntityState.Modified;
            }


            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormModel", new { id = formModel.FormId }, formModel);
        }

        // DELETE: api/Forms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formModel = await _context.Forms.SingleOrDefaultAsync(m => m.FormId == id);
            if (formModel == null)
            {
                return NotFound();
            }

            _context.Forms.Remove(formModel);
            await _context.SaveChangesAsync();

            return Ok(formModel);
        }

        private bool FormModelExists(long id)
        {
            return _context.Forms.Any(e => e.FormId == id);
        }
    }
}