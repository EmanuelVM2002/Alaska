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
    public class IciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Icies
        public async Task<IActionResult> Index()
        {
              return View(await _context.Icy.ToListAsync());
        }

        // GET: Icies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Icy == null)
            {
                return NotFound();
            }

            var icy = await _context.Icy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (icy == null)
            {
                return NotFound();
            }

            return View(icy);
        }

        // GET: Icies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Icies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor")] Icy icy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(icy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(icy);
        }

        // GET: Icies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Icy == null)
            {
                return NotFound();
            }

            var icy = await _context.Icy.FindAsync(id);
            if (icy == null)
            {
                return NotFound();
            }
            return View(icy);
        }

        // POST: Icies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor")] Icy icy)
        {
            if (id != icy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IcyExists(icy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(icy);
        }

        // GET: Icies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Icy == null)
            {
                return NotFound();
            }

            var icy = await _context.Icy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (icy == null)
            {
                return NotFound();
            }

            return View(icy);
        }

        // POST: Icies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Icy == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Icy'  is null.");
            }
            var icy = await _context.Icy.FindAsync(id);
            if (icy != null)
            {
                _context.Icy.Remove(icy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IcyExists(int id)
        {
          return _context.Icy.Any(e => e.Id == id);
        }
    }
}
