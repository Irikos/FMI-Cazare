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
    [Route("api/Documents")]
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Documents
        [HttpGet]
        public IEnumerable<DocumentModel> GetDocumentModel()
        {
            return _context.DocumentModel;
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentModel = await _context.DocumentModel.SingleOrDefaultAsync(m => m.DocumentId == id);

            if (documentModel == null)
            {
                return NotFound();
            }

            return Ok(documentModel);
        }

        // PUT: api/Documents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentModel([FromRoute] long id, [FromBody] DocumentModel documentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentModel.DocumentId)
            {
                return BadRequest();
            }

            _context.Entry(documentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentModelExists(id))
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

        // POST: api/Documents
        [HttpPost]
        public async Task<IActionResult> PostDocumentModel([FromBody] DocumentModel documentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DocumentModel.Add(documentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentModel", new { id = documentModel.DocumentId }, documentModel);
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentModel = await _context.DocumentModel.SingleOrDefaultAsync(m => m.DocumentId == id);
            if (documentModel == null)
            {
                return NotFound();
            }

            _context.DocumentModel.Remove(documentModel);
            await _context.SaveChangesAsync();

            return Ok(documentModel);
        }

        private bool DocumentModelExists(long id)
        {
            return _context.DocumentModel.Any(e => e.DocumentId == id);
        }
    }
}