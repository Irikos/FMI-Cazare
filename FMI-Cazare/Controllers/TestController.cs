using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMI_Cazare.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMI_Cazare.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly GeneratorService _generatorService;

        public TestController(ApplicationDbContext context, GeneratorService generatorService)
        {
            _context = context;
            _generatorService = generatorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TestGenerator([FromRoute] long id)
        {
            var form = await _context.Forms
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.FormId == id);

            if (form == null)
                return NotFound();

            string html = String.Format(@"
<!DOCTYPE html>
<html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
<body>
<h1>It works!</h1>
User address: {0}
</body>
</html>",
form.User.Address);

            byte[] pdf = await _generatorService.HtmlToPdfAsync(html);
            return File(pdf, "application/pdf", "Manifest.pdf");
        }

    }
}