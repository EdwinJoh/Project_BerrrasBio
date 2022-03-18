#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_BerrrasBio.Data;
using Project_BerrrasBio.Models;

namespace Project_BerrrasBio.Controllers
{
    public class SalonsController : Controller
    {
        private readonly Project_BerrrasBioContext _context;

        public SalonsController(Project_BerrrasBioContext context)
        {
            _context = context;
        }

        // GET: Salons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salon.ToListAsync());
        }

        // GET: Salons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salon = await _context.Salon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salon == null)
            {
                return NotFound();
            }

            return View(salon);
        }

        // GET: Salons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Seats")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salon);
        }

        // GET: Salons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salon = await _context.Salon.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }
            return View(salon);
        }

        // POST: Salons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Seats")] Salon salon)
        {
            if (id != salon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalonExists(salon.Id))
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
            return View(salon);
        }

        // GET: Salons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salon = await _context.Salon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salon == null)
            {
                return NotFound();
            }

            return View(salon);
        }

        // POST: Salons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salon = await _context.Salon.FindAsync(id);
            _context.Salon.Remove(salon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalonExists(int id)
        {
            return _context.Salon.Any(e => e.Id == id);
        }
    }
}
