using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CredexAPI.Models;

namespace CredexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly Context _context;

        public StatusesController(Context context)
        {
            _context = context;
        }

        // GET: api/Statuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statuses>>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statuses>> GetStatuses(int id)
        {
            var statuses = await _context.Statuses.FindAsync(id);

            if (statuses == null)
            {
                return NotFound();
            }

            return statuses;
        }

        // PUT: api/Statuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatuses(int id, Statuses statuses)
        {
            if (id != statuses.Id)
            {
                return BadRequest();
            }

            _context.Entry(statuses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusesExists(id))
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

        // POST: api/Statuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statuses>> PostStatuses(Statuses statuses)
        {
            _context.Statuses.Add(statuses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatuses", new { id = statuses.Id }, statuses);
        }

        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatuses(int id)
        {
            var statuses = await _context.Statuses.FindAsync(id);
            if (statuses == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(statuses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusesExists(int id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }
    }
}
