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
    [Route("api/ManagerInfoes")]
    public class ManagerInfoesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public ManagerInfoesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/ManagerInfoes
        [HttpGet]
        public IEnumerable<ManagerInfo> GetManagerInfo()
        {
            return _context.ManagerInfo;
        }

        // GET: api/ManagerInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManagerInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managerInfo = await _context.ManagerInfo.SingleOrDefaultAsync(m => m.ManagerInfoId == id);

            if (managerInfo == null)
            {
                return NotFound();
            }

            return Ok(managerInfo);
        }

        // PUT: api/ManagerInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagerInfo([FromRoute] int id, [FromBody] ManagerInfo managerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != managerInfo.ManagerInfoId)
            {
                return BadRequest();
            }

            _context.Entry(managerInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerInfoExists(id))
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

        // POST: api/ManagerInfoes
        [HttpPost]
        public async Task<IActionResult> PostManagerInfo([FromBody] ManagerInfo managerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ManagerInfo.Add(managerInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagerInfo", new { id = managerInfo.ManagerInfoId }, managerInfo);
        }

        // DELETE: api/ManagerInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagerInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managerInfo = await _context.ManagerInfo.SingleOrDefaultAsync(m => m.ManagerInfoId == id);
            if (managerInfo == null)
            {
                return NotFound();
            }

            _context.ManagerInfo.Remove(managerInfo);
            await _context.SaveChangesAsync();

            return Ok(managerInfo);
        }

        private bool ManagerInfoExists(int id)
        {
            return _context.ManagerInfo.Any(e => e.ManagerInfoId == id);
        }
    }
}