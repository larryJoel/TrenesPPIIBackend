using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class Asiento
{
    public int IdAsiento { get; set; }

    public int? IdViaje { get; set; }

    public int? NumeroAsiento { get; set; }

    public int? Disponible { get; set; }

    public virtual Viaje? IdViajeNavigation { get; set; }
}
