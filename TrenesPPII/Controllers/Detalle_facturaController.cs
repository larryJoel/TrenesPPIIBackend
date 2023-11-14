using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class Detalle_facturaController : Controller
    {
        private readonly TrenesContext _context;
        public Detalle_facturaController( TrenesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Detalle")]
        public async Task<IActionResult> Detalle()
        {
            var listDetalleFactura = await _context.Detalle_Facturas.ToListAsync();
            return Ok(listDetalleFactura);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] detalle_factura detalle)
        {
            await _context.Detalle_Facturas.AddAsync(detalle);
            await _context.SaveChangesAsync();
            return Ok(detalle);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] detalle_factura detalle)
        {
            var res = await _context.Detalle_Facturas.FindAsync(id);
            if (res == null)
            {
                return BadRequest("No existe el detalle de factura");
            }
            else
            {
                res.IdFacturaFact = detalle.IdFacturaFact;
                res.Id_ticket=detalle.Id_ticket;
                res.Cantidad = detalle.Cantidad;
                res.Precio_unitario=detalle.Precio_unitario;
                res.SubTotal = detalle.SubTotal;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Detalle_Facturas.FindAsync(id);
            if (res == null)
            {
                return BadRequest("No existe el detalle de la factura");
            }
            else
            {
                _context.Detalle_Facturas.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

    }
}
