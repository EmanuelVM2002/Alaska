using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class Client
    {
        public int Id { get; set; } 
        public string Nom { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(255)]
        public string Cedula { get; set; }
        [Required]
        public string Direccion { get; set; }
    }
}
