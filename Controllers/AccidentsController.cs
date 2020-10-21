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
    public class AccidentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccidentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Accidents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Accident.Include(a => a.LabDay).Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Accidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accident = await _context.Accident
                .Include(a => a.LabDay)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accident == null)
            {
                return NotFound();
            }

            return View(accident);
        }

        // GET: Accidents/Create
        public IActionResult Create()
        {
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Accidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Time,Type,Damages,Notes,UserId,LabDayId")] Accident accident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", accident.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accident.UserId);
            return View(accident);
        }

        // GET: Accidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accident = await _context.Accident.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", accident.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accident.UserId);
            return View(accident);
        }

        // POST: Accidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Time,Type,Damages,Notes,UserId,LabDayId")] Accident accident)
        {
            if (id != accident.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccidentExists(accident.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", accident.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accident.UserId);
            return View(accident);
        }

        // GET: Accidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accident = await _context.Accident
                .Include(a => a.LabDay)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accident == null)
            {
                return NotFound();
            }

            return View(accident);
        }

        // POST: Accidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accident = await _context.Accident.FindAsync(id);
            _context.Accident.Remove(accident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccidentExists(int id)
        {
            return _context.Accident.Any(e => e.ID == id);
        }
    }
}
