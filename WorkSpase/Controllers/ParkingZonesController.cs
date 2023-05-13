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
    public class ParkingZonesController : ControllerBase
    {
        private readonly ParkingZoneConext _context;

        public ParkingZonesController(ParkingZoneConext context)
        {
            _context = context;
        }

        // GET: api/ParkingZones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingZone>>> GetWorkItems()
        {
          if (_context.WorkItems == null)
          {
              return NotFound();
          }
            return await _context.WorkItems.ToListAsync();
        }

        // GET: api/ParkingZones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingZone>> GetParkingZone(long id)
        {
          if (_context.WorkItems == null)
          {
              return NotFound();
          }
            var parkingZone = await _context.WorkItems.FindAsync(id);

            if (parkingZone == null)
            {
                return NotFound();
            }

            return parkingZone;
        }

        // PUT: api/ParkingZones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingZone(long id, ParkingZone parkingZone)
        {
            if (id != parkingZone.Id)
            {
                return BadRequest();
            }

            _context.Entry(parkingZone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingZoneExists(id))
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

        // POST: api/ParkingZones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParkingZone>> PostParkingZone(ParkingZone parkingZone)
        {
          if (_context.WorkItems == null)
          {
              return Problem("Entity set 'ParkingZoneConext.WorkItems'  is null.");
          }
            _context.WorkItems.Add(parkingZone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingZone", new { id = parkingZone.Id }, parkingZone);
        }

        // DELETE: api/ParkingZones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingZone(long id)
        {
            if (_context.WorkItems == null)
            {
                return NotFound();
            }
            var parkingZone = await _context.WorkItems.FindAsync(id);
            if (parkingZone == null)
            {
                return NotFound();
            }

            _context.WorkItems.Remove(parkingZone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingZoneExists(long id)
        {
            return (_context.WorkItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
