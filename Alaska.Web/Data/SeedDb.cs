using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alaska.Web.Data;
using Alaska.Web.Data.Entities;
using Alaska.Web.Enums;
using Alaska.Web.Helpers;
using Alaska.Web.Models;
namespace Alaska.Web.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(ApplicationDbContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCitiesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1000761254", "Emanuel", "E", "emanuelvillada10@gmail.com", "3017759082", "Calle GG", UserType.Admin);
        }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.City.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "3017759082");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckCitiesAsync()
        {
            if (!_context.City.Any())
            {
                _context.City.Add(new City
                {
                    NomCiudad = "Apartadó",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Armenia",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Barrancabermeja",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Barranquilla",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Medellín",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Bogota",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Buga",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Bucaramanga",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Calarca",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Caldas",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Cali",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Cartagena",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Cartago",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Chía",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Copacabana",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Cucuta",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Dosquebradas",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Girardot",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Ibague",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "La Ceja",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Manizales",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Monteria",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Neiva",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Palmira",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Pereira",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Popayan",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Quibdo",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Sabaneta",
                });
                _context.City.Add(new City
                {
                    NomCiudad = "Yopal",
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}