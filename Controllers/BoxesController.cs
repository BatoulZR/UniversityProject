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
    public class BoxesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Boxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Box.ToListAsync());
        }

        // GET: Boxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Box
                .FirstOrDefaultAsync(m => m.ID == id);
            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // GET: Boxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Box_Name,Location")] Box box)
        {
            if (ModelState.IsValid)
            {
                _context.Add(box);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(box);
        }

        // GET: Boxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Box.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);
        }

        // POST: Boxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Box_Name,Location")] Box box)
        {
            if (id != box.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(box);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoxExists(box.ID))
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
            return View(box);
        }

        // GET: Boxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Box
                .FirstOrDefaultAsync(m => m.ID == id);
            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // POST: Boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var box = await _context.Box.FindAsync(id);
            _context.Box.Remove(box);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoxExists(int id)
        {
            return _context.Box.Any(e => e.ID == id);
        }

        // GET: Stocks/Backterias/5
        public async Task<IActionResult> Grid(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Box
                .Include(s => s.Bacterias)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (box == null)
            {
                return NotFound();
            }

            List<ItemGrid> newList = new List<ItemGrid>(121);

            for (int i = 0; i < 121; i++)
            {
                if (i == 0)
                {
                    newList.Add(new ItemGrid(0, "", 0, 0, box.ID));
                }

                else if (i <= 10 && i > 0)
                {
                    newList.Add(new ItemGrid(0, "" + i, i, 0, box.ID));
                }

                else if (i % 11 == 0)
                {
                    newList.Add(new ItemGrid(0, "" + i / 11, 0, i / 11, box.ID));
                }

                else
                {
                    bool done = false;

                    foreach (var item in box.Bacterias)
                    {
                        if (item.y * 11 + item.x == i)
                        {
                            newList.Add(new ItemGrid(item.ID, item.BacteriaName, item.x, item.y, box.ID));
                            box.Bacterias.Remove(item);
                            done = true;
                        }

                        if (done) break;
                    }

                    if (!done)
                    {
                        newList.Add(new ItemGrid(0, " ", i % 11, i / 11, box.ID));
                    }
                }

            }

            return View(newList);
        }
    }
}
