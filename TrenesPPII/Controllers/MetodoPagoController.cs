using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : Controller
    {
        private readonly TrenesContext _context;

        public MetodoPagoController( TrenesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("metodoPago")]
        public async Task<IActionResult> MetodoPago()
        {
            var ListaMP = await _context.MetodoPagos.ToListAsync();
            return Ok(ListaMP);
        }

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] MetodoPago metodo)
        {
            await _context.MetodoPagos.AddAsync(metodo);
            await _context.SaveChangesAsync();
            return Ok(metodo);  
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] MetodoPago metodo)
        {
            var res = _context.MetodoPagos.Find(id);
            if (res == null)
            {
                return BadRequest("Método de pago no existe");
            }
            else
            {
                res.Nombre = metodo.Nombre;
                res.Descripcion = metodo.Descripcion;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
        
        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.MetodoPagos.FindAsync(id);
            if(res == null)
            {
                return BadRequest("Método de pago no existe");
            }
            else
            {
                _context.MetodoPagos.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
