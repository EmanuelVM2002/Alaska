using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alaska.Web.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Nombre del Restaurante")]
        public string NomRestaurante { set; get; }
        [JsonIgnore]
        public int IdCity { get; set; }
    }
}
