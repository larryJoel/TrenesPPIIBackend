using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class Trene
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Numero { get; set; }

    public string? Descripcion { get; set; }
    public int cant_pasajeros { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
