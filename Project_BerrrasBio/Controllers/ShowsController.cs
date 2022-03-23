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
    public class ShowsController : Controller
    {
        private readonly Project_BerrrasBioContext _context;

        public ShowsController(Project_BerrrasBioContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index(string sortOrder)
        {
            


            var count = from c in _context.Show.Include(c => c.Movie)
                                                .Include(c => c.Salon)
                                                .Include(s => s.Bookings)
                                                 select c;

            ViewBag.DateSort = sortOrder == "Date" ? "date_desc" : "Date"; // decending ???
            ViewBag.SeatSortParm = String.IsNullOrEmpty(sortOrder) ? "Seat left" : "";
            //behöver uträkning för seats left kan man använda den som vi har i view ? 
            switch (sortOrder)
            {
                case "Date":
                    count = count.OrderByDescending(s => s.ShowTime);
                    break;
                case "Seat left":
                    count = count.OrderByDescending(s => s.Salon.Seats);
                    break;
                case "date_desc":
                    count = count.OrderBy(s => s.ShowTime);
                    break;

                default:
                    count = count.OrderBy(s => s.Id);
                    break;
            }
            return View(await count.AsNoTracking().ToListAsync());


        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                            .Include(s => s.Movie)
                            .Include(s => s.Salon)
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id");
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,SalonId,ShowTime")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", show.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id", show.SalonId);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", show.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id", show.SalonId);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,SalonId,ShowTime")] Show show)
        {
            if (id != show.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", show.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id", show.SalonId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Show.FindAsync(id);
            _context.Show.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.Id == id);
        }
    }
}
