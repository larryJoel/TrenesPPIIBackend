using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class MetodoPago
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
