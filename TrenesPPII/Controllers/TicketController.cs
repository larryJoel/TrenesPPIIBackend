using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly TrenesContext _context;

        public TicketController( TrenesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Ticket")]
        public async Task<IActionResult> Ticket()
        {
            var listTicket = await _context.Tickets.ToListAsync();
            return Ok(listTicket);
        }

        [HttpGet]
        [Route("Ticket/id:int")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return BadRequest("No se encuentra el ticket");
            }

            return Ok(ticket);
        }

        [HttpGet]
        [Route("ticketPorFactura/{Id_factura:int}")]
        public async Task<IActionResult> TickettoFact(int Id_factura)
        {
            var listaTickets = await _context.Tickets
                                               .Where(t => t.Id_factura == Id_factura)
                                               .ToListAsync();

            if (listaTickets == null || !listaTickets.Any())
            {
                return NotFound($"No hay tickets con el número de Id_factura {Id_factura}");
            }

            return Ok(listaTickets);
        }





        [HttpGet]
        [Route("Diponibilidad")]
        public async Task<IActionResult> Diponibilidad()
        {
            var id = 3;
            //var res = await _context.PuestosDisponibles.FromSqlRaw("spPuestosDisponibles @id", new SqlParameter("@id", id)).ToListAsync();
            var res = _context.Database.SqlQuery<int>($"exec spPuestosDisponibles {id}").SingleOrDefault();
            return Ok(res);
        }

        [HttpGet]
        [Route("ActualizarPuestosDisp")]
        public IActionResult ActualizarPuestosDisp()
        {
            _context.Database.ExecuteSqlRaw("EXEC ActualizaPuestoViajes");

            // Puedes devolver cualquier respuesta adecuada a tu caso
            return Ok("Procedimiento almacenado ejecutado correctamente");
        }


        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Ticket ticket)
        {
            var id = ticket.ViajeId;
            var res = _context.Database.SqlQuery<int>($"exec spPuestosDisponibles {id}");
           

            if (res == null)
            {
                return BadRequest("No puede vender más boletos");
            }

            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] Ticket ticket)
        {
            var res = _context.Tickets.Find(id);
            if(res == null)
            {
                return BadRequest("No existe el ticket");
            }
            else
            {
                res.FechaCreate = ticket.FechaCreate;
                res.FechaEdit = ticket.FechaEdit;
                res.FechaExpira = ticket.FechaExpira;
                res.EstadoTicket = ticket.EstadoTicket;
                res.MetodoPagoId = ticket.MetodoPagoId;
                res.TipoTicketId = ticket.TipoTicketId;
                res.ViajeId = ticket.ViajeId;
                res.Id_factura = ticket.Id_factura;
                res.Description = ticket.Description;
                res.Tipo=ticket.Tipo;

                await _context.SaveChangesAsync();
                return Ok(ticket);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _context.Tickets.FindAsync(id);
            if (res == null)
            {
                return BadRequest("El ticket no existe");
            }
            else
            {
                _context.Tickets.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
