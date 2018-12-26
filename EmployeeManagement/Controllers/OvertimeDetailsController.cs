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
    [Route("api/OvertimeDetails")]
    public class OvertimeDetailsController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public OvertimeDetailsController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/OvertimeDetails
        [HttpGet]
        public IEnumerable<OvertimeDetails> GetOvertimeDetails()
        {
            return _context.OvertimeDetails;
        }

        // GET: api/OvertimeDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOvertimeDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var overtimeDetails = await _context.OvertimeDetails.SingleOrDefaultAsync(m => m.OvertimeDetailsId == id);

            if (overtimeDetails == null)
            {
                return NotFound();
            }

            return Ok(overtimeDetails);
        }

        // PUT: api/OvertimeDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOvertimeDetails([FromRoute] int id, [FromBody] OvertimeDetails overtimeDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != overtimeDetails.OvertimeDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(overtimeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OvertimeDetailsExists(id))
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

        // POST: api/OvertimeDetails
        [HttpPost]
        public async Task<IActionResult> PostOvertimeDetails([FromBody] OvertimeDetails overtimeDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OvertimeDetails.Add(overtimeDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOvertimeDetails", new { id = overtimeDetails.OvertimeDetailsId }, overtimeDetails);
        }

        // DELETE: api/OvertimeDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOvertimeDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var overtimeDetails = await _context.OvertimeDetails.SingleOrDefaultAsync(m => m.OvertimeDetailsId == id);
            if (overtimeDetails == null)
            {
                return NotFound();
            }

            _context.OvertimeDetails.Remove(overtimeDetails);
            await _context.SaveChangesAsync();

            return Ok(overtimeDetails);
        }

        private bool OvertimeDetailsExists(int id)
        {
            return _context.OvertimeDetails.Any(e => e.OvertimeDetailsId == id);
        }
    }
}