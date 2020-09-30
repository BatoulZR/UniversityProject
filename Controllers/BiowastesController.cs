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
    public class BiowastesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BiowastesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Biowastes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Biowaste.Include(b => b.Company).Include(b => b.Experiment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Biowastes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biowaste = await _context.Biowaste
                .Include(b => b.Company)
                .Include(b => b.Experiment)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (biowaste == null)
            {
                return NotFound();
            }

            return View(biowaste);
        }

        // GET: Biowastes/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Set<Company>(), "ID", "ID");
            ViewData["ExperimentId"] = new SelectList(_context.Set<Experiment>(), "ID", "ID");
            return View();
        }

        // POST: Biowastes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CompanyId,Boxnum,weight,date,ExperimentId")] Biowaste biowaste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biowaste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Set<Company>(), "ID", "ID", biowaste.CompanyId);
            ViewData["ExperimentId"] = new SelectList(_context.Set<Experiment>(), "ID", "ID", biowaste.ExperimentId);
            return View(biowaste);
        }

        // GET: Biowastes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biowaste = await _context.Biowaste.FindAsync(id);
            if (biowaste == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Set<Company>(), "ID", "ID", biowaste.CompanyId);
            ViewData["ExperimentId"] = new SelectList(_context.Set<Experiment>(), "ID", "ID", biowaste.ExperimentId);
            return View(biowaste);
        }

        // POST: Biowastes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CompanyId,Boxnum,weight,date,ExperimentId")] Biowaste biowaste)
        {
            if (id != biowaste.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biowaste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiowasteExists(biowaste.ID))
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
            ViewData["CompanyId"] = new SelectList(_context.Set<Company>(), "ID", "ID", biowaste.CompanyId);
            ViewData["ExperimentId"] = new SelectList(_context.Set<Experiment>(), "ID", "ID", biowaste.ExperimentId);
            return View(biowaste);
        }

        // GET: Biowastes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biowaste = await _context.Biowaste
                .Include(b => b.Company)
                .Include(b => b.Experiment)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (biowaste == null)
            {
                return NotFound();
            }

            return View(biowaste);
        }

        // POST: Biowastes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biowaste = await _context.Biowaste.FindAsync(id);
            _context.Biowaste.Remove(biowaste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiowasteExists(int id)
        {
            return _context.Biowaste.Any(e => e.ID == id);
        }
    }
}
