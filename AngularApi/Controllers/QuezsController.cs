using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace AngularApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class QuezsController : ControllerBase
    {
        private readonly DataContext _context;

        public QuezsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Quezs
        [HttpGet]
        [Authorize]
        public IEnumerable<Quez> GetQuezes()
        {
            var userid = HttpContext.User.Claims.First().Value;
            return _context.Quezes.Where(q=>q.Ownerid==userid);
        }

        // GET: api/Quezs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuez([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quez = await _context.Quezes.FindAsync(id);

            if (quez == null)
            {
                return NotFound();
            }

            return Ok(quez);
        }

        // PUT: api/Quezs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuez([FromRoute] int id, [FromBody] Quez quez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quez.Id)
            {
                return BadRequest();
            }

            _context.Entry(quez).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuezExists(id))
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

        // POST: api/Quezs
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostQuez([FromBody] Quez quez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userid = HttpContext.User.Claims.First().Value;

            quez.Ownerid = userid;
            _context.Quezes.Add(quez);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuez", new { id = quez.Id }, quez);
        }

        // DELETE: api/Quezs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuez([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quez = await _context.locations.FindAsync(id);
            if (quez == null)
            {
                return NotFound();
            }

            _context.locations.Remove(quez);
            await _context.SaveChangesAsync();

            return Ok(quez);
        }

        private bool QuezExists(int id)
        {
            return _context.Quezes.Any(e => e.Id == id);
        }
    }
}