using Alaska.Web.Enums;
using Alaska.Web.Helpers;
using Alaska.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alaska.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly ICombosHelper _combosHelper;

        public UsersController(ApplicationDbContext context, IUserHelper userHelper, IBlobHelper blobHelper, ICombosHelper combosHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _blobHelper = blobHelper;
            _combosHelper = combosHelper;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _context.Users
                .Include(u => u.City)
                .ToListAsync());
        }

    }
}

