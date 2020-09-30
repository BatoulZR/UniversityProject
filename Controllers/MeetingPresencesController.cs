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
    public class MeetingPresencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingPresencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeetingPresences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MeetingPresence.Include(m => m.User).Include(m => m.meetingRR);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MeetingPresences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPresence = await _context.MeetingPresence
                .Include(m => m.User)
                .Include(m => m.meetingRR)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meetingPresence == null)
            {
                return NotFound();
            }

            return View(meetingPresence);
        }

        // GET: MeetingPresences/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["mrrId"] = new SelectList(_context.Set<MeetingRoomReservation>(), "ID", "objective");
            return View();
        }

        // POST: MeetingPresences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserId,name,mrrId")] MeetingPresence meetingPresence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingPresence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", meetingPresence.UserId);
            ViewData["mrrId"] = new SelectList(_context.Set<MeetingRoomReservation>(), "ID", "objective", meetingPresence.mrrId);
            return View(meetingPresence);
        }

        // GET: MeetingPresences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPresence = await _context.MeetingPresence.FindAsync(id);
            if (meetingPresence == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", meetingPresence.UserId);
            ViewData["mrrId"] = new SelectList(_context.Set<MeetingRoomReservation>(), "ID", "objective", meetingPresence.mrrId);
            return View(meetingPresence);
        }

        // POST: MeetingPresences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserId,name,mrrId")] MeetingPresence meetingPresence)
        {
            if (id != meetingPresence.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingPresence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingPresenceExists(meetingPresence.ID))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", meetingPresence.UserId);
            ViewData["mrrId"] = new SelectList(_context.Set<MeetingRoomReservation>(), "ID", "objective", meetingPresence.mrrId);
            return View(meetingPresence);
        }

        // GET: MeetingPresences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPresence = await _context.MeetingPresence
                .Include(m => m.User)
                .Include(m => m.meetingRR)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meetingPresence == null)
            {
                return NotFound();
            }

            return View(meetingPresence);
        }

        // POST: MeetingPresences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingPresence = await _context.MeetingPresence.FindAsync(id);
            _context.MeetingPresence.Remove(meetingPresence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingPresenceExists(int id)
        {
            return _context.MeetingPresence.Any(e => e.ID == id);
        }
    }
}
