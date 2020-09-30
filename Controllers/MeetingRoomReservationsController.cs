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
    public class MeetingRoomReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingRoomReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeetingRoomReservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MeetingRoomReservation.Include(m => m.LabDay);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MeetingRoomReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoomReservation = await _context.MeetingRoomReservation
                .Include(m => m.LabDay)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meetingRoomReservation == null)
            {
                return NotFound();
            }

            return View(meetingRoomReservation);
        }

        // GET: MeetingRoomReservations/Create
        public IActionResult Create()
        {
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID");
            return View();
        }

        // POST: MeetingRoomReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,date,time1,time2,objective,summary,LabDayId")] MeetingRoomReservation meetingRoomReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingRoomReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", meetingRoomReservation.LabDayId);
            return View(meetingRoomReservation);
        }

        // GET: MeetingRoomReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoomReservation = await _context.MeetingRoomReservation.FindAsync(id);
            if (meetingRoomReservation == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", meetingRoomReservation.LabDayId);
            return View(meetingRoomReservation);
        }

        // POST: MeetingRoomReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,date,time1,time2,objective,summary,LabDayId")] MeetingRoomReservation meetingRoomReservation)
        {
            if (id != meetingRoomReservation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingRoomReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingRoomReservationExists(meetingRoomReservation.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", meetingRoomReservation.LabDayId);
            return View(meetingRoomReservation);
        }

        // GET: MeetingRoomReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoomReservation = await _context.MeetingRoomReservation
                .Include(m => m.LabDay)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meetingRoomReservation == null)
            {
                return NotFound();
            }

            return View(meetingRoomReservation);
        }

        // POST: MeetingRoomReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingRoomReservation = await _context.MeetingRoomReservation.FindAsync(id);
            _context.MeetingRoomReservation.Remove(meetingRoomReservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingRoomReservationExists(int id)
        {
            return _context.MeetingRoomReservation.Any(e => e.ID == id);
        }
    }
}
