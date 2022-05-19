using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alaska.Web.Models
{
    public class City
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Nombre de la Ciudad")]
        public string NomCiudad { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
        [JsonIgnore]
        [NotMapped]
        [DisplayName("Numero de Restaurantes")]
        public int RestaurantsNumber => Restaurants == null ? 0 : Restaurants.Count;
    }
}
