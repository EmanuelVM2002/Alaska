using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DisplayName("Numero de Restaurantes")]
        public int RestaurantsNumber => Restaurants == null ? 0 : Restaurants.Count;
    }
}
