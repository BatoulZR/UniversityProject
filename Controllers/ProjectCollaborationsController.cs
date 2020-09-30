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
    public class ProjectCollaborationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectCollaborationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectCollaborations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectCollaboration.Include(p => p.Collaboration).Include(p => p.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectCollaborations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectCollaboration = await _context.ProjectCollaboration
                .Include(p => p.Collaboration)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projectCollaboration == null)
            {
                return NotFound();
            }

            return View(projectCollaboration);
        }

        // GET: ProjectCollaborations/Create
        public IActionResult Create()
        {
            ViewData["collaborationId"] = new SelectList(_context.Collaboration, "ID", "ID");
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount");
            return View();
        }

        // POST: ProjectCollaborations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,projectId,collaborationId")] ProjectCollaboration projectCollaboration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectCollaboration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["collaborationId"] = new SelectList(_context.Collaboration, "ID", "ID", projectCollaboration.collaborationId);
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", projectCollaboration.projectId);
            return View(projectCollaboration);
        }

        // GET: ProjectCollaborations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectCollaboration = await _context.ProjectCollaboration.FindAsync(id);
            if (projectCollaboration == null)
            {
                return NotFound();
            }
            ViewData["collaborationId"] = new SelectList(_context.Collaboration, "ID", "ID", projectCollaboration.collaborationId);
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", projectCollaboration.projectId);
            return View(projectCollaboration);
        }

        // POST: ProjectCollaborations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,projectId,collaborationId")] ProjectCollaboration projectCollaboration)
        {
            if (id != projectCollaboration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectCollaboration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectCollaborationExists(projectCollaboration.ID))
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
            ViewData["collaborationId"] = new SelectList(_context.Collaboration, "ID", "ID", projectCollaboration.collaborationId);
            ViewData["projectId"] = new SelectList(_context.Project, "ID", "fundAmount", projectCollaboration.projectId);
            return View(projectCollaboration);
        }

        // GET: ProjectCollaborations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectCollaboration = await _context.ProjectCollaboration
                .Include(p => p.Collaboration)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projectCollaboration == null)
            {
                return NotFound();
            }

            return View(projectCollaboration);
        }

        // POST: ProjectCollaborations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectCollaboration = await _context.ProjectCollaboration.FindAsync(id);
            _context.ProjectCollaboration.Remove(projectCollaboration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectCollaborationExists(int id)
        {
            return _context.ProjectCollaboration.Any(e => e.ID == id);
        }
    }
}
