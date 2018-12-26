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
    [Route("api/LeaveTypes")]
    public class LeaveTypesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public LeaveTypesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/LeaveTypes
        [HttpGet]
        public IEnumerable<LeaveType> GetLeaveType()
        {
            return _context.LeaveType;
        }

        // GET: api/LeaveTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveType = await _context.LeaveType.SingleOrDefaultAsync(m => m.LeaveTypeId == id);

            if (leaveType == null)
            {
                return NotFound();
            }

            return Ok(leaveType);
        }

        // PUT: api/LeaveTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveType([FromRoute] int id, [FromBody] LeaveType leaveType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leaveType.LeaveTypeId)
            {
                return BadRequest();
            }

            _context.Entry(leaveType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveTypeExists(id))
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

        // POST: api/LeaveTypes
        [HttpPost]
        public async Task<IActionResult> PostLeaveType([FromBody] LeaveType leaveType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeaveType.Add(leaveType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveType", new { id = leaveType.LeaveTypeId }, leaveType);
        }

        // DELETE: api/LeaveTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveType = await _context.LeaveType.SingleOrDefaultAsync(m => m.LeaveTypeId == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            _context.LeaveType.Remove(leaveType);
            await _context.SaveChangesAsync();

            return Ok(leaveType);
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveType.Any(e => e.LeaveTypeId == id);
        }
    }
}