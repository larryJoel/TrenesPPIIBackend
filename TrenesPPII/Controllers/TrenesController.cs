using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenesController : Controller
    {
        private readonly TrenesContext _context;
        public TrenesController(TrenesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Trenes")]
        public async Task<IActionResult> Trenes()
        {
            var trenesList = await _context.Trenes.ToListAsync();
            return Ok(trenesList);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Trene tren)
        {
            await _context.Trenes.AddAsync(tren);
            await _context.SaveChangesAsync();
            return Ok(tren);
        }

        [HttpPost]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] Trene tren)
        {
            var res = _context.Trenes.Find(id);
            if (res == null)
            {
                return BadRequest("No existe el tren");
            }
            else
            {
                res.Nombre = tren.Nombre;
                res.Numero = tren.Numero;
                res.Descripcion = tren.Descripcion;
                res.cant_pasajeros = tren.cant_pasajeros;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = _context.Trenes.Find(id);
            if (res == null)
            {
                return BadRequest("No existe el tren");
            }
            else
            {
                _context.Trenes.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
