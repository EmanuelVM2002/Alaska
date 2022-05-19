using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }
        [Display(Name = "Image")]
        
        public string ImageFullPath => ImageId == Guid.Empty
            ? "$https://localhost:44340/images/no-image.png"// luego cambiamos esta url por la de Azure
            : $"https://tiendaonline.Web.blob.core.windows.net/categories/{ImageId}"; // blob en Azure
    }
}
