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
    [Route("api/OrganizationInfoes")]
    public class OrganizationInfoesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public OrganizationInfoesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationInfoes
        [HttpGet]
        public IEnumerable<OrganizationInfo> GetOrganizationInfo()
        {
            return _context.OrganizationInfo;
        }

        // GET: api/OrganizationInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizationInfo = await _context.OrganizationInfo.SingleOrDefaultAsync(m => m.OrganizationId == id);

            if (organizationInfo == null)
            {
                return NotFound();
            }

            return Ok(organizationInfo);
        }

        // PUT: api/OrganizationInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationInfo([FromRoute] int id, [FromBody] OrganizationInfo organizationInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizationInfo.OrganizationId)
            {
                return BadRequest();
            }

            _context.Entry(organizationInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationInfoExists(id))
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

        // POST: api/OrganizationInfoes
        [HttpPost]
        public async Task<IActionResult> PostOrganizationInfo([FromBody] OrganizationInfo organizationInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrganizationInfo.Add(organizationInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizationInfo", new { id = organizationInfo.OrganizationId }, organizationInfo);
        }

        // DELETE: api/OrganizationInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizationInfo = await _context.OrganizationInfo.SingleOrDefaultAsync(m => m.OrganizationId == id);
            if (organizationInfo == null)
            {
                return NotFound();
            }

            _context.OrganizationInfo.Remove(organizationInfo);
            await _context.SaveChangesAsync();

            return Ok(organizationInfo);
        }

        private bool OrganizationInfoExists(int id)
        {
            return _context.OrganizationInfo.Any(e => e.OrganizationId == id);
        }
    }
}