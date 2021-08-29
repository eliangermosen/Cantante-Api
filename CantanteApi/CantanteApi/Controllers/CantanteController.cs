using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CantanteApi.Data;
using CantanteApi.Models;

namespace CantanteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantanteController : ControllerBase
    {
        private readonly CantanteApiContext _context;

        public CantanteController(CantanteApiContext context)
        {
            _context = context;
        }

        // GET: api/Cantante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cantante>>> GetCantante()
        {
            return await _context.Cantante.ToListAsync();
        }

        // GET: api/Cantante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cantante>> GetCantante(int id)
        {
            var cantante = await _context.Cantante.FindAsync(id);

            if (cantante == null)
            {
                return NotFound();
            }

            return cantante;
        }

        // PUT: api/Cantante/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCantante(int id, Cantante cantante)
        {
            if (id != cantante.Id)
            {
                return BadRequest();
            }

            _context.Entry(cantante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantanteExists(id))
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

        // POST: api/Cantante
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cantante>> PostCantante(Cantante cantante)
        {
            _context.Cantante.Add(cantante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCantante", new { id = cantante.Id }, cantante);
        }

        // DELETE: api/Cantante/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cantante>> DeleteCantante(int id)
        {
            var cantante = await _context.Cantante.FindAsync(id);
            if (cantante == null)
            {
                return NotFound();
            }

            _context.Cantante.Remove(cantante);
            await _context.SaveChangesAsync();

            return cantante;
        }

        private bool CantanteExists(int id)
        {
            return _context.Cantante.Any(e => e.Id == id);
        }
    }
}
