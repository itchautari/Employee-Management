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
    [Route("api/ManagerTypes")]
    public class ManagerTypesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public ManagerTypesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/ManagerTypes
        [HttpGet]
        public IEnumerable<ManagerType> GetManagerType()
        {
            return _context.ManagerType;
        }

        // GET: api/ManagerTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManagerType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managerType = await _context.ManagerType.SingleOrDefaultAsync(m => m.ManagerTypeId == id);

            if (managerType == null)
            {
                return NotFound();
            }

            return Ok(managerType);
        }

        // PUT: api/ManagerTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagerType([FromRoute] int id, [FromBody] ManagerType managerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != managerType.ManagerTypeId)
            {
                return BadRequest();
            }

            _context.Entry(managerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerTypeExists(id))
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

        // POST: api/ManagerTypes
        [HttpPost]
        public async Task<IActionResult> PostManagerType([FromBody] ManagerType managerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ManagerType.Add(managerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagerType", new { id = managerType.ManagerTypeId }, managerType);
        }

        // DELETE: api/ManagerTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagerType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managerType = await _context.ManagerType.SingleOrDefaultAsync(m => m.ManagerTypeId == id);
            if (managerType == null)
            {
                return NotFound();
            }

            _context.ManagerType.Remove(managerType);
            await _context.SaveChangesAsync();

            return Ok(managerType);
        }

        private bool ManagerTypeExists(int id)
        {
            return _context.ManagerType.Any(e => e.ManagerTypeId == id);
        }
    }
}