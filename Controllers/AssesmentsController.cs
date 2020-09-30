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
    public class AssesmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssesmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assesments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Assesment.Include(a => a.LabDay).Include(a => a.Student).Include(a => a.Trainee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assesments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesment = await _context.Assesment
                .Include(a => a.LabDay)
                .Include(a => a.Student)
                .Include(a => a.Trainee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (assesment == null)
            {
                return NotFound();
            }

            return View(assesment);
        }

        // GET: Assesments/Create
        public IActionResult Create()
        {
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID");
            ViewData["studentId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["TraineeId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Assesments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,studentId,TraineeId,date,quality,quantity,work_habits,communication,attitude,professionalism,leadership,LabDayId")] Assesment assesment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assesment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", assesment.LabDayId);
            ViewData["studentId"] = new SelectList(_context.Users, "Id", "Id", assesment.studentId);
            ViewData["TraineeId"] = new SelectList(_context.Users, "Id", "Id", assesment.TraineeId);
            return View(assesment);
        }

        // GET: Assesments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesment = await _context.Assesment.FindAsync(id);
            if (assesment == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", assesment.LabDayId);
            ViewData["studentId"] = new SelectList(_context.Users, "Id", "Id", assesment.studentId);
            ViewData["TraineeId"] = new SelectList(_context.Users, "Id", "Id", assesment.TraineeId);
            return View(assesment);
        }

        // POST: Assesments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,studentId,TraineeId,date,quality,quantity,work_habits,communication,attitude,professionalism,leadership,LabDayId")] Assesment assesment)
        {
            if (id != assesment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assesment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssesmentExists(assesment.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", assesment.LabDayId);
            ViewData["studentId"] = new SelectList(_context.Users, "Id", "Id", assesment.studentId);
            ViewData["TraineeId"] = new SelectList(_context.Users, "Id", "Id", assesment.TraineeId);
            return View(assesment);
        }

        // GET: Assesments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesment = await _context.Assesment
                .Include(a => a.LabDay)
                .Include(a => a.Student)
                .Include(a => a.Trainee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (assesment == null)
            {
                return NotFound();
            }

            return View(assesment);
        }

        // POST: Assesments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assesment = await _context.Assesment.FindAsync(id);
            _context.Assesment.Remove(assesment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssesmentExists(int id)
        {
            return _context.Assesment.Any(e => e.ID == id);
        }
    }
}
