using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string NomCiudad { get; set; }

        //todo good
    }
}
