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
           
            return await _context.FortuneTellers.ToListAsync();
        }
        [AllowAnonymous]
        [HttpGet("~/GetFortuneTellersByFortuneType")]
        public async Task<ActionResult<IEnumerable<FortuneTeller>>> GetFortuneTellersByFortuneType(FortuneType fortuneType)
        {
            try { 
            if (_context.FortuneTellers == null)
            {
                return NotFound();
            }
            switch ((int)fortuneType)
            {
                case 1:
                    return await _context.FortuneTellers.AsQueryable().Where(x => x.Coffee == true).ToListAsync();
                case 21:
                    return await _context.FortuneTellers.AsQueryable().Where(x => x.Tarot == true).ToListAsync();
                case 3:
                    return await _context.FortuneTellers.AsQueryable().Where(x => x.Water == true).ToListAsync();
                case 4:
                    return await _context.FortuneTellers.AsQueryable().Where(x => x.Birthmap == true).ToListAsync();
                case 5:
                    return await _context.FortuneTellers.AsQueryable().Where(x => x.PlayingCard == true).ToListAsync();

            }
            return await _context.FortuneTellers.ToListAsync();
            }catch (Exception ex)
            {
                return NotFound();
            }
        }
        // GET: api/FortuneTellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FortuneTeller>> GetFortuneTeller(int id)
        {
            var fortuneTeller = await _context.FortuneTellers.FindAsync(id);

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
        public async Task<ActionResult<FortuneTeller>> PostFortuneTeller(FortuneTeller fortuneTeller)
        {
            _context.FortuneTellers.Add(fortuneTeller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFortuneTeller", new { id = fortuneTeller.Id }, fortuneTeller);
        }

        // DELETE: api/FortuneTellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFortuneTeller(int id)
        {
            var fortuneTeller = await _context.FortuneTellers.FindAsync(id);
            if (fortuneTeller == null)
            {
                return NotFound();
            }

            _context.FortuneTellers.Remove(fortuneTeller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FortuneTellerExists(int id)
        {
            return _context.FortuneTellers.Any(e => e.Id == id);
        }

      
    }
}
