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
    public class ProjectResearchersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectResearchersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectResearchers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectResearcher.Include(p => p.Project).Include(p => p.Researcher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectResearchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectResearcher = await _context.ProjectResearcher
                .Include(p => p.Project)
                .Include(p => p.Researcher)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projectResearcher == null)
            {
                return NotFound();
            }

            return View(projectResearcher);
        }

        // GET: ProjectResearchers/Create
        public IActionResult Create()
        {
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount");
            ViewData["researcherId"] = new SelectList(_context.Set<Researcher>(), "ID", "reseacherName");
            return View();
        }

        // POST: ProjectResearchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,projectId,researcherId")] ProjectResearcher projectResearcher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectResearcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", projectResearcher.projectId);
            ViewData["researcherId"] = new SelectList(_context.Set<Researcher>(), "ID", "reseacherName", projectResearcher.researcherId);
            return View(projectResearcher);
        }

        // GET: ProjectResearchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectResearcher = await _context.ProjectResearcher.FindAsync(id);
            if (projectResearcher == null)
            {
                return NotFound();
            }
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", projectResearcher.projectId);
            ViewData["researcherId"] = new SelectList(_context.Set<Researcher>(), "ID", "reseacherName", projectResearcher.researcherId);
            return View(projectResearcher);
        }

        // POST: ProjectResearchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,projectId,researcherId")] ProjectResearcher projectResearcher)
        {
            if (id != projectResearcher.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectResearcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectResearcherExists(projectResearcher.ID))
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
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", projectResearcher.projectId);
            ViewData["researcherId"] = new SelectList(_context.Set<Researcher>(), "ID", "reseacherName", projectResearcher.researcherId);
            return View(projectResearcher);
        }

        // GET: ProjectResearchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectResearcher = await _context.ProjectResearcher
                .Include(p => p.Project)
                .Include(p => p.Researcher)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projectResearcher == null)
            {
                return NotFound();
            }

            return View(projectResearcher);
        }

        // POST: ProjectResearchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectResearcher = await _context.ProjectResearcher.FindAsync(id);
            _context.ProjectResearcher.Remove(projectResearcher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectResearcherExists(int id)
        {
            return _context.ProjectResearcher.Any(e => e.ID == id);
        }
    }
}
