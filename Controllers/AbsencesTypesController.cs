using CredexAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CredexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsencesTypesController : ControllerBase
    {
        private readonly Context _context;

        public AbsencesTypesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbsenceTypes>>> GetAllAbsencesTypes()
        {
            return await _context.AbsenceTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AbsenceTypes>> GetAbsenceType(int id)
        {
            return await _context.AbsenceTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbsenceType(int id, AbsenceTypes absenceTypes)
        {
            if (id != absenceTypes.Id)
            {
                return BadRequest();
            }

            if (!AbsenceTypesExists(absenceTypes.Id))
            {
                return NotFound();
            }

            _context.AbsenceTypes.Update(absenceTypes);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<AbsenceTypes>> PostAbsenceType(AbsenceTypes absenceTypes)
        {
            _context.AbsenceTypes.Add(absenceTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbsenceType", new { id = absenceTypes.Id }, absenceTypes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsenceType(int id)
        {
            var absenceTypes = await _context.AbsenceTypes.FindAsync(id);

            if (absenceTypes == null)
            {
                return NotFound();
            }

            _context.AbsenceTypes.Remove(absenceTypes);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AbsenceTypesExists(int id)
        {
            return _context.AbsenceTypes.Any(x => x.Id == id);
        }
    }
}
