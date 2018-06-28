using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMI_Cazare.Models;
using FMI_Cazare.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMI_Cazare.Controllers
{
    [Produces("application/json")]
    [Route("api/Pdf")]
    public class PdfController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly GeneratorService _generatorService;

        public PdfController(ApplicationDbContext context, GeneratorService generatorService)
        {
            _context = context;
            _generatorService = generatorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            FormModel form = await _context.Forms
                .Include(m => m.User)
                .Include(m => m.DormPreferences)
                    .ThenInclude(m => m.Dorm)
                .FirstOrDefaultAsync(m => m.UserId == id && m.State == FormModel.FormState.Approved);

            if (form == null)
                return NotFound();
            
            string html = await System.IO.File.ReadAllTextAsync("pdf.html");

            html = html.Replace("{0}", form.User.LastName + " " + form.User.FatherFirstName[0] + ". " + form.User.FirstName);
            html = html.Replace("{1}", form.User.BirthDate.ToString("dd.MM.yyyy"));
            html = html.Replace("{2}", form.User.BirthPlace);
            html = html.Replace("{3}", form.User.FatherFirstName);
            html = html.Replace("{4}", form.User.MotherFirstName);
            html = html.Replace("{5}", form.User.Address);
            html = html.Replace("{6}", form.User.Phone);
            html = html.Replace("{7}", form.User.Email);
            html = html.Replace("{8}", form.User.IcSerie);
            html = html.Replace("{9}", form.User.IcNumber);
            html = html.Replace("{10}", form.User.Cnp);
            html = html.Replace("{11}", "Matematica si Informatica");
            html = html.Replace("{12}", form.User.Specialization);
            html = html.Replace("{13}", form.User.Year);
            html = html.Replace("{14}", "");
            html = html.Replace("{15}", "");
            html = html.Replace("{16}", "");
            html = html.Replace("{17}", "");
            html = html.Replace("{18}", "");
            html = html.Replace("{19}", "");
            html = html.Replace("{20}", String.Join(", ", form.DormPreferences.Select(m => m.Dorm.Name)));
            html = html.Replace("{21}", "");
            html = html.Replace("{22}", form.IsContinuity ? "X" : "");
            html = html.Replace("{23}", "");
            html = html.Replace("{24}", "");
            html = html.Replace("{25}", "");
            html = html.Replace("{26}", form.IsSocial ? "X" : "");
            html = html.Replace("{27}", "");
            html = html.Replace("{28}", "");
            html = html.Replace("{29}", DateTime.Today.ToString("dd.MM.yyyy"));

            byte[] pdf = await _generatorService.HtmlToPdfAsync(html);
            return File(pdf, "application/pdf", form.User.LastName + " " + form.User.FirstName + ".pdf");
        }

    }
}