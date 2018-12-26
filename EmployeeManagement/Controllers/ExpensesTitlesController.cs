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
    [Route("api/ExpensesTitles")]
    public class ExpensesTitlesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public ExpensesTitlesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/ExpensesTitles
        [HttpGet]
        public IEnumerable<ExpensesTitle> GetExpensesTitle()
        {
            return _context.ExpensesTitle;
        }

        // GET: api/ExpensesTitles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpensesTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expensesTitle = await _context.ExpensesTitle.SingleOrDefaultAsync(m => m.ExpensesId == id);

            if (expensesTitle == null)
            {
                return NotFound();
            }

            return Ok(expensesTitle);
        }

        // PUT: api/ExpensesTitles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpensesTitle([FromRoute] int id, [FromBody] ExpensesTitle expensesTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expensesTitle.ExpensesId)
            {
                return BadRequest();
            }

            _context.Entry(expensesTitle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesTitleExists(id))
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

        // POST: api/ExpensesTitles
        [HttpPost]
        public async Task<IActionResult> PostExpensesTitle([FromBody] ExpensesTitle expensesTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExpensesTitle.Add(expensesTitle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpensesTitle", new { id = expensesTitle.ExpensesId }, expensesTitle);
        }

        // DELETE: api/ExpensesTitles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpensesTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expensesTitle = await _context.ExpensesTitle.SingleOrDefaultAsync(m => m.ExpensesId == id);
            if (expensesTitle == null)
            {
                return NotFound();
            }

            _context.ExpensesTitle.Remove(expensesTitle);
            await _context.SaveChangesAsync();

            return Ok(expensesTitle);
        }

        private bool ExpensesTitleExists(int id)
        {
            return _context.ExpensesTitle.Any(e => e.ExpensesId == id);
        }
    }
}