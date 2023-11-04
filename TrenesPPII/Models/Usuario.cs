using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Cp { get; set; }

    public int? TipoDocId { get; set; }

    public string? NroDocumento { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public int? TipoUsuarioId { get; set; }

    public DateTime? FechaIni { get; set; }

    public DateTime? FechaEdit { get; set; }

    public int? IrolId { get; set; }

    public string? Password { get; set; }

    public virtual TipoUsuario? TipoUsuario { get; set; }

    public virtual ICollection<UsuarioTicket> UsuarioTickets { get; set; } = new List<UsuarioTicket>();
}
