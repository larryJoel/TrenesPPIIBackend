using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AsientoController : Controller
    {
        private readonly TrenesContext _context;

        public AsientoController( TrenesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Asiento")]
        public async Task<IActionResult> Asiento()
        {
            var listAsientos = await _context.Asientos.ToListAsync();
            return Ok(listAsientos);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Asiento asiento)
        {
            await _context.Asientos.AddAsync(asiento);
            await _context.SaveChangesAsync();
            return Ok(asiento);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] Asiento asiento)
        {
            var res = _context.Asientos.Find(id);
            if (res == null)
            {
                return BadRequest("No existe el asiento");
            }
            else
            {
                res.IdViaje = asiento.IdViaje;
                res.NumeroAsiento = asiento.NumeroAsiento;
                res.Disponible = asiento.Disponible;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Asientos.FindAsync(id);
            if (res == null)
            {
                return BadRequest("No existe el asiento");
            }
            else
            {
                _context.Asientos.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
