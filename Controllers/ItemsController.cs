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

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
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
            return View();
        }

        // GET: Items/Create
        public IActionResult CreateMachine()
        {
            return View();
        }

        // GET: Items/Create
        public IActionResult CreateItem()
        {
            return View();
        }

        // GET: Items/Create
        public IActionResult CreateFurniture()
        {
            return View();
        }


        // GET: Items/Create
        public IActionResult CreateConsumable()
        {
            return View();
        }
        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,type,name,weight,units,quantity,arrivalDate,expiryDate,notes,room")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Item/Edit/5
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
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,type,name,weight,units,quantity,arrivalDate,expiryDate,notes,room")] Item item)
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

        public IActionResult consumables ()
        {
            var list = _context.Item.ToList<Item>();
           
            return View(list);
        }

        public IActionResult glassAndPlastic()
        {
            var list = _context.Item.ToList<Item>();

            return View(list);
        }

        public IActionResult machines()
        {
            var list = _context.Item.ToList<Item>();

            return View(list);
        }


        public IActionResult furnitures()
        {
            var list = _context.Item.ToList<Item>();

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConsumable([Bind("ID,name,weight,units,quantity,arrivalDate,expiryDate,notes,room")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.type = "Consumable";
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(consumables));
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGlass([Bind("ID,name,weight,units,quantity,arrivalDate,expiryDate,notes,room")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.type = "Item";
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(glassAndPlastic));
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFurniture([Bind("ID,name,weight,units,quantity,arrivalDate,expiryDate,notes,room")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.type = "Furniture";
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(furnitures));
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMachine([Bind("ID,name,serialNumber,calibration,quantity,arrivalDate,notes,room")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.type = "Machine";
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(machines));
            }
            return View(item);
        }

    }
}
