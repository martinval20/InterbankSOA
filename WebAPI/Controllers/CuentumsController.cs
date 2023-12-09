using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Transfers;

namespace WebAPI.Controllers
{
    [EnableCors("WEBVUE")]
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
        [HttpGet("ListarCuentasActivas")]
        public async Task<ActionResult<IEnumerable<CuentumDt1>>> GetListarCuentas()
        {
            if (_context.Cuenta == null)
            {
                return NotFound();
            }
            return await (from b in _context.Cuenta.Where(t => t.Estado.Equals("ACTIVO"))
                          select new CuentumDt1()
                          {
                              IdTipoCuenta = b.IdTipoCuenta,
                              NumeroCuenta = b.NumeroCuenta,
                              Saldo = b.Saldo,
                              Estado = b.Estado,
                          }).ToListAsync();
        }
        //Martin Valdiviezo
        //GET: api/Cuentum/FiltrarCuenta
        [HttpGet("FiltarCuentaPorNumeroCuenta")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CuentumDt1>>> GetFiltrarCuenta(string? numCuenta)
        {
            if (_context.Cuenta == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(numCuenta))
            {
                return await (from b in _context.Cuenta.Where(t => t.Id < 6)
                              select new CuentumDt1()
                              {
                                  IdTipoCuenta = b.IdTipoCuenta,
                                  NumeroCuenta = b.NumeroCuenta,
                                  Saldo = b.Saldo,
                                  Estado = b.Estado,
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
                                  Estado = b.Estado,
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
        // Martin Valdiviezo
        // PUT: api/Cuentums/ActualizarEstado
        [HttpPut("SuspenderCuenta/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutActualizarEstado(int id, CuentumDt2 cuentumDt2)
        {
            if (_context.Cuenta == null)
            {
                return Problem("Entity set 'bdSOAContext.Cuenta'  is null.");
            }
            Cuentum cuentum = _context.Cuenta.Find(id);
            cuentum.Estado = "SUSPENDIDO";
            _context.Entry(cuentum).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCuentum", new { id = cuentumDt2.Id }, cuentumDt2);
        }

        // Martin Valdiviezo
        // PUT: api/Cuentums/ActivarCuenta
        [HttpPut("ActivarCuenta/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutActivarEstado(int id, CuentumDt2 cuentumDt2)
        {
            if (_context.Cuenta == null)
            {
                return Problem("Entity set 'bdSOAContext.Cuenta'  is null.");
            }
            Cuentum cuentum = _context.Cuenta.Find(id);
            cuentum.Estado = "ACTIVO";
            _context.Entry(cuentum).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCuentum", new { id = cuentumDt2.Id }, cuentumDt2);
        }


        // POST: api/Cuentums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuentum>> PostCuentum(Cuentum cuentum)
        {
          if (_context.Cuenta == null)
          {
                return BadRequest(ModelState);
            }
            _context.Cuenta.Add(cuentum);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCuentum", new { id = cuentum.Id }, cuentum);
        }

        //Martin Valdiviezo
        // POST: api/Cuentums/AperturarCuenta
/*        [HttpPost("AperturarCuenta")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CuentumDt2>> PostAperturaCuenta(CuentumDt2 cuentumDt2, int idPersona, int idTipoCuenta, String numCuenta, String clave)
        {
            if(_context.Cuenta == null)
            {
                return BadRequest(ModelState);
            }
            Cuentum cuentum = new()
            {
                IdPersona = idPersona,
                IdTipoCuenta = idTipoCuenta,
                NumeroCuenta = numCuenta,
                Saldo = 0,
                Clave = clave,
                Estado = "INACTIVO"
            };
            _context.Cuenta.Add(cuentum);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCuentum", new { id = cuentumDt2.Id }, cuentumDt2);
        }*/

        //Martin Valdiviezo
        // POST: api/Cuentums/AperturarCuenta
        [HttpPost("AperturarCuenta2")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CuentumDt2>> PostAperturaCuenta(CuentumDt2 cuentumDt2)
        {
            Cuentum cuentum = new Cuentum()
            {
                IdPersona = cuentumDt2.IdPersona,
                IdTipoCuenta = cuentumDt2.IdTipoCuenta,
                NumeroCuenta = cuentumDt2.NumeroCuenta,
                Saldo = cuentumDt2.Saldo,
                Clave = cuentumDt2.Clave,
                Estado = "INACTIVO"
            };
            _context.Cuenta.Add(cuentum);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCuentum", new { id = cuentumDt2.Id }, cuentumDt2);
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
