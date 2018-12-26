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
    [Route("api/PaymentModes")]
    public class PaymentModesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public PaymentModesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/PaymentModes
        [HttpGet]
        public IEnumerable<PaymentMode> GetPaymentMode()
        {
            return _context.PaymentMode;
        }

        // GET: api/PaymentModes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentMode([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentMode = await _context.PaymentMode.SingleOrDefaultAsync(m => m.PaymentTypeId == id);

            if (paymentMode == null)
            {
                return NotFound();
            }

            return Ok(paymentMode);
        }

        // PUT: api/PaymentModes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMode([FromRoute] int id, [FromBody] PaymentMode paymentMode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentMode.PaymentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(paymentMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentModeExists(id))
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

        // POST: api/PaymentModes
        [HttpPost]
        public async Task<IActionResult> PostPaymentMode([FromBody] PaymentMode paymentMode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentMode.Add(paymentMode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentMode", new { id = paymentMode.PaymentTypeId }, paymentMode);
        }

        // DELETE: api/PaymentModes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMode([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentMode = await _context.PaymentMode.SingleOrDefaultAsync(m => m.PaymentTypeId == id);
            if (paymentMode == null)
            {
                return NotFound();
            }

            _context.PaymentMode.Remove(paymentMode);
            await _context.SaveChangesAsync();

            return Ok(paymentMode);
        }

        private bool PaymentModeExists(int id)
        {
            return _context.PaymentMode.Any(e => e.PaymentTypeId == id);
        }
    }
}