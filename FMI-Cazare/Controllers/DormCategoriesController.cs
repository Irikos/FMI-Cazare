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
    [Route("api/DormCategories")]
    public class DormCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DormCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DormCategories
        [HttpGet]
        public IEnumerable<DormCategoryModel> GetDormCategoryModel()
        {
            return _context.DormCategoryModel;
        }

        // GET: api/DormCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDormCategoryModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dormCategoryModel = await _context.DormCategoryModel.SingleOrDefaultAsync(m => m.DormCategoryId == id);

            if (dormCategoryModel == null)
            {
                return NotFound();
            }

            return Ok(dormCategoryModel);
        }

        // PUT: api/DormCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDormCategoryModel([FromRoute] long id, [FromBody] DormCategoryModel dormCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dormCategoryModel.DormCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(dormCategoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DormCategoryModelExists(id))
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

        // POST: api/DormCategories
        [HttpPost]
        public async Task<IActionResult> PostDormCategoryModel([FromBody] DormCategoryModel dormCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DormCategoryModel.Add(dormCategoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDormCategoryModel", new { id = dormCategoryModel.DormCategoryId }, dormCategoryModel);
        }

        // DELETE: api/DormCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDormCategoryModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dormCategoryModel = await _context.DormCategoryModel.SingleOrDefaultAsync(m => m.DormCategoryId == id);
            if (dormCategoryModel == null)
            {
                return NotFound();
            }

            _context.DormCategoryModel.Remove(dormCategoryModel);
            await _context.SaveChangesAsync();

            return Ok(dormCategoryModel);
        }

        private bool DormCategoryModelExists(long id)
        {
            return _context.DormCategoryModel.Any(e => e.DormCategoryId == id);
        }
    }
}