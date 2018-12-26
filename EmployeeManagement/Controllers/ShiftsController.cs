﻿using System;
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
    [Route("api/Shifts")]
    public class ShiftsController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public ShiftsController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/Shifts
        [HttpGet]
        public IEnumerable<Shift> GetShift()
        {
            return _context.Shift;
        }

        // GET: api/Shifts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShift([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shift = await _context.Shift.SingleOrDefaultAsync(m => m.ShiftId == id);

            if (shift == null)
            {
                return NotFound();
            }

            return Ok(shift);
        }

        // PUT: api/Shifts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShift([FromRoute] int id, [FromBody] Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shift.ShiftId)
            {
                return BadRequest();
            }

            _context.Entry(shift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(id))
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

        // POST: api/Shifts
        [HttpPost]
        public async Task<IActionResult> PostShift([FromBody] Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Shift.Add(shift);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShift", new { id = shift.ShiftId }, shift);
        }

        // DELETE: api/Shifts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShift([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shift = await _context.Shift.SingleOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return NotFound();
            }

            _context.Shift.Remove(shift);
            await _context.SaveChangesAsync();

            return Ok(shift);
        }

        private bool ShiftExists(int id)
        {
            return _context.Shift.Any(e => e.ShiftId == id);
        }
    }
}