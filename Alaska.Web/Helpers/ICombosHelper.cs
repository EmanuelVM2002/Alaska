using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Alaska.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();
        IEnumerable<SelectListItem> GetComboCities();
        IEnumerable<SelectListItem> GetComboRestaurants(int CityId);

    }

}
