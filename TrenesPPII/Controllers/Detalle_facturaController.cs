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

        [HttpGet]
        [Route("Detalle/Id_factura:int")]
        public async Task<IActionResult> Detalle(int Id_factura)
        {
            try
            {
                var detallesFacturas = await _context.Detalle_Facturas
                    .Where(df => df.Id_factura == Id_factura)
                    .ToListAsync();
                if(detallesFacturas != null && detallesFacturas.Any())
                {
                    return Ok(detallesFacturas);
                }
                else
                {
                    return BadRequest("No se encontraron detalles de factura con ese Id_factura");
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }


        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] detalle_factura detalle)
        {
            await _context.Detalle_Facturas.AddAsync(detalle);
            await _context.SaveChangesAsync();
            return Ok(detalle);
        }

        [HttpPost]
        [Route("Agregar/id_factura:int")]
        public IActionResult agregar(int id_factura)
        {
            var id = id_factura;
            var res = _context.Database.SqlQuery<int>($"exec spGenerarBoletos {id}");
            if (res == null)
            {
                return BadRequest("Error al generar boletos");
            }
            return Ok(res);
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
                res.descripcion = detalle.descripcion;
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
