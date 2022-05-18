using System.ComponentModel.DataAnnotations;
using Alaska.Web.Data.Entities;
namespace Alaska.Web.Models
{
    public class City
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NomCiudad { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
