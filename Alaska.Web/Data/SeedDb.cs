using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alaska.Web.Data;
using Alaska.Web.Models;

public class SeedDb
{
    private readonly ApplicationDbContext _context;

    public SeedDb(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCitiesAsync();
    }

    private async Task CheckCitiesAsync()
    {
        if (!_context.City.Any())
        {
            _context.City.Add(new City
            {
                NomCiudad = "Armenia",
                Restaurants = new List<Restaurant>
                {
                    new Restaurant { NomRestaurante = "Alaskarmenia" }
                }
            });
            _context.City.Add(new City
            {
                NomCiudad = "Bogota",
                Restaurants = new List<Restaurant>
                {
                    new Restaurant { NomRestaurante = "Bogotalaska" }
                }
            });
            _context.City.Add(new City
            {
                NomCiudad = "Medellin",
                Restaurants = new List<Restaurant>
                {
                    new Restaurant { NomRestaurante = "AlaskaMedallo" }
                }
            });
            _context.City.Add(new City
            {
                NomCiudad = "Cucuta",
                Restaurants = new List<Restaurant>
                {
                    new Restaurant { NomRestaurante = "AlaskaCucuta" }
                }
            });
            _context.City.Add(new City
            {
                NomCiudad = "Barranquilla",
                Restaurants = new List<Restaurant>
                {
                    new Restaurant { NomRestaurante = "AlaskaGood" }
                }
            });
            await _context.SaveChangesAsync();
        }
    }
}