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
    public class PermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PermissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Permissions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Permission.Include(p => p.LabDay);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Permissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permission = await _context.Permission
                .Include(p => p.LabDay)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(permission);
        }

        // GET: Permissions/Create
        public IActionResult Create()
        {
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID");
            return View();
        }

        public IActionResult borrow()
        {
            
            return View();
        }

        public IActionResult work()
        {

            return View();
        }

        public IActionResult print()
        {

            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,type,name,phoneNumber,PagesNumber,Colored,BorrowedObject,ReturnDate,Returned,Work,Schedule,Notes,LabDayId")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", permission.LabDayId);
            return View(permission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> work([Bind("ID,name,phoneNumber,Date,Work,Schedule,Notes,")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                permission.type = "working";
                _context.Add(permission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(permission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> borrow([Bind("ID,name,phoneNumber,email,suervised,project,university,position,BorrowedObject,,ReturnDate,Notes")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                permission.Date = DateTime.Now;
                permission.type = "borrowing";
                _context.Add(permission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(permission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> print([Bind("ID,name,PagesNumber,Colored,Date,Notes")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                permission.type = "printing";
                
                _context.Add(permission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(permission);
        }

        // GET: Permissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permission = await _context.Permission.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", permission.LabDayId);
            return View(permission);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,type,name,phoneNumber,PagesNumber,Colored,BorrowedObject,ReturnDate,Returned,Work,Schedule,Notes,LabDayId")] Permission permission)
        {
            if (id != permission.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionExists(permission.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", permission.LabDayId);
            return View(permission);
        }

        // GET: Permissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permission = await _context.Permission
                .Include(p => p.LabDay)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permission = await _context.Permission.FindAsync(id);
            _context.Permission.Remove(permission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionExists(int id)
        {
            return _context.Permission.Any(e => e.ID == id);
        }
    }
}
