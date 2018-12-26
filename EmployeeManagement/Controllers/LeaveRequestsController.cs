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
    [Route("api/LeaveRequests")]
    public class LeaveRequestsController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public LeaveRequestsController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/LeaveRequests
        [HttpGet]
        public IEnumerable<LeaveRequest> GetLeaveRequest()
        {
            return _context.LeaveRequest;
        }

        // GET: api/LeaveRequests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveRequest = await _context.LeaveRequest.SingleOrDefaultAsync(m => m.LeaveRequestId == id);

            if (leaveRequest == null)
            {
                return NotFound();
            }

            return Ok(leaveRequest);
        }

        // PUT: api/LeaveRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveRequest([FromRoute] int id, [FromBody] LeaveRequest leaveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leaveRequest.LeaveRequestId)
            {
                return BadRequest();
            }

            _context.Entry(leaveRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRequestExists(id))
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

        // POST: api/LeaveRequests
        [HttpPost]
        public async Task<IActionResult> PostLeaveRequest([FromBody] LeaveRequest leaveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeaveRequest.Add(leaveRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveRequest", new { id = leaveRequest.LeaveRequestId }, leaveRequest);
        }

        // DELETE: api/LeaveRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveRequest = await _context.LeaveRequest.SingleOrDefaultAsync(m => m.LeaveRequestId == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            _context.LeaveRequest.Remove(leaveRequest);
            await _context.SaveChangesAsync();

            return Ok(leaveRequest);
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequest.Any(e => e.LeaveRequestId == id);
        }
    }
}