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
            ? "$https://alaskaweb20220519144510.azurewebsites.net"// luego cambiamos esta url por la de Azure
            : $"https://alaskdemo.blob.core.windows.net/products/{ImageId}";
    }
}
