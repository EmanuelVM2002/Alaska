using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class City
    {
        public int CodCiudad { get; set; }
        [Required]
        public string NomCiudad { get; set; }
    }
}
