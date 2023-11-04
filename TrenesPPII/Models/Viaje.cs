using System;
using System.Collections.Generic;

namespace TrenesPPII.Models;

public partial class Viaje
{
    public int Id { get; set; }

    public DateTime? HoraSal { get; set; }

    public DateTime? HoraLlegada { get; set; }

    public int? TrenId { get; set; }

    public int? Origen { get; set; }

    public int? Destino { get; set; }
    public int Disponible { get; set; }

    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();

    public virtual Estacion? DestinoNavigation { get; set; }

    public virtual Estacion? OrigenNavigation { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Trene? Tren { get; set; }
}
