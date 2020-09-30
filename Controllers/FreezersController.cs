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
    public class FreezersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FreezersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Freezers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Freezer.ToListAsync());
        }

        // GET: Freezers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer = await _context.Freezer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (freezer == null)
            {
                return NotFound();
            }

            return View(freezer);
        }

        // GET: Freezers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Freezers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,temperature,Cons,BoxName,BoxType,LevelNum,Side,LevSide")] Freezer freezer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freezer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(freezer);
        }

        // GET: Freezers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer = await _context.Freezer.FindAsync(id);
            if (freezer == null)
            {
                return NotFound();
            }
            return View(freezer);
        }

        // POST: Freezers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,temperature,Cons,BoxName,BoxType,LevelNum,Side,LevSide")] Freezer freezer)
        {
            if (id != freezer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freezer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreezerExists(freezer.ID))
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
            return View(freezer);
        }

        // GET: Freezers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer = await _context.Freezer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (freezer == null)
            {
                return NotFound();
            }

            return View(freezer);
        }

        // POST: Freezers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freezer = await _context.Freezer.FindAsync(id);
            _context.Freezer.Remove(freezer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreezerExists(int id)
        {
            return _context.Freezer.Any(e => e.ID == id);
        }
    }
}
