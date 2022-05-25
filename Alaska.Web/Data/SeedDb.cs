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
            await CheckUserAsync("1000761254", "Emanuel", "Villada", "emanuelvillada10@gmail.com", "3017759082", "Calle GG", UserType.Admin);
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
                await _userHelper.AddUserAsync(user, "E3017759082");
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
                await _context.SaveChangesAsync();
            }
        }
    }
}