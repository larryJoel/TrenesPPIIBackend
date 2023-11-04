using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class EstacionController : Controller
    {
        private readonly TrenesContext _context;
        public EstacionController(TrenesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Estacion")]
        public async Task<IActionResult> Estacion()
        {
            var ListaEstacion = await _context.Estacions.ToListAsync();
            return Ok(ListaEstacion);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Estacion estacion)
        {
            await _context.Estacions.AddAsync(estacion);
            await _context.SaveChangesAsync();
            return Ok(estacion);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] Estacion estacion)
        {
            var res = _context.Estacions.Find(id);
            if (res == null)
            {
                return BadRequest("La estación no existe");
            }
            else
            {
                res.Nombre = estacion.Nombre;
                res.Direccion = estacion.Direccion;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Estacions.FindAsync(id);
            if (res == null)
            {
                return BadRequest("La estación no existe");
            }
            else
            {
                _context.Estacions.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
