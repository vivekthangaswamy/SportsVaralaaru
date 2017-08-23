using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsVaralaaruAPI.Models;

namespace SportsVaralaaruAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Sports")]
    public class SportsController : Controller
    {
        private readonly SportsVaralaaruAPIContext _context;

        public SportsController(SportsVaralaaruAPIContext context)
        {
            _context = context;
        }

        // GET: api/Sports
        [HttpGet]
        public IEnumerable<Sports> GetSports()
        {
            return _context.Sports;
        }

        // GET: api/Sports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSports([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sports = await _context.Sports.SingleOrDefaultAsync(m => m.Id == id);

            if (sports == null)
            {
                return NotFound();
            }

            return Ok(sports);
        }

        // PUT: api/Sports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSports([FromRoute] int id, [FromBody] Sports sports)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sports.Id)
            {
                return BadRequest();
            }

            _context.Entry(sports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportsExists(id))
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

        // POST: api/Sports
        [HttpPost]
        public async Task<IActionResult> PostSports([FromBody] Sports sports)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sports.Add(sports);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSports", new { id = sports.Id }, sports);
        }

        // DELETE: api/Sports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSports([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sports = await _context.Sports.SingleOrDefaultAsync(m => m.Id == id);
            if (sports == null)
            {
                return NotFound();
            }

            _context.Sports.Remove(sports);
            await _context.SaveChangesAsync();

            return Ok(sports);
        }

        private bool SportsExists(int id)
        {
            return _context.Sports.Any(e => e.Id == id);
        }
    }
}