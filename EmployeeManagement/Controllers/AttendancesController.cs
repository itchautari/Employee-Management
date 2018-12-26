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
    [Route("api/Attendances")]
    public class AttendancesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public AttendancesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/Attendances
        [HttpGet]
        public IEnumerable<Attendance> GetAttendance()
        {
            return _context.Attendance;
        }

        // GET: api/Attendances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendance = await _context.Attendance.SingleOrDefaultAsync(m => m.AttendanceId == id);

            if (attendance == null)
            {
                return NotFound();
            }

            return Ok(attendance);
        }

        // PUT: api/Attendances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance([FromRoute] int id, [FromBody] Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendance.AttendanceId)
            {
                return BadRequest();
            }

            _context.Entry(attendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(id))
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

        // POST: api/Attendances
        [HttpPost]
        public async Task<IActionResult> PostAttendance([FromBody] Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Attendance.Add(attendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendance", new { id = attendance.AttendanceId }, attendance);
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendance = await _context.Attendance.SingleOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            _context.Attendance.Remove(attendance);
            await _context.SaveChangesAsync();

            return Ok(attendance);
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendance.Any(e => e.AttendanceId == id);
        }
    }
}