using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrenesPPII.Controllers
{
    [Keyless]
    public class spPuestosDisponibles
    {
        string? boletosSinVender { get; set; }
    }
}
