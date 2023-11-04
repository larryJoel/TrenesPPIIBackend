using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private readonly TrenesContext _context;

        public FacturaController( TrenesContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Factura")]
        public async Task<IActionResult> Factura()
        {
            var listFacturas = await _context.factura.ToArrayAsync();
            return Ok(listFacturas);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] factura factura)
        {
            await _context.factura.AddAsync(factura);
            await _context.SaveChangesAsync();
            return Ok(factura);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult>Editar(int id, [FromBody] factura factura)
        {
            var res = await _context.factura.FindAsync(id);
            if (res == null)
            {
                return BadRequest("No existe la factura");
            }
            else
            {
               res.cliente_id = factura.cliente_id;
               res.fecha_emision = factura.fecha_emision;
               res.total = factura.total;
               await _context.SaveChangesAsync();
               return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.factura.FindAsync(id);
            if (res == null)
            {
                return BadRequest("No existe la factura");
            }
            else
            {
                _context.factura.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

    }
}
