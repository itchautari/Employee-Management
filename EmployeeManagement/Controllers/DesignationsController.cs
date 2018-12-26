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
    [Route("api/Designations")]
    public class DesignationsController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public DesignationsController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/Designations
        [HttpGet]
        public IEnumerable<Designation> GetDesignation()
        {
            return _context.Designation;
        }

        // GET: api/Designations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesignation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var designation = await _context.Designation.SingleOrDefaultAsync(m => m.DesignationId == id);

            if (designation == null)
            {
                return NotFound();
            }

            return Ok(designation);
        }

        // PUT: api/Designations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignation([FromRoute] int id, [FromBody] Designation designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != designation.DesignationId)
            {
                return BadRequest();
            }

            _context.Entry(designation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationExists(id))
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

        // POST: api/Designations
        [HttpPost]
        public async Task<IActionResult> PostDesignation([FromBody] Designation designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Designation.Add(designation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignation", new { id = designation.DesignationId }, designation);
        }

        // DELETE: api/Designations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var designation = await _context.Designation.SingleOrDefaultAsync(m => m.DesignationId == id);
            if (designation == null)
            {
                return NotFound();
            }

            _context.Designation.Remove(designation);
            await _context.SaveChangesAsync();

            return Ok(designation);
        }

        private bool DesignationExists(int id)
        {
            return _context.Designation.Any(e => e.DesignationId == id);
        }
    }
}