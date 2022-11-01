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
    public class AllowanceTypesController : ControllerBase
    {
        private readonly Context _context;

        public AllowanceTypesController(Context context)
        {
            _context = context;
        }

        // GET: api/AllowanceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllowanceTypes>>> GetAllowanceTypes()
        {
            return await _context.AllowanceTypes.ToListAsync();
        }

        // GET: api/AllowanceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllowanceTypes>> GetAllowanceTypes(string id)
        {
            var allowanceTypes = await _context.AllowanceTypes.FindAsync(id);

            if (allowanceTypes == null)
            {
                return NotFound();
            }

            return allowanceTypes;
        }

        // PUT: api/AllowanceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowanceTypes(string id, AllowanceTypes allowanceTypes)
        {
            if (id != allowanceTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(allowanceTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowanceTypesExists(id))
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

        // POST: api/AllowanceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AllowanceTypes>> PostAllowanceTypes(AllowanceTypes allowanceTypes)
        {
            _context.AllowanceTypes.Add(allowanceTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AllowanceTypesExists(allowanceTypes.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAllowanceTypes", new { id = allowanceTypes.Id }, allowanceTypes);
        }

        // DELETE: api/AllowanceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllowanceTypes(string id)
        {
            var allowanceTypes = await _context.AllowanceTypes.FindAsync(id);
            if (allowanceTypes == null)
            {
                return NotFound();
            }

            _context.AllowanceTypes.Remove(allowanceTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllowanceTypesExists(string id)
        {
            return _context.AllowanceTypes.Any(e => e.Id == id);
        }
    }
}
