using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorProject.Data;
using SeniorProject.Models;

namespace SeniorProject.Controllers
{
    public class RotationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RotationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rotations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rotation.Include(r => r.LabDay).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rotations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotation = await _context.Rotation
                .Include(r => r.LabDay)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rotation == null)
            {
                return NotFound();
            }

            return View(rotation);
        }

        // GET: Rotations/Create
        public IActionResult Create()
        {
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Rotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,entrancePermission,photosAndDemandLetter,inventory,cafeteriaFees,eventsAndCeremonies,stockUpdates,orderingConsumables,month,year,LabDayId,UserId")] Rotation rotation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", rotation.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rotation.UserId);
            return View(rotation);
        }

        // GET: Rotations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotation = await _context.Rotation.FindAsync(id);
            if (rotation == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", rotation.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rotation.UserId);
            return View(rotation);
        }

        // POST: Rotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,entrancePermission,photosAndDemandLetter,inventory,cafeteriaFees,eventsAndCeremonies,stockUpdates,orderingConsumables,month,year,LabDayId,UserId")] Rotation rotation)
        {
            if (id != rotation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rotation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RotationExists(rotation.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", rotation.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rotation.UserId);
            return View(rotation);
        }

        // GET: Rotations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotation = await _context.Rotation
                .Include(r => r.LabDay)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rotation == null)
            {
                return NotFound();
            }

            return View(rotation);
        }

        // POST: Rotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rotation = await _context.Rotation.FindAsync(id);
            _context.Rotation.Remove(rotation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RotationExists(int id)
        {
            return _context.Rotation.Any(e => e.ID == id);
        }
    }
}
