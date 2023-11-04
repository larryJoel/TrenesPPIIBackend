using System.ComponentModel.DataAnnotations;

namespace TrenesPPII.Models
{
    public class factura
    {
        [Key]
        public int id_factura { get; set; }
        public DateTime fecha_emision { get; set; }
        public int cliente_id { get; set; }
        public decimal total { get; set; }

        public virtual Usuario? IdCliente { get; set; }
    }
}
