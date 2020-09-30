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
    public class BacteriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BacteriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bacteria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bacteria.ToListAsync());
        }

        // GET: Bacteria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacteria = await _context.Bacteria
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bacteria == null)
            {
                return NotFound();
            }

            return View(bacteria);
        }

        // GET: Bacteria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bacteria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BacteriaName,x,y,boxID")] Bacteria bacteria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bacteria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bacteria);
        }

        // GET: Bacteria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacteria = await _context.Bacteria.FindAsync(id);
            if (bacteria == null)
            {
                return NotFound();
            }
            return View(bacteria);
        }

        // POST: Bacteria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BacteriaName,x,y,boxID")] Bacteria bacteria)
        {
            if (id != bacteria.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bacteria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BacteriaExists(bacteria.ID))
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
            return View(bacteria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GridBacteria(int id, [Bind("ID,BacteriaName,x,y,boxID")] Bacteria bacteria)
        {
            if (id != bacteria.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bacteria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BacteriaExists(bacteria.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Grid", "Boxes",bacteria.boxID);
                //return View("/Views/Boxes/Grid.cshtml");
            }
            return View(bacteria);
        }


        // GET: Bacteria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacteria = await _context.Bacteria
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bacteria == null)
            {
                return NotFound();
            }

            return View(bacteria);
        }

        // POST: Bacteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bacteria = await _context.Bacteria.FindAsync(id);
            _context.Bacteria.Remove(bacteria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BacteriaExists(int id)
        {
            return _context.Bacteria.Any(e => e.ID == id);
        }

        // GET: Bacterias/CreateBacteria/1/1
        public IActionResult CreateBacteria(int X, int Y, int boxID)
        {
            var bacteria = new Bacteria();
            bacteria.x = X;
            bacteria.y = Y;
            bacteria.boxID = boxID;
            return View(bacteria);
        }
    }
}
