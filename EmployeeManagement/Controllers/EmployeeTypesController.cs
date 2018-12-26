using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/EmployeeTypes")]
    public class EmployeeTypesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public EmployeeTypesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeTypes
        [HttpGet]
        public IEnumerable<EmployeeType> GetEmployeeType()
        {
            return _context.EmployeeType;
        }

        // GET: api/EmployeeTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeType = await _context.EmployeeType.SingleOrDefaultAsync(m => m.EmployeeTypeId == id);

            if (employeeType == null)
            {
                return NotFound();
            }

            return Ok(employeeType);
        }

        // PUT: api/EmployeeTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeType([FromRoute] int id, [FromBody] EmployeeType employeeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeType.EmployeeTypeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTypeExists(id))
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

        // POST: api/EmployeeTypes
        [HttpPost]
        public async Task<IActionResult> PostEmployeeType([FromBody] EmployeeType employeeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeeType.Add(employeeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeType", new { id = employeeType.EmployeeTypeId }, employeeType);
        }

        // DELETE: api/EmployeeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeType = await _context.EmployeeType.SingleOrDefaultAsync(m => m.EmployeeTypeId == id);
            if (employeeType == null)
            {
                return NotFound();
            }

            _context.EmployeeType.Remove(employeeType);
            await _context.SaveChangesAsync();

            return Ok(employeeType);
        }

        private bool EmployeeTypeExists(int id)
        {
            return _context.EmployeeType.Any(e => e.EmployeeTypeId == id);
        }
    }
}