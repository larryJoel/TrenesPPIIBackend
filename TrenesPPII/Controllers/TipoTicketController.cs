using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTicketController : Controller
    {
        private readonly TrenesContext _context;
        public TipoTicketController(TrenesContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("TipoTicket")]
        public async Task<IActionResult> Tipos()
        {
            var listaTiposTicket = await _context.TipoTickets.ToListAsync();
            return Ok(listaTiposTicket);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] TipoTicket tipoTicket)
        {
            if (tipoTicket == null)
            {
                return BadRequest("Error en la creación del tipo de ticket");
            }
            await _context.TipoTickets.AddAsync(tipoTicket);
            await _context.SaveChangesAsync();
            return Ok(tipoTicket);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] TipoTicket tipoTicket)
        {
            var res = _context.TipoTickets.Find(id);
            if (res == null)
            {
                return BadRequest("El tipo de ticket no existe");
            }
            else
            {
                res.Nombre = tipoTicket.Nombre;
                res.Descripcion = tipoTicket.Descripcion;
                res.Precio = tipoTicket.Precio;
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult>Eliminar(int id)
        {
            var res = await _context.TipoTickets.FindAsync(id);
            if(res == null)
            {
                return BadRequest("Tipo de Ticket no existe");
            }
            else
            {
                _context.TipoTickets.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

    }
}
