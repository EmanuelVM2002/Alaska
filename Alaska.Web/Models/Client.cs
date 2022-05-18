using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class Client
    {
        public int Id { get; set; }
        [MaxLength(10, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="El campo {0} debe contener al menos un caracter")]
        public string Cedula { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Direccion { get; set; }
    }
}
