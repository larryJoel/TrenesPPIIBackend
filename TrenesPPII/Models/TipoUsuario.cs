using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class TipoUsuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string Desripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
