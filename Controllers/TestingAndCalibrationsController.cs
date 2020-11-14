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
    public class TestingAndCalibrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestingAndCalibrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestingAndCalibrations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TestingAndCalibration.Include(t => t.LabDay).Include(t => t.User).Include(t => t.item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TestingAndCalibrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testingAndCalibration = await _context.TestingAndCalibration
                .Include(t => t.LabDay)
                .Include(t => t.User)
                .Include(t => t.item)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testingAndCalibration == null)
            {
                return NotFound();
            }

            return View(testingAndCalibration);
        }

        // GET: TestingAndCalibrations/Create
        public IActionResult Create()
        {
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ItemId"] = new SelectList(_context.Item, "ID", "ID");
            return View();
        }

        // POST: TestingAndCalibrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,machineId,UserId,date,nextCheck,LabDayId")] TestingAndCalibration testingAndCalibration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testingAndCalibration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", testingAndCalibration.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", testingAndCalibration.UserId);
            ViewData["machineId"] = new SelectList(_context.Item, "ID", "ID", testingAndCalibration.ID);
            return View(testingAndCalibration);
        }

        // GET: TestingAndCalibrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testingAndCalibration = await _context.TestingAndCalibration.FindAsync(id);
            if (testingAndCalibration == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", testingAndCalibration.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", testingAndCalibration.UserId);
            ViewData["machineId"] = new SelectList(_context.Item, "ID", "ID", testingAndCalibration.ItemId);
            return View(testingAndCalibration);
        }

        // POST: TestingAndCalibrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,machineId,UserId,date,nextCheck,LabDayId")] TestingAndCalibration testingAndCalibration)
        {
            if (id != testingAndCalibration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testingAndCalibration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestingAndCalibrationExists(testingAndCalibration.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", testingAndCalibration.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", testingAndCalibration.UserId);
            ViewData["machineId"] = new SelectList(_context.Item, "ID", "ID", testingAndCalibration.ItemId);
            return View(testingAndCalibration);
        }

        // GET: TestingAndCalibrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testingAndCalibration = await _context.TestingAndCalibration
                .Include(t => t.LabDay)
                .Include(t => t.User)
                .Include(t => t.item)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testingAndCalibration == null)
            {
                return NotFound();
            }

            return View(testingAndCalibration);
        }

        // POST: TestingAndCalibrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testingAndCalibration = await _context.TestingAndCalibration.FindAsync(id);
            _context.TestingAndCalibration.Remove(testingAndCalibration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestingAndCalibrationExists(int id)
        {
            return _context.TestingAndCalibration.Any(e => e.ID == id);
        }
    }
}
