﻿using System;
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
    public class CollaborationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollaborationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Collaborations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Collaboration.Include(c => c.LabDay);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Collaborations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaboration = await _context.Collaboration
                .Include(c => c.LabDay)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (collaboration == null)
            {
                return NotFound();
            }

            return View(collaboration);
        }

        // GET: Collaborations/Create
        public IActionResult Create()
        {
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID");
            return View();
        }

        // POST: Collaborations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ColabboratorName,Institute,Compounds,Position,phdM2,Test,LabDayId")] Collaboration collaboration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaboration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", collaboration.LabDayId);
            return View(collaboration);
        }

        // GET: Collaborations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaboration = await _context.Collaboration.FindAsync(id);
            if (collaboration == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", collaboration.LabDayId);
            return View(collaboration);
        }

        // POST: Collaborations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ColabboratorName,Institute,Compounds,Position,phdM2,Test,LabDayId")] Collaboration collaboration)
        {
            if (id != collaboration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaboration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaborationExists(collaboration.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", collaboration.LabDayId);
            return View(collaboration);
        }

        // GET: Collaborations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaboration = await _context.Collaboration
                .Include(c => c.LabDay)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (collaboration == null)
            {
                return NotFound();
            }

            return View(collaboration);
        }

        // POST: Collaborations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collaboration = await _context.Collaboration.FindAsync(id);
            _context.Collaboration.Remove(collaboration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaborationExists(int id)
        {
            return _context.Collaboration.Any(e => e.ID == id);
        }
    }
}
