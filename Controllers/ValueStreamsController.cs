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
    public class ValueStreamsController : ControllerBase
    {
        private readonly Context _context;

        public ValueStreamsController(Context context)
        {
            _context = context;
        }

        // GET: api/ValueStreams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValueStreams>>> GetValueStreams()
        {
            return await _context.ValueStreams.ToListAsync();
        }

        // GET: api/ValueStreams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValueStreams>> GetValueStreams(int id)
        {
            var valueStreams = await _context.ValueStreams.FindAsync(id);

            if (valueStreams == null)
            {
                return NotFound();
            }

            return valueStreams;
        }

        // PUT: api/ValueStreams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValueStreams(int id, ValueStreams valueStreams)
        {
            if (id != valueStreams.Id)
            {
                return BadRequest();
            }

            _context.Entry(valueStreams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueStreamsExists(id))
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

        // POST: api/ValueStreams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ValueStreams>> PostValueStreams(ValueStreams valueStreams)
        {
            _context.ValueStreams.Add(valueStreams);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValueStreams", new { id = valueStreams.Id }, valueStreams);
        }

        // DELETE: api/ValueStreams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValueStreams(int id)
        {
            var valueStreams = await _context.ValueStreams.FindAsync(id);
            if (valueStreams == null)
            {
                return NotFound();
            }

            _context.ValueStreams.Remove(valueStreams);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValueStreamsExists(int id)
        {
            return _context.ValueStreams.Any(e => e.Id == id);
        }
    }
}
