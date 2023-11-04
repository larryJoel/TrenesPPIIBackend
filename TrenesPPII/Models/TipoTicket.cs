using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class TipoTicket
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
