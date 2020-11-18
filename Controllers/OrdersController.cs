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
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
                var applicationDbContext = _context.Order.Include(o => o.LabDay).Include(o => o.User).Include(o => o.project) ;
                return View(await applicationDbContext.ToListAsync());
            
            
        }

        [HttpGet]
        //public async Task<IActionResult> Index(string searchString)
        //{

        //    ViewData["CurrentFilter"] = searchString;
        //    var orders = from o in _context.Order
        //                select o;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        orders = orders.Where(o => o.productName.Contains(searchString));

        //    }

        //    return View(await orders.AsNoTracking().Where(o => o.productName.Equals(false)).ToListAsync());

        //}

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.LabDay)
                .Include(o => o.User)
                .Include(o => o.project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,productName,supervisorName,quantity,specifityNotes,dateOfOrder,dateOfUsage,confirmed,LabDayId,compId,UserId,projectId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", order.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", order.projectId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", order.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", order.projectId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,productName,supervisorName,quantity,specifityNotes,dateOfOrder,dateOfUsage,confirmed,LabDayId,compId,UserId,projectId")] Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", order.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", order.projectId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.LabDay)
                .Include(o => o.User)
                .Include(o => o.project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Confirm(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            order.confirmed= true;
            var updte = _context.Order.Update(order);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

            //var updateForm =  _context.Form.Update(form);
            ////await _context.SaveChangesAsync();



        }





    }
}
