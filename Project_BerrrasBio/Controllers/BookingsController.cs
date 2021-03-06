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

    public class BookingsController : Controller
    {

        private readonly Project_BerrrasBioContext _context;

        public BookingsController(Project_BerrrasBioContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var project_BerrrasBioContext = _context.Booking.Include(b => b.shows);
            return View(await project_BerrrasBioContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                                .Include(b => b.shows)
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        //GET: Bookings/Create
        public async Task<IActionResult> Create(int id, decimal price)
        {
            Booking book = new Booking();
            book.ShowId = id;
            book.TotalPrice = price;


            return View(book);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,NumOfSeats    ")] Booking booking, decimal price)
        {

            if (ModelState.IsValid)
            {
                booking.TotalPrice = price * booking.NumOfSeats;
                var showing = _context.Show
                    .Where(s => s.Id == booking.ShowId)
                    .Include(s => s.Bookings)
                    .Include(s => s.Salon)
                    .Include(s => s.Movie)
                    .SingleOrDefault();

                int remaingingSeats = (int)(showing.Salon.Seats - showing.Bookings.Sum(b => b.NumOfSeats));

                if (booking.NumOfSeats > remaingingSeats)
                {
                    return RedirectToAction("Error", "Bookings", booking);
                }
                _context.Add(booking);

                await _context.SaveChangesAsync();
                return RedirectToAction("Success", "Bookings", booking);
            }
            return RedirectToAction("Index", "Show");
        }


        // Action method that return an booking confirmation view if the booking was successfull

        public IActionResult Success(Booking booking)
        {
            return View(booking);
        }

        // Action method that return an error view if there is not enought places in the salon for the ticket that the customer wants

        public IActionResult Error(Booking booking)
        {
            return View(booking);
        }
        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["ShowId"] = new SelectList(_context.Show, "Id", "Id", booking.ShowId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowId,NumOfSeats")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
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
            ViewData["ShowId"] = new SelectList(_context.Show, "Id", "Id", booking.ShowId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.shows)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
