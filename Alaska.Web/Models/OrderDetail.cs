using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{

    public class OrderDetail
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public float Quantity { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
        public decimal Value => (decimal)Quantity * Price;
    }

}
