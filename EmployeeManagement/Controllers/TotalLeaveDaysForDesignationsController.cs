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
    [Route("api/TotalLeaveDaysForDesignations")]
    public class TotalLeaveDaysForDesignationsController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public TotalLeaveDaysForDesignationsController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/TotalLeaveDaysForDesignations
        [HttpGet]
        public IEnumerable<TotalLeaveDaysForDesignation> GetTotalLeaveDaysForDesignation()
        {
            return _context.TotalLeaveDaysForDesignation;
        }

        // GET: api/TotalLeaveDaysForDesignations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTotalLeaveDaysForDesignation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var totalLeaveDaysForDesignation = await _context.TotalLeaveDaysForDesignation.SingleOrDefaultAsync(m => m.Id == id);

            if (totalLeaveDaysForDesignation == null)
            {
                return NotFound();
            }

            return Ok(totalLeaveDaysForDesignation);
        }

        // PUT: api/TotalLeaveDaysForDesignations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTotalLeaveDaysForDesignation([FromRoute] int id, [FromBody] TotalLeaveDaysForDesignation totalLeaveDaysForDesignation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != totalLeaveDaysForDesignation.Id)
            {
                return BadRequest();
            }

            _context.Entry(totalLeaveDaysForDesignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotalLeaveDaysForDesignationExists(id))
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

        // POST: api/TotalLeaveDaysForDesignations
        [HttpPost]
        public async Task<IActionResult> PostTotalLeaveDaysForDesignation([FromBody] TotalLeaveDaysForDesignation totalLeaveDaysForDesignation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TotalLeaveDaysForDesignation.Add(totalLeaveDaysForDesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTotalLeaveDaysForDesignation", new { id = totalLeaveDaysForDesignation.Id }, totalLeaveDaysForDesignation);
        }

        // DELETE: api/TotalLeaveDaysForDesignations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTotalLeaveDaysForDesignation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var totalLeaveDaysForDesignation = await _context.TotalLeaveDaysForDesignation.SingleOrDefaultAsync(m => m.Id == id);
            if (totalLeaveDaysForDesignation == null)
            {
                return NotFound();
            }

            _context.TotalLeaveDaysForDesignation.Remove(totalLeaveDaysForDesignation);
            await _context.SaveChangesAsync();

            return Ok(totalLeaveDaysForDesignation);
        }

        private bool TotalLeaveDaysForDesignationExists(int id)
        {
            return _context.TotalLeaveDaysForDesignation.Any(e => e.Id == id);
        }
    }
}