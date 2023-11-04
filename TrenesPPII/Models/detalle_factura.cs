using System.ComponentModel.DataAnnotations;

namespace TrenesPPII.Models
{
    public class detalle_factura
    {
        [Key]
        public int Id_detalle { get; set; }
        public int Id_factura { get; set; }
        public int Id_ticket { get; set; }
        public int Cantidad { get; set;}
        public double Precio_unitario { get; set; }
        public double SubTotal { get; set; }

        public virtual factura? IdFacturaFact { get; set; }
        public virtual Ticket? IdTicketFact { get; set; }
    }
}
