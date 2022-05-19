using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class CategoryViewModel : Category
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
