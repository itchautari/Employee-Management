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
    [Route("api/SalaryAttributes")]
    public class SalaryAttributesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public SalaryAttributesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/SalaryAttributes
        [HttpGet]
        public IEnumerable<SalaryAttribute> GetSalaryAttribute()
        {
            return _context.SalaryAttribute;
        }

        // GET: api/SalaryAttributes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalaryAttribute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salaryAttribute = await _context.SalaryAttribute.SingleOrDefaultAsync(m => m.SalaryAttributeId == id);

            if (salaryAttribute == null)
            {
                return NotFound();
            }

            return Ok(salaryAttribute);
        }

        // PUT: api/SalaryAttributes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryAttribute([FromRoute] int id, [FromBody] SalaryAttribute salaryAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salaryAttribute.SalaryAttributeId)
            {
                return BadRequest();
            }

            _context.Entry(salaryAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryAttributeExists(id))
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

        // POST: api/SalaryAttributes
        [HttpPost]
        public async Task<IActionResult> PostSalaryAttribute([FromBody] SalaryAttribute salaryAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SalaryAttribute.Add(salaryAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalaryAttribute", new { id = salaryAttribute.SalaryAttributeId }, salaryAttribute);
        }

        // DELETE: api/SalaryAttributes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryAttribute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salaryAttribute = await _context.SalaryAttribute.SingleOrDefaultAsync(m => m.SalaryAttributeId == id);
            if (salaryAttribute == null)
            {
                return NotFound();
            }

            _context.SalaryAttribute.Remove(salaryAttribute);
            await _context.SaveChangesAsync();

            return Ok(salaryAttribute);
        }

        private bool SalaryAttributeExists(int id)
        {
            return _context.SalaryAttribute.Any(e => e.SalaryAttributeId == id);
        }
    }
}