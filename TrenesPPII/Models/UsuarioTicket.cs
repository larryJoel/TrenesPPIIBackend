using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class UsuarioTicket
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? TicketId { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
