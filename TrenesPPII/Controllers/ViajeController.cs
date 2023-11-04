using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : Controller
    {
        private readonly TrenesContext _context;
        public ViajeController( TrenesContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Viaje")]
        public async Task<IActionResult> Viaje()
        {
            var listaViajes = await _context.Viajes.ToListAsync();
            return Ok(listaViajes);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Viaje viaje)
        {
            await _context.Viajes.AddAsync(viaje);
            await _context.SaveChangesAsync();
            return Ok(viaje);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] Viaje viaje)
        {
            var res = _context.Viajes.Find(id);
            if (res == null)
            {
                return BadRequest("Viaje no existe");
            }
            else
            {
                res.HoraSal = viaje.HoraSal;
                res.HoraLlegada = viaje.HoraLlegada;
                res.Tren = viaje.Tren;
                res.Origen = viaje.Origen;
                res.Destino = viaje.Destino;
                res.Disponible = viaje.Disponible;
                await _context.SaveChangesAsync();
                return Ok(res);
            }

        }

        [HttpDelete]
        [Route("eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Viajes.FindAsync(id);
            if (res == null)
            {
                return BadRequest("El viaje no existe");
            }
            else
            {
                _context.Viajes.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
