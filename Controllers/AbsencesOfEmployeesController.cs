﻿using CredexAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CredexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsencesOfEmployeesController : ControllerBase
    {
        private readonly Context _context;

        public AbsencesOfEmployeesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbsencesOfEmployees>>> GetAllAbsencesOfEmployees()
        {
            return await _context.AbsencesOfEmployees.Include(x => x.AbsenceTypes).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AbsencesOfEmployees>> GetAbsenceOfEmployees(int id)
        {
            return await _context.AbsencesOfEmployees.Include(x => x.AbsenceTypes).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        [HttpGet("getEmployeeAbsences/{id}")]
        public async Task<ActionResult<IEnumerable<AbsencesOfEmployees>>> GetEmployeeAbsences(int id)
        {
            return await _context.AbsencesOfEmployees.Include(x => x.AbsenceTypes).Where(x => x.EmployeeId == id).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbsenceOfEmployees(int id, AbsencesOfEmployees absencesOfEmployees)
        {
            if(id != absencesOfEmployees.Id)
            {
                return BadRequest();
            }

            if(!AbsenceOfEmployeesExists(absencesOfEmployees.Id))
            {
                return NotFound();
            }

            _context.AbsencesOfEmployees.Update(absencesOfEmployees);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<AbsencesOfEmployees>> PostAbsencesOfEmployees(AbsencesOfEmployees absencesOfEmployees)
        {
            _context.AbsencesOfEmployees.Add(absencesOfEmployees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbsencesOfEmployees", new { id = absencesOfEmployees.Id }, absencesOfEmployees);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsencesOfEmployees(int id)
        {
            var absencesOfEmployees = await _context.AbsencesOfEmployees.FindAsync(id);

            if(absencesOfEmployees == null)
            {
                return NotFound();
            }

            _context.AbsencesOfEmployees.Remove(absencesOfEmployees);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AbsenceOfEmployeesExists(int id)
        {
            return _context.AbsencesOfEmployees.Any(x => x.Id == id);
        }
    }
}
