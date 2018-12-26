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
    [Route("api/HolidayTypes")]
    public class HolidayTypesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public HolidayTypesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/HolidayTypes
        [HttpGet]
        public IEnumerable<HolidayType> GetHolidayType()
        {
            return _context.HolidayType;
        }

        // GET: api/HolidayTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHolidayType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var holidayType = await _context.HolidayType.SingleOrDefaultAsync(m => m.HolidayTypeId == id);

            if (holidayType == null)
            {
                return NotFound();
            }

            return Ok(holidayType);
        }

        // PUT: api/HolidayTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidayType([FromRoute] int id, [FromBody] HolidayType holidayType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != holidayType.HolidayTypeId)
            {
                return BadRequest();
            }

            _context.Entry(holidayType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidayTypeExists(id))
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

        // POST: api/HolidayTypes
        [HttpPost]
        public async Task<IActionResult> PostHolidayType([FromBody] HolidayType holidayType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HolidayType.Add(holidayType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHolidayType", new { id = holidayType.HolidayTypeId }, holidayType);
        }

        // DELETE: api/HolidayTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var holidayType = await _context.HolidayType.SingleOrDefaultAsync(m => m.HolidayTypeId == id);
            if (holidayType == null)
            {
                return NotFound();
            }

            _context.HolidayType.Remove(holidayType);
            await _context.SaveChangesAsync();

            return Ok(holidayType);
        }

        private bool HolidayTypeExists(int id)
        {
            return _context.HolidayType.Any(e => e.HolidayTypeId == id);
        }
    }
}