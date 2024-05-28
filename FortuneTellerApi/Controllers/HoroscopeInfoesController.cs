using Microsoft.AspNetCore.Mvc;
using FortuneTellerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FortuneTellerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoroscopeInfoesController : ControllerBase
    {
        private readonly APIDbContext _context;

        public HoroscopeInfoesController(APIDbContext context)
        {
            _context = context;
        }



        // GET: api/HoroscopeInfoes/5
        [HttpGet]
        public async Task<ActionResult<List<HoroscopeInfo>>> GetHoroscopeInfo(HoroscopeSign sign)
        {
          if (_context.HoroscopeInfos == null)
          {
              return NotFound();
          }
            List<HoroscopeInfo> horoscopeInfo = await _context.HoroscopeInfos.Where(x =>x.HoroscopeSign == sign).ToListAsync();

            if (horoscopeInfo == null)
            {
                return NotFound();
            }

            return horoscopeInfo;
        }

        // PUT: api/HoroscopeInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoroscopeInfo(int id, HoroscopeInfo horoscopeInfo)
        {
            if (id != horoscopeInfo.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(horoscopeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoroscopeInfoExists(id))
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

        // POST: api/HoroscopeInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoroscopeInfo>> PostHoroscopeInfo(HoroscopeInfo horoscopeInfo)
        {
          if (_context.HoroscopeInfos == null)
          {
              return Problem("Entity set 'APIDbContext.HoroscopeInfos'  is null.");
          }
            _context.HoroscopeInfos.Add(horoscopeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoroscopeInfo", new { id = horoscopeInfo.MessageId }, horoscopeInfo);
        }

        // DELETE: api/HoroscopeInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoroscopeInfo(int id)
        {
            if (_context.HoroscopeInfos == null)
            {
                return NotFound();
            }
            var horoscopeInfo = await _context.HoroscopeInfos.FindAsync(id);
            if (horoscopeInfo == null)
            {
                return NotFound();
            }

            _context.HoroscopeInfos.Remove(horoscopeInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoroscopeInfoExists(int id)
        {
            return (_context.HoroscopeInfos?.Any(e => e.MessageId == id)).GetValueOrDefault();
        }
    }
}
