using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class Supplier
    {
        public int CodProveedor { get; set; }
        [Required]
        [MaxLength(255)]
        public int NIT { get; set; }
        [Required]
        public string NomProveedor { set; get; }
    }
}
