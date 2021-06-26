using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OFERTALABORAL_WEB_API.Models;

namespace OFERTALABORAL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaLaboraltwoController : ControllerBase
    {
        private readonly ReclutamientoDBContext _context;

        public OfertaLaboraltwoController(ReclutamientoDBContext context)
        {
            _context = context;
        }

        // GET: api/OfertaLaboraltwo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfertaLaboral>>> GetOfertaLaboral()
        {
            return await _context.OfertaLaboral.ToListAsync();
        }

        // GET: api/OfertaLaboraltwo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfertaLaboral>> GetOfertaLaboral(int id)
        {
            var ofertaLaboral = await _context.OfertaLaboral.FindAsync(id);

            if (ofertaLaboral == null)
            {
                return NotFound();
            }

            return ofertaLaboral;
        }

        // PUT: api/OfertaLaboraltwo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfertaLaboral(int id, OfertaLaboral ofertaLaboral)
        {
            if (id != ofertaLaboral.Id)
            {
                return BadRequest();
            }

            _context.Entry(ofertaLaboral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaLaboralExists(id))
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

        // POST: api/OfertaLaboraltwo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfertaLaboral>> PostOfertaLaboral(OfertaLaboral ofertaLaboral)
        {
            _context.OfertaLaboral.Add(ofertaLaboral);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfertaLaboral", new { id = ofertaLaboral.Id }, ofertaLaboral);
        }

        // DELETE: api/OfertaLaboraltwo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfertaLaboral(int id)
        {
            var ofertaLaboral = await _context.OfertaLaboral.FindAsync(id);
            if (ofertaLaboral == null)
            {
                return NotFound();
            }

            _context.OfertaLaboral.Remove(ofertaLaboral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertaLaboralExists(int id)
        {
            return _context.OfertaLaboral.Any(e => e.Id == id);
        }
    }
}
