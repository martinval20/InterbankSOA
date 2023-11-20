using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Transfers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentumsController : ControllerBase
    {
        private readonly bdSOAContext _context;

        public CuentumsController(bdSOAContext context)
        {
            _context = context;
        }

        //Martin Valdiviezo
        //GET: api/Cuentum/ListarCuentas
        [HttpGet("ListarCuentas")]
        public async Task<ActionResult<IEnumerable<CuentumDt1>>> GetListarCuentas()
        {
            if (_context.Cuenta == null)
            {
                return NotFound();
            }
            return await (from b in _context.Cuenta
                          select new CuentumDt1()
                          {
                              IdTipoCuenta = b.IdTipoCuenta,
                              NumeroCuenta = b.NumeroCuenta,
                              Saldo = b.Saldo,
                          }).ToListAsync();
        }
        //Martin Valdiviezo
        //GET: api/Cuentum/FiltrarCuenta
        [HttpGet("FiltarCuentaPorNumCuenta")]
        public async Task<ActionResult<IEnumerable<CuentumDt1>>> GetFiltrarCuenta(string? numCuenta)
        {
            if (_context.Cuenta == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(numCuenta))
            {
                return await (from b in _context.Cuenta
                              select new CuentumDt1()
                              {
                                  IdTipoCuenta = b.IdTipoCuenta,
                                  NumeroCuenta = b.NumeroCuenta,
                                  Saldo = b.Saldo,
                              }).ToListAsync();
            }
            else
            {
                return await (from b in _context.Cuenta.Where(t=>t.NumeroCuenta.Contains(numCuenta))
                              select new CuentumDt1()
                              {
                                  IdTipoCuenta = b.IdTipoCuenta,
                                  NumeroCuenta = b.NumeroCuenta,
                                  Saldo = b.Saldo,
                              }).ToListAsync();
            }
           
        }

        // GET: api/Cuentums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuentum>>> GetCuenta()
        {
          if (_context.Cuenta == null)
          {
              return NotFound();
          }
            return await _context.Cuenta.ToListAsync();
        }

        // GET: api/Cuentums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuentum>> GetCuentum(int id)
        {
          if (_context.Cuenta == null)
          {
              return NotFound();
          }
            var cuentum = await _context.Cuenta.FindAsync(id);

            if (cuentum == null)
            {
                return NotFound();
            }

            return cuentum;
        }

        // PUT: api/Cuentums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuentum(int id, Cuentum cuentum)
        {
            if (id != cuentum.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuentum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentumExists(id))
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

        // POST: api/Cuentums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuentum>> PostCuentum(Cuentum cuentum)
        {
          if (_context.Cuenta == null)
          {
              return Problem("Entity set 'bdSOAContext.Cuenta'  is null.");
          }
            _context.Cuenta.Add(cuentum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuentum", new { id = cuentum.Id }, cuentum);
        }

        // DELETE: api/Cuentums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentum(int id)
        {
            if (_context.Cuenta == null)
            {
                return NotFound();
            }
            var cuentum = await _context.Cuenta.FindAsync(id);
            if (cuentum == null)
            {
                return NotFound();
            }

            _context.Cuenta.Remove(cuentum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuentumExists(int id)
        {
            return (_context.Cuenta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
