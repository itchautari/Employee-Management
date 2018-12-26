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
    [Route("api/HolidayInfoes")]
    public class HolidayInfoesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public HolidayInfoesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/HolidayInfoes
        [HttpGet]
        public IEnumerable<HolidayInfo> GetHolidayInfo()
        {
            return _context.HolidayInfo;
        }

        // GET: api/HolidayInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHolidayInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var holidayInfo = await _context.HolidayInfo.SingleOrDefaultAsync(m => m.HolidayInfoId == id);

            if (holidayInfo == null)
            {
                return NotFound();
            }

            return Ok(holidayInfo);
        }

        // PUT: api/HolidayInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidayInfo([FromRoute] int id, [FromBody] HolidayInfo holidayInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != holidayInfo.HolidayInfoId)
            {
                return BadRequest();
            }

            _context.Entry(holidayInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidayInfoExists(id))
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

        // POST: api/HolidayInfoes
        [HttpPost]
        public async Task<IActionResult> PostHolidayInfo([FromBody] HolidayInfo holidayInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HolidayInfo.Add(holidayInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHolidayInfo", new { id = holidayInfo.HolidayInfoId }, holidayInfo);
        }

        // DELETE: api/HolidayInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var holidayInfo = await _context.HolidayInfo.SingleOrDefaultAsync(m => m.HolidayInfoId == id);
            if (holidayInfo == null)
            {
                return NotFound();
            }

            _context.HolidayInfo.Remove(holidayInfo);
            await _context.SaveChangesAsync();

            return Ok(holidayInfo);
        }

        private bool HolidayInfoExists(int id)
        {
            return _context.HolidayInfo.Any(e => e.HolidayInfoId == id);
        }
    }
}