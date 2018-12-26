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
    [Route("api/OvertimeSetUps")]
    public class OvertimeSetUpsController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public OvertimeSetUpsController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/OvertimeSetUps
        [HttpGet]
        public IEnumerable<OvertimeSetUp> GetOvertimeSetUp()
        {
            return _context.OvertimeSetUp;
        }

        // GET: api/OvertimeSetUps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOvertimeSetUp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var overtimeSetUp = await _context.OvertimeSetUp.SingleOrDefaultAsync(m => m.OvertimeSetUpId == id);

            if (overtimeSetUp == null)
            {
                return NotFound();
            }

            return Ok(overtimeSetUp);
        }

        // PUT: api/OvertimeSetUps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOvertimeSetUp([FromRoute] int id, [FromBody] OvertimeSetUp overtimeSetUp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != overtimeSetUp.OvertimeSetUpId)
            {
                return BadRequest();
            }

            _context.Entry(overtimeSetUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OvertimeSetUpExists(id))
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

        // POST: api/OvertimeSetUps
        [HttpPost]
        public async Task<IActionResult> PostOvertimeSetUp([FromBody] OvertimeSetUp overtimeSetUp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OvertimeSetUp.Add(overtimeSetUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOvertimeSetUp", new { id = overtimeSetUp.OvertimeSetUpId }, overtimeSetUp);
        }

        // DELETE: api/OvertimeSetUps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOvertimeSetUp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var overtimeSetUp = await _context.OvertimeSetUp.SingleOrDefaultAsync(m => m.OvertimeSetUpId == id);
            if (overtimeSetUp == null)
            {
                return NotFound();
            }

            _context.OvertimeSetUp.Remove(overtimeSetUp);
            await _context.SaveChangesAsync();

            return Ok(overtimeSetUp);
        }

        private bool OvertimeSetUpExists(int id)
        {
            return _context.OvertimeSetUp.Any(e => e.OvertimeSetUpId == id);
        }
    }
}