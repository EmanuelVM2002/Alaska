using Alaska.Web.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Alaska.Web.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Is Starred")]
        public bool IsStarred { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        [DisplayName("Product Images Number")]
        public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

        //TO DO: Pendiente cambiar los paths por los de Azure	
        [Display(Name = "Image")]
        public string ImageFullPath => ProductImages == null || ProductImages.Count == 0
        ? $"https://localhost:44340/images/no-image.png"
        : ProductImages.FirstOrDefault().ImageFullPath;
    }
}

