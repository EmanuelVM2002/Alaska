using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class Client
    {
        public int CodCliente { get; set; } 
        public string Nom { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(255)]
        [Key]
        public string Cedula { get; set; }
        [Required]
        public string Direccion { get; set; }
    }
}
