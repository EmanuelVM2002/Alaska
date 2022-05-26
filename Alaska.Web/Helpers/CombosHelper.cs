using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Alaska.Web.Data;
using Alaska.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Alaska.Web.Helpers
{

    public class CombosHelper : ICombosHelper
    {
        private readonly ApplicationDbContext _context;

        public CombosHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboCategories()
        {
            List<SelectListItem> list = _context.Categories.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a category...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboRestaurants(int cityId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            City city = _context.City
                .Include(d => d.Restaurants)
                .FirstOrDefault(d => d.Id == cityId);
            if (city != null)
            {
                list = city.Restaurants.Select(t => new SelectListItem
                {
                    Text = t.NomRestaurante,
                    Value = t.Id.ToString()
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a restaurante...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboCities()
        {
            List<SelectListItem> list = _context.City.Select(t => new SelectListItem
            {
                Text = t.NomCiudad,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Ciudad...]",
                Value = "0"
            });

            return list;
        }

    }

}
