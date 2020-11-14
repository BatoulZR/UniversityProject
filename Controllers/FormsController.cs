using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorProject.Data;
using SeniorProject.Models;

namespace SeniorProject.Controllers
{
    public class FormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Form.Include(f => f.LabDay).Where(f => f.requestStatus == false);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;
            var forms = from f in _context.Form
                        select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.requestType.Contains(searchString));

            }

            return View(await forms.AsNoTracking().Where(f => f.requestStatus == false).ToListAsync());

        }


        // GET: Forms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form
                .Include(f => f.LabDay)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // GET: Forms/Create
        public IActionResult CreateMembership()
        {
          
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
        public IActionResult CreateInternship()
        {

            return View();
        }

        public IActionResult Thanks()
        {

            return View();
        }

        public IActionResult CreateFreeForm()
        {

            return View();
        }

        public IActionResult CreateTrainingPre()
        {

            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMembership([Bind("ID,StudentID,firstname,fathername,lastname,phone,email,requestStatus")] Form form)
        {
            if (ModelState.IsValid)
            {
                form.date = DateTime.Now;
                form.requestType = "Membership";
                form.requestStatus = false;
                

                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Thanks));
            }
           
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInternship([Bind("ID,StudentID,firstname,fathername,lastname,phone,email,place,duration")] Form form)
        {
            if (ModelState.IsValid)
            {
                form.date = DateTime.Now;
                form.requestType = "Internship";
                form.requestStatus = false;
                
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Thanks));
            }
           
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTrainingPre([Bind("ID,StudentID,firstname,fathername,lastname,phone,email,speciality,year,duration")] Form form)
        {
            if (ModelState.IsValid)
            {
                form.date = DateTime.Now;
                form.requestType = "Training Pre-Registration";
                form.requestStatus = false;
           
                
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Thanks));
            }
            
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFreeForm([Bind("ID,StudentID,firstname,fathername,lastname,phone,email,requestStatus,Paragraph")] Form form)
        {
            if (ModelState.IsValid)
            {
                form.date = DateTime.Now;
                form.requestType = "Free Form";
                form.requestStatus = false;
                //LabDay labDay = _context.LabDay.FirstOrDefault(a => a.date == DateTime.Now);
                //form.LabDayId = labDay.ID;
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Thanks));
            }
           
            return View(form);
        }

        // GET: Forms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            
            return View(form);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StudentID,firstname,fathername,lastname,phone,requestType,email,speciality,year,requestStatus,date,place,duration,Paragraph,LabDayId")] Form form)
        {
            if (id != form.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(form);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormExists(form.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.LabDay, "ID", "ID", form.LabDayId);
            return View(form);
        }

        // GET: Forms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form
                .Include(f => f.LabDay)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var form = await _context.Form.FindAsync(id);
            _context.Form.Remove(form);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(int id)
        {
            return _context.Form.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Confirm(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form.FindAsync(id);

            if (form == null)
            {
                return NotFound();
            }
            form.requestStatus = true;
            var updte = _context.Form.Update(form);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

            //var updateForm =  _context.Form.Update(form);
            ////await _context.SaveChangesAsync();



        }





    }




    }

