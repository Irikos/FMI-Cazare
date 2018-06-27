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
    [Route("api/Notifications")]
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Notifications
        [HttpGet]
        public IEnumerable<NotificationModel> GetNotificationModel()
        {
            return _context.Notifications;
        }

        // GET: api/Notifications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notificationModel = await _context.Notifications.SingleOrDefaultAsync(m => m.NotificationId == id);

            if (notificationModel == null)
            {
                return NotFound();
            }

            return Ok(notificationModel);
        }

        // PUT: api/Notifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationModel([FromRoute] long id, [FromBody] NotificationModel notificationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificationModel.NotificationId)
            {
                return BadRequest();
            }

            _context.Entry(notificationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationModelExists(id))
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

        // POST: api/Notifications
        [HttpPost]
        public async Task<IActionResult> PostNotificationModel([FromBody] NotificationModel notificationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Notifications.Add(notificationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificationModel", new { id = notificationModel.NotificationId }, notificationModel);
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationModel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notificationModel = await _context.Notifications.SingleOrDefaultAsync(m => m.NotificationId == id);
            if (notificationModel == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(notificationModel);
            await _context.SaveChangesAsync();

            return Ok(notificationModel);
        }

        private bool NotificationModelExists(long id)
        {
            return _context.Notifications.Any(e => e.NotificationId == id);
        }
    }
}