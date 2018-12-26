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
    [Route("api/Branches")]
    public class BranchesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public BranchesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/Branches
        [HttpGet]
        public IEnumerable<Branch> GetBranch()
        {
            return _context.Branch;
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branch = await _context.Branch.SingleOrDefaultAsync(m => m.BranchId == id);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        // PUT: api/Branches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch([FromRoute] int id, [FromBody] Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branch.BranchId)
            {
                return BadRequest();
            }

            _context.Entry(branch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
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

        // POST: api/Branches
        [HttpPost]
        public async Task<IActionResult> PostBranch([FromBody] Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Branch.Add(branch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranch", new { id = branch.BranchId }, branch);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branch = await _context.Branch.SingleOrDefaultAsync(m => m.BranchId == id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();

            return Ok(branch);
        }

        private bool BranchExists(int id)
        {
            return _context.Branch.Any(e => e.BranchId == id);
        }
    }
}