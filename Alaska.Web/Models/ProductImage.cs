using System.ComponentModel.DataAnnotations;

namespace Alaska.Web.Models
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        [Display(Name = "Image")]
        public Guid ImageId { get; set; }
        [Display(Name = "Image")]

        public string ImageFullPath => ImageId == Guid.Empty
            ? "$https://localhost:44340/images/no-image.png"// luego cambiamos esta url por la de Azure
            : $"https://alaskdemo.blob.core.windows.net/categories/{ImageId}";
    }
}
