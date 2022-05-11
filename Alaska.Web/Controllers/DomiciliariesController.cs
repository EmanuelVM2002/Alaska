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
    public class DomiciliariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DomiciliariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Domiciliaries
        public async Task<IActionResult> Index()
        {
              return View(await _context.Domiciliary.ToListAsync());
        }

        // GET: Domiciliaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Domiciliary == null)
            {
                return NotFound();
            }

            var domiciliary = await _context.Domiciliary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domiciliary == null)
            {
                return NotFound();
            }

            return View(domiciliary);
        }

        // GET: Domiciliaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Domiciliaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Direccion,NomEmpleado,CedEmpleado,ApeEmpleado,EdadEmpleado")] Domiciliary domiciliary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domiciliary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(domiciliary);
        }

        // GET: Domiciliaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Domiciliary == null)
            {
                return NotFound();
            }

            var domiciliary = await _context.Domiciliary.FindAsync(id);
            if (domiciliary == null)
            {
                return NotFound();
            }
            return View(domiciliary);
        }

        // POST: Domiciliaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Direccion,NomEmpleado,CedEmpleado,ApeEmpleado,EdadEmpleado")] Domiciliary domiciliary)
        {
            if (id != domiciliary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domiciliary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomiciliaryExists(domiciliary.Id))
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
            return View(domiciliary);
        }

        // GET: Domiciliaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Domiciliary == null)
            {
                return NotFound();
            }

            var domiciliary = await _context.Domiciliary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domiciliary == null)
            {
                return NotFound();
            }

            return View(domiciliary);
        }

        // POST: Domiciliaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Domiciliary == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Domiciliary'  is null.");
            }
            var domiciliary = await _context.Domiciliary.FindAsync(id);
            if (domiciliary != null)
            {
                _context.Domiciliary.Remove(domiciliary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomiciliaryExists(int id)
        {
          return _context.Domiciliary.Any(e => e.Id == id);
        }
    }
}
