using Alaska.Web.Models;
using System;

namespace Alaska.Web.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew);
        CategoryViewModel ToCategoryViewModel(Category category);
        Task<Product> ToProductAsync(ProductViewModel model, bool isNew);
        ProductViewModel ToProductViewModel(Product product);
    }

}
