using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AGWADProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace AGWADProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarsController : Controller
    {
        private readonly AGDbContext _context;

        public CarsController(AGDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var aGDbContext = _context.Cars.Include(c => c.Category).Include(c => c.FuelType).Include(c => c.TractionType).Include(c => c.TransmissionType);
            return View(await aGDbContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.FuelType)
                .Include(c => c.TractionType)
                .Include(c => c.TransmissionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["FuelTypeId"] = new SelectList(_context.FuelTypes, "Id", "Name");
            ViewData["TractionTypeId"] = new SelectList(_context.TractionTypes, "Id", "Name");
            ViewData["TransmissionTypeId"] = new SelectList(_context.TransmissionTypes, "Id", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Year,CategoryId,FuelTypeId,TractionTypeId,TransmissionTypeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", car.CategoryId);
            ViewData["FuelTypeId"] = new SelectList(_context.FuelTypes, "Id", "Id", car.FuelTypeId);
            ViewData["TractionTypeId"] = new SelectList(_context.TractionTypes, "Id", "Id", car.TractionTypeId);
            ViewData["TransmissionTypeId"] = new SelectList(_context.TransmissionTypes, "Id", "Id", car.TransmissionTypeId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", car.CategoryId);
            ViewData["FuelTypeId"] = new SelectList(_context.FuelTypes, "Id", "Id", car.FuelTypeId);
            ViewData["TractionTypeId"] = new SelectList(_context.TractionTypes, "Id", "Id", car.TractionTypeId);
            ViewData["TransmissionTypeId"] = new SelectList(_context.TransmissionTypes, "Id", "Id", car.TransmissionTypeId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Year,CategoryId,FuelTypeId,TractionTypeId,TransmissionTypeId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", car.CategoryId);
            ViewData["FuelTypeId"] = new SelectList(_context.FuelTypes, "Id", "Id", car.FuelTypeId);
            ViewData["TractionTypeId"] = new SelectList(_context.TractionTypes, "Id", "Id", car.TractionTypeId);
            ViewData["TransmissionTypeId"] = new SelectList(_context.TransmissionTypes, "Id", "Id", car.TransmissionTypeId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.FuelType)
                .Include(c => c.TractionType)
                .Include(c => c.TransmissionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
