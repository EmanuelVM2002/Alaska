using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class AddProductImageViewMode
    {
        public int ProductId { get; set; }

        [Display(Name = "Image")]
        [Required]
        public IFormFile ImageFile { get; set; }

    }
}
