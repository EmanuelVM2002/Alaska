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
            ? "$https://alaskaweb20220519144510.azurewebsites.net"// luego cambiamos esta url por la de Azure
            : $"https://alaskdemo.blob.core.windows.net/categories/{ImageId}"; // blob en Azure
    }
}
