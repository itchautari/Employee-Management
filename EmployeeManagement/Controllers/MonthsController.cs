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
    [Route("api/Months")]
    public class MonthsController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public MonthsController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/Months
        [HttpGet]
        public IEnumerable<Months> GetMonths()
        {
            return _context.Months;
        }

        // GET: api/Months/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonths([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var months = await _context.Months.SingleOrDefaultAsync(m => m.MonthId == id);

            if (months == null)
            {
                return NotFound();
            }

            return Ok(months);
        }

        // PUT: api/Months/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonths([FromRoute] int id, [FromBody] Months months)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != months.MonthId)
            {
                return BadRequest();
            }

            _context.Entry(months).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthsExists(id))
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

        // POST: api/Months
        [HttpPost]
        public async Task<IActionResult> PostMonths([FromBody] Months months)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Months.Add(months);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonths", new { id = months.MonthId }, months);
        }

        // DELETE: api/Months/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonths([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var months = await _context.Months.SingleOrDefaultAsync(m => m.MonthId == id);
            if (months == null)
            {
                return NotFound();
            }

            _context.Months.Remove(months);
            await _context.SaveChangesAsync();

            return Ok(months);
        }

        private bool MonthsExists(int id)
        {
            return _context.Months.Any(e => e.MonthId == id);
        }
    }
}