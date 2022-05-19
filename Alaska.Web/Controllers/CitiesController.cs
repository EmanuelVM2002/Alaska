using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alaska.Web.Data;
using Alaska.Web.Models;

namespace Alaska.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            return View(await _context.City
                .Include(c => c.Restaurants)
                .ToListAsync());
        }


        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            City city = await _context.City
                .Include(_c => _c.Restaurants)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(city);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya hay una ciudad con el mismo nombre");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }


                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(city);
        }


        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomCiudad")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .Include(c => c.Restaurants)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.City == null)
            {
                return Problem("Entity set 'ApplicationDbContext.City'  is null.");
            }
            var city = await _context.City.FindAsync(id);
            if (city != null)
            {
                _context.City.Remove(city);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddRestaurant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            Restaurant model = new Restaurant { IdCity = city.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                City city = await _context.City
                .Include(c => c.Restaurants)
                .FirstOrDefaultAsync(c => c.Id == restaurant.IdCity);
                if (city == null)
                {
                    return NotFound();
                }

                try
                {
                    restaurant.Id = 0;
                    city.Restaurants.Add(restaurant);
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new {Id = city.Id});

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya hay un resgistro con ese nombre");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                        dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(restaurant);
        }

        public async Task<IActionResult> EditRestaurant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant restaurant = await _context.Restaurant.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            City city = await _context.City.FirstOrDefaultAsync(c =>
            c.Restaurants.FirstOrDefault(d => d.Id == restaurant.Id) != null);
            restaurant.IdCity = city.Id;
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new {Id = restaurant.IdCity});
                }
                    catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(restaurant);
        }
        public async Task<IActionResult> DeleteRestaurant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant restaurant = await _context.Restaurant
            .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            City city = await _context.City.FirstOrDefaultAsync(c =>
            c.Restaurants.FirstOrDefault(d => d.Id == restaurant.Id) != null);
            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = city.Id });
        }

        public async Task<IActionResult> DetailsRestaurant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant restaurant = await _context.Restaurant
            .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            City city = await _context.City.FirstOrDefaultAsync(c =>
            c.Restaurants.FirstOrDefault(d => d.Id == restaurant.Id) != null);
            restaurant.IdCity = city.Id;
            return View(restaurant);
        }


    }
}
