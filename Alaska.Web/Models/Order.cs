using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class Order
    {
        public string CodPedido { get; set; } 
        public string Detalles { get; set; }
        public int EstadoPedido { get; set; }
    }
}
