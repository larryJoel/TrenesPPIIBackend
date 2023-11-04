using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class Estacion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Viaje> ViajeDestinoNavigations { get; set; } = new List<Viaje>();

    public virtual ICollection<Viaje> ViajeOrigenNavigations { get; set; } = new List<Viaje>();
}
