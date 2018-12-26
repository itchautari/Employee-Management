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
    [Route("api/LeaveInfoes")]
    public class LeaveInfoesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public LeaveInfoesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/LeaveInfoes
        [HttpGet]
        public IEnumerable<LeaveInfo> GetLeaveInfo()
        {
            return _context.LeaveInfo;
        }

        // GET: api/LeaveInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveInfo = await _context.LeaveInfo.SingleOrDefaultAsync(m => m.LeaveInfoId == id);

            if (leaveInfo == null)
            {
                return NotFound();
            }

            return Ok(leaveInfo);
        }

        // PUT: api/LeaveInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveInfo([FromRoute] int id, [FromBody] LeaveInfo leaveInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leaveInfo.LeaveInfoId)
            {
                return BadRequest();
            }

            _context.Entry(leaveInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveInfoExists(id))
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

        // POST: api/LeaveInfoes
        [HttpPost]
        public async Task<IActionResult> PostLeaveInfo([FromBody] LeaveInfo leaveInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeaveInfo.Add(leaveInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveInfo", new { id = leaveInfo.LeaveInfoId }, leaveInfo);
        }

        // DELETE: api/LeaveInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveInfo = await _context.LeaveInfo.SingleOrDefaultAsync(m => m.LeaveInfoId == id);
            if (leaveInfo == null)
            {
                return NotFound();
            }

            _context.LeaveInfo.Remove(leaveInfo);
            await _context.SaveChangesAsync();

            return Ok(leaveInfo);
        }

        private bool LeaveInfoExists(int id)
        {
            return _context.LeaveInfo.Any(e => e.LeaveInfoId == id);
        }
    }
}