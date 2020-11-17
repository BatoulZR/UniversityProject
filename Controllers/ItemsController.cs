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
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Item.ToListAsync());
        }

        public IActionResult ConsumableIndex()
        {
            var list = _context.Item.ToList<Item>();

            return View(list);
        }

        public IActionResult GlasswareIndex()
        {
            var list = _context.Item.ToList<Item>();

            return View(list);
        }

        public IActionResult MachineIndex()
        {
            var list = _context.Item.ToList<Item>();

            return View(list);
        }


        public IActionResult FurnitureIndex()
        {
            var list = _context.Item.ToList<Item>();

            return View(list);
        }


        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Experiment)
                .Include(i => i.company)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["ExId"] = new SelectList(_context.Experiment, "ID", "ID");
            ViewData["CompanyId"] = new SelectList(_context.Company, "ID", "ID");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,type,name,Capacity,serialNumber,lotNumber,weight,units,quantity,arrivalDate,expiryDate,notes,room,price,calibration,inUse,expired,remainingQuantity,quantityUsed,from,to,ExId,CompanyId")] Item item)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExId"] = new SelectList(_context.Experiment, "ID", "ID", item.ExId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "ID", "ID", item.CompanyId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ExId"] = new SelectList(_context.Experiment, "ID", "ID", item.ExId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "ID", "ID", item.CompanyId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,type,name,Capacity,serialNumber,lotNumber,weight,units,quantity,arrivalDate,expiryDate,notes,room,price,calibration,inUse,expired,remainingQuantity,quantityUsed,from,to,ExId,CompanyId")] Item item)
        {
            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ID))
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
            ViewData["ExId"] = new SelectList(_context.Experiment, "ID", "ID", item.ExId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "ID", "ID", item.CompanyId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Experiment)
                .Include(i => i.company)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ID == id);
        }
    }
}
