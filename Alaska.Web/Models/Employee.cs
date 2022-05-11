using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string NomEmpleado { get; set; }
        [Required]
        [MaxLength(255)]
        public string CedEmpleado { get; set; }
        [Required]
        public string ApeEmpleado { get; set; }
        [Required]
        public int EdadEmpleado { get; set; }
    }
}
