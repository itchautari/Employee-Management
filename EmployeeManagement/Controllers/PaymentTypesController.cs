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
    [Route("api/PaymentTypes")]
    public class PaymentTypesController : Controller
    {
        private readonly EmployeemanagementContext _context;

        public PaymentTypesController(EmployeemanagementContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTypes
        [HttpGet]
        public IEnumerable<PaymentType> GetPaymentType()
        {
            return _context.PaymentType;
        }

        // GET: api/PaymentTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentType = await _context.PaymentType.SingleOrDefaultAsync(m => m.PaymentTypeId == id);

            if (paymentType == null)
            {
                return NotFound();
            }

            return Ok(paymentType);
        }

        // PUT: api/PaymentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentType([FromRoute] int id, [FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentType.PaymentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(paymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
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

        // POST: api/PaymentTypes
        [HttpPost]
        public async Task<IActionResult> PostPaymentType([FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentType.Add(paymentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentType", new { id = paymentType.PaymentTypeId }, paymentType);
        }

        // DELETE: api/PaymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentType = await _context.PaymentType.SingleOrDefaultAsync(m => m.PaymentTypeId == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            _context.PaymentType.Remove(paymentType);
            await _context.SaveChangesAsync();

            return Ok(paymentType);
        }

        private bool PaymentTypeExists(int id)
        {
            return _context.PaymentType.Any(e => e.PaymentTypeId == id);
        }
    }
}