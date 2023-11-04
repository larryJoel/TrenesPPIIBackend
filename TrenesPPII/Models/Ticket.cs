using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public DateTime? FechaCreate { get; set; }

    public DateTime? FechaEdit { get; set; }

    public DateTime? FechaExpira { get; set; }

    public string? EstadoTicket { get; set; }

    public int? MetodoPagoId { get; set; }

    public int? TipoTicketId { get; set; }

    public int? ViajeId { get; set; }

    public virtual MetodoPago? MetodoPago { get; set; }

    public virtual TipoTicket? TipoTicket { get; set; }

    public virtual ICollection<UsuarioTicket> UsuarioTickets { get; set; } = new List<UsuarioTicket>();

    public virtual Viaje? Viaje { get; set; }
}
