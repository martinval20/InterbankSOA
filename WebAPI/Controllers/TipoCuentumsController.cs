using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Transfers;

namespace WebAPI.Controllers
{
    [EnableCors("WEBVUE")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCuentumsController : ControllerBase
    {
        private readonly bdSOAContext _context;

        public TipoCuentumsController(bdSOAContext context)
        {
            _context = context;
        }
        //Martin Valdiviezo 1
        //GET: api/TiposCuentums/ListarCuenta
        [HttpGet("ListarTiposCuentas")]
        public async Task<ActionResult<IEnumerable<TipoCuentumDt1>>> GetListarCuentas()
        {
            if (_context.TipoCuenta == null)
            {
                return NotFound();
            }
            return await (from b in _context.TipoCuenta.Where(t => t.Id<6)
                          select new TipoCuentumDt1()
                          {
                              Id = b.Id,
                              NombreTipoCuenta = b.NombreTipoCuenta
                          }).ToListAsync();
        }

        //Martin Valdiviezo
        //GET: api/TiposCuentums/FiltrarPorNombreCuenta
        [HttpGet("FiltrarPorNombreCuenta")]
        public async Task<ActionResult<IEnumerable<TipoCuentumDt1>>> GetFiltrarTipoCuentumPorNombre(string? nombreCuenta)
        {
            if (_context.TipoCuenta == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(nombreCuenta))
            {
                return await (from b in _context.TipoCuenta.Where(t => t.Id<6)
                              select new TipoCuentumDt1()
                              {
                                  Id = b.Id,
                                  NombreTipoCuenta = b.NombreTipoCuenta
                              }).ToListAsync();
            }
            else
            {
                return await (from b in _context.TipoCuenta.Where(t => t.NombreTipoCuenta.Contains(nombreCuenta) && t.Id < 6)
                                   select new TipoCuentumDt1()
                                   {
                                       Id = b.Id,
                                       NombreTipoCuenta = b.NombreTipoCuenta
                                   }).ToListAsync();
            }
            
        }

        // GET: api/TipoCuentums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCuentum>>> GetTipoCuenta()
        {
          if (_context.TipoCuenta == null)
          {
              return NotFound();
          }
            return await _context.TipoCuenta.ToListAsync();
        }

        // GET: api/TipoCuentums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCuentum>> GetTipoCuentum(int id)
        {
          if (_context.TipoCuenta == null)
          {
              return NotFound();
          }
            var tipoCuentum = await _context.TipoCuenta.FindAsync(id);

            if (tipoCuentum == null)
            {
                return NotFound();
            }

            return tipoCuentum;
        }

        // PUT: api/TipoCuentums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCuentum(int id, TipoCuentum tipoCuentum)
        {
            if (id != tipoCuentum.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoCuentum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCuentumExists(id))
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

        // POST: api/TipoCuentums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCuentum>> PostTipoCuentum(TipoCuentum tipoCuentum)
        {
          if (_context.TipoCuenta == null)
          {
              return Problem("Entity set 'bdSOAContext.TipoCuenta'  is null.");
          }
            _context.TipoCuenta.Add(tipoCuentum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCuentum", new { id = tipoCuentum.Id }, tipoCuentum);
        }

        // DELETE: api/TipoCuentums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCuentum(int id)
        {
            if (_context.TipoCuenta == null)
            {
                return NotFound();
            }
            var tipoCuentum = await _context.TipoCuenta.FindAsync(id);
            if (tipoCuentum == null)
            {
                return NotFound();
            }

            _context.TipoCuenta.Remove(tipoCuentum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCuentumExists(int id)
        {
            return (_context.TipoCuenta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
