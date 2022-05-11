using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public int NIT { get; set; }
        [Required]
        public string NomProveedor { set; get; }
    }
}
