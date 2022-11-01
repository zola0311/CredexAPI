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
    public class AllowancesOfEmployeesController : ControllerBase
    {
        private readonly Context _context;

        public AllowancesOfEmployeesController(Context context)
        {
            _context = context;
        }

        // GET: api/AllowancesOfEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllowancesOfEmployees>>> GetAllowancesOfEmployees()
        {
            return await _context.AllowancesOfEmployees.ToListAsync();
        }

        // GET: api/AllowancesOfEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllowancesOfEmployees>> GetAllowancesOfEmployees(int id)
        {
            var allowancesOfEmployees = await _context.AllowancesOfEmployees.FindAsync(id);

            if (allowancesOfEmployees == null)
            {
                return NotFound();
            }

            return allowancesOfEmployees;
        }

        // PUT: api/AllowancesOfEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowancesOfEmployees(int id, AllowancesOfEmployees allowancesOfEmployees)
        {
            if (id != allowancesOfEmployees.Id)
            {
                return BadRequest();
            }

            _context.Entry(allowancesOfEmployees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowancesOfEmployeesExists(id))
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

        // POST: api/AllowancesOfEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AllowancesOfEmployees>> PostAllowancesOfEmployees(AllowancesOfEmployees allowancesOfEmployees)
        {
            _context.AllowancesOfEmployees.Add(allowancesOfEmployees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllowancesOfEmployees", new { id = allowancesOfEmployees.Id }, allowancesOfEmployees);
        }

        // DELETE: api/AllowancesOfEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllowancesOfEmployees(int id)
        {
            var allowancesOfEmployees = await _context.AllowancesOfEmployees.FindAsync(id);
            if (allowancesOfEmployees == null)
            {
                return NotFound();
            }

            _context.AllowancesOfEmployees.Remove(allowancesOfEmployees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllowancesOfEmployeesExists(int id)
        {
            return _context.AllowancesOfEmployees.Any(e => e.Id == id);
        }
    }
}
