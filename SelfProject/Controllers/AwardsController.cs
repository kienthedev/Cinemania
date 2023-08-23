using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfProjectDataAccess.Models;

namespace SelfProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardsController : ControllerBase
    {
        private readonly SelfProjectContext _context;

        public AwardsController(SelfProjectContext context)
        {
            _context = context;
        }

        // GET: api/Awards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Award>>> GetAwards()
        {
          if (_context.Awards == null)
          {
              return NotFound();
          }
            return await _context.Awards.ToListAsync();
        }

        // GET: api/Awards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Award>> GetAward(int id)
        {
          if (_context.Awards == null)
          {
              return NotFound();
          }
            var award = await _context.Awards.FindAsync(id);

            if (award == null)
            {
                return NotFound();
            }

            return award;
        }

        // PUT: api/Awards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAward(int id, Award award)
        {
            if (id != award.AwardId)
            {
                return BadRequest();
            }

            _context.Entry(award).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwardExists(id))
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

        // POST: api/Awards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Award>> PostAward(Award award)
        {
          if (_context.Awards == null)
          {
              return Problem("Entity set 'SelfProjectContext.Awards'  is null.");
          }
            _context.Awards.Add(award);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AwardExists(award.AwardId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAward", new { id = award.AwardId }, award);
        }

        // DELETE: api/Awards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAward(int id)
        {
            if (_context.Awards == null)
            {
                return NotFound();
            }
            var award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AwardExists(int id)
        {
            return (_context.Awards?.Any(e => e.AwardId == id)).GetValueOrDefault();
        }
    }
}
