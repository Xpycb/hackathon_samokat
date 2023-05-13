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
    public class WorkingPlacesController : ControllerBase
    {
        private readonly WorkingPlacesConext _context;

        public WorkingPlacesController(WorkingPlacesConext context)
        {
            _context = context;
        }

        // GET: api/WorkingPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkingPlaces>>> GetPlacesItems()
        {
          if (_context.PlacesItems == null)
          {
              return NotFound();
          }
            return await _context.PlacesItems.ToListAsync();
        }

        // GET: api/WorkingPlaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkingPlaces>> GetWorkingPlaces(long id)
        {
          if (_context.PlacesItems == null)
          {
              return NotFound();
          }
            var workingPlaces = await _context.PlacesItems.FindAsync(id);

            if (workingPlaces == null)
            {
                return NotFound();
            }

            return workingPlaces;
        }

        // PUT: api/WorkingPlaces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkingPlaces(long id, WorkingPlaces workingPlaces)
        {
            if (id != workingPlaces.Id)
            {
                return BadRequest();
            }

            _context.Entry(workingPlaces).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkingPlacesExists(id))
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

        // POST: api/WorkingPlaces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkingPlaces>> PostWorkingPlaces(WorkingPlaces workingPlaces)
        {
          if (_context.PlacesItems == null)
          {
              return Problem("Entity set 'WorkingPlacesConext.PlacesItems'  is null.");
          }
            _context.PlacesItems.Add(workingPlaces);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkingPlaces", new { id = workingPlaces.Id }, workingPlaces);
        }

        // DELETE: api/WorkingPlaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkingPlaces(long id)
        {
            if (_context.PlacesItems == null)
            {
                return NotFound();
            }
            var workingPlaces = await _context.PlacesItems.FindAsync(id);
            if (workingPlaces == null)
            {
                return NotFound();
            }

            _context.PlacesItems.Remove(workingPlaces);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkingPlacesExists(long id)
        {
            return (_context.PlacesItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
