using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CredexAPI.Models;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace CredexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Context _context;

        public EmployeesController(Context context)
        {
            _context = context;
        }

        [HttpGet("getDeletedEmployees")]
        public async Task<ActionResult<IEnumerable<Employees>>> GetDeletedEmplyoees()
        {
            return await _context.Employees.Where(x => x.IsDeleted == true).Include(x => x.Genders).Include(x => x.Jobs).Include(x => x.Statuses).Include(x => x.AllowancesOfEmployees).ThenInclude(x => x.AllowanceTypes).ToListAsync();
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            return await _context.Employees.Include(x => x.Genders).Include(x => x.Jobs).Include(x => x.Statuses).Where(x => x.IsDeleted == false).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(int id)
        {
            var employees = await _context.Employees.Include(x => x.Genders).Include(x => x.Jobs).Include(x => x.Statuses).Include(x => x.AllowancesOfEmployees).ThenInclude(x => x.AllowanceTypes).Where(x => x.EmployeeId == id).FirstOrDefaultAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees(int id, EmployeeAndAllowancesOfEmployees employeeAndAllowancesOfEmployees)
        {
            if (id != employeeAndAllowancesOfEmployees.Employee.EmployeeId)
            {
                return BadRequest();
            }

            try
            {
                _context.Employees.Update(employeeAndAllowancesOfEmployees.Employee);
                await _context.SaveChangesAsync();

                var oldAllowancesOfEmployees = await _context.AllowancesOfEmployees.Where(x => x.EmployeeId == employeeAndAllowancesOfEmployees.Employee.EmployeeId).ToListAsync();

                foreach (var oldAllowance in oldAllowancesOfEmployees)
                {
                    _context.AllowancesOfEmployees.Remove(oldAllowance);
                    await _context.SaveChangesAsync();
                }

                foreach (var allowance in employeeAndAllowancesOfEmployees.AllowancesOfEmployees)
                {
                    _context.AllowancesOfEmployees.Add(allowance);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
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

        [HttpPut("restoreEmployee/{employeeId}")]
        public async Task<IActionResult> RestoreEmployee(int employeeId, Employees employees)
        {
            if(employeeId != employees.EmployeeId)
            {
                return BadRequest();
            }

            try
            {

                if(employees != null)
                {
                    _context.Employees.Update(employees);
                    await _context.SaveChangesAsync();
                }
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("deleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId, Employees employees)
        {
            if (employeeId != employees.EmployeeId)
            {
                return BadRequest();
            }

            try
            {

                if (employees != null)
                {
                    _context.Employees.Update(employees);
                    await _context.SaveChangesAsync();
                }
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees(Employees employees)
        {
            _context.Employees.Add(employees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployees", new { id = employees.EmployeeId }, employees);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
