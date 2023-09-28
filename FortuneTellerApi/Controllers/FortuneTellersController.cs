using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FortuneTellerApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace FortuneTellerApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FortuneTellersController : ControllerBase
    {
        private readonly APIDbContext _context;

        public FortuneTellersController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/FortuneTellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FortuneTeller>>> GetFortuneTellers()
        {
          if (_context.FortuneTellers == null)
          {
              return NotFound();
          }
            return await _context.FortuneTellers.ToListAsync();
        }

        // GET: api/FortuneTellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FortuneTeller>> GetFortuneTeller(int userId)
        {
          if (_context.FortuneTellers == null)
          {
              return NotFound();
          }
            var fortuneTeller =  _context.FortuneTellers?.FirstOrDefault(e => e.UserId == userId);

            if (fortuneTeller == null)
            {
                return NotFound();
            }

            return fortuneTeller;
        }

        // PUT: api/FortuneTellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFortuneTeller(int id, FortuneTeller fortuneTeller)
        {
            if (id != fortuneTeller.Id)
            {
                return BadRequest();
            }

            _context.Entry(fortuneTeller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FortuneTellerExists(id))
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

        // POST: api/FortuneTellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FortuneTeller>> AddFortuneTeller(FortuneTeller fortuneTeller)
        {
          if (_context.FortuneTellers == null)
          {
              return Problem("Entity set 'APIDbContext.FortuneTellers'  is null.");
          }
            _context.FortuneTellers.Add(fortuneTeller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFortuneTeller", new { UserId = fortuneTeller.UserId }, fortuneTeller);
        }

        // DELETE: api/FortuneTellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFortuneTeller(int id)
        {
            if (_context.FortuneTellers == null)
            {
                return NotFound();
            }
            var fortuneTeller = await _context.FortuneTellers.FindAsync(id);
            if (fortuneTeller == null)
            {
                return NotFound();
            }

            _context.FortuneTellers.Remove(fortuneTeller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FortuneTellerExists(int userId)
        {
            return (_context.FortuneTellers?.Any(e => e.UserId == userId)).GetValueOrDefault();
        }
    }
}
