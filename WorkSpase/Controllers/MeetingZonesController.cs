using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpase.Models;

namespace WorkSpase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingZonesController : ControllerBase
    {
        private readonly MeetingZoneConext _context;

        public MeetingZonesController(MeetingZoneConext context)
        {
            _context = context;
        }

        // GET: api/MeetingZones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingZone>>> GetMeetItems()
        {
          if (_context.MeetItems == null)
          {
              return NotFound();
          }
            return await _context.MeetItems.ToListAsync();
        }

        // GET: api/MeetingZones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingZone>> GetMeetingZone(long id)
        {
          if (_context.MeetItems == null)
          {
              return NotFound();
          }
            var meetingZone = await _context.MeetItems.FindAsync(id);

            if (meetingZone == null)
            {
                return NotFound();
            }

            return meetingZone;
        }

        // PUT: api/MeetingZones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingZone(long id, MeetingZone meetingZone)
        {
            if (id != meetingZone.Id)
            {
                return BadRequest();
            }

            _context.Entry(meetingZone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingZoneExists(id))
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

        // POST: api/MeetingZones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MeetingZone>> PostMeetingZone(MeetingZone meetingZone)
        {
          if (_context.MeetItems == null)
          {
              return Problem("Entity set 'MeetingZoneConext.MeetItems'  is null.");
          }
            _context.MeetItems.Add(meetingZone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeetingZone", new { id = meetingZone.Id }, meetingZone);
        }

        // DELETE: api/MeetingZones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetingZone(long id)
        {
            if (_context.MeetItems == null)
            {
                return NotFound();
            }
            var meetingZone = await _context.MeetItems.FindAsync(id);
            if (meetingZone == null)
            {
                return NotFound();
            }

            _context.MeetItems.Remove(meetingZone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeetingZoneExists(long id)
        {
            return (_context.MeetItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
