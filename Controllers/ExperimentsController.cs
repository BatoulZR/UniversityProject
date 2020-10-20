using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SeniorProject.Data;
using SeniorProject.Models;
using SQLitePCL;
using Microsoft.AspNetCore.Identity;

namespace SeniorProject.Controllers
{
    public class ExperimentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        // private UserMa _userManager;

        public ExperimentsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Experiments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Experiment.Include(e => e.LabDay).Include(e => e.User).Include(e => e.project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Experiments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiment = await _context.Experiment
                .Include(e => e.LabDay)
                .Include(e => e.User)
                .Include(e => e.project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experiment == null)
            {
                return NotFound();
            }

            return View(experiment);
        }

        // GET: Experiments/Create
        public IActionResult Create()
        {
            /* ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID");
             ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
             ViewData["projectId"] = new SelectList(_context.Set<Project>(), "ID", "fundAmount");*/
            return View();
        }

        // POST: Experiments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Superv,Date,Desc")] Experiment experiment)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                experiment.User = user;
                experiment.UserId = user.Id;
                //var currentUMUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                //var user = await _userManager.GetUserAsync(HttpContext.User);
                LabDay labDay = _context.LabDay.FirstOrDefault(a => a.date.Equals(DateTime.Now.Date));
                experiment.LabDay = labDay;
                experiment.LabDayId = labDay.ID;

                //experiment.User=
                //experiment.UserId=

                /* _context.Add(experiment);
                 await _context.SaveChangesAsync();*/
                // experiment.Equipments = new ICollection<Equipment>;
                IList<Equipment> equipments = _context.Equipment.Where(a => a.inUse == false).ToList();
                //ViewBag.Equipments = equipments;
                TempData["equipments"] = JsonConvert.SerializeObject(equipments);
                TempData["experiment"] = JsonConvert.SerializeObject(experiment);
                TempData.Keep();

                

                return RedirectToAction(nameof(ReserveEquipments));

                //  return RedirectToAction(nameof(Index));
            }
            /*ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", experiment.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", experiment.UserId);
            ViewData["projectId"] = new SelectList(_context.Set<Project>(), "ID", "fundAmount", experiment.projectId);*/
            return View(experiment);
        }




        public IActionResult ReserveEquipments()
        {
            //virtual objects loose their value, null
            //error after refresh
            var experiment = TempData["experiment"];
            var equipments = TempData["equipments"];
            TempData.Keep();
            //TempData["experiment"] = experiment;
            //TempData.Keep();
            ViewBag.Equipments = JsonConvert.DeserializeObject<IList<Equipment>>((string)equipments);
            return View();
        }


        [HttpPost]
        public IActionResult Reserve(String [] equipments)
        {
            if (ModelState.IsValid)
            {
                var experiment2 = JsonConvert.DeserializeObject<Experiment>((string)TempData["experiment"]);
                //Console.WriteLine(""+equipments[1]);
                //Console.WriteLine("" + equipments[0]);
                //experiment2.Equipments = equipments;
                //lkoo

                for (int i = 0; i < equipments.Length; i++)
                {
                    Equipment equipment = _context.Equipment.FirstOrDefault(a => a.name.Equals(equipments[i]));
                   equipment.inUse = true;
                    experiment2.Equipments.Add(equipment);
                    

                }

                _context.Add(experiment2);
                _context.SaveChangesAsync();
                

                return RedirectToAction(nameof(Index));

           
            }

            return View();
        }



        // GET: Experiments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiment = await _context.Experiment.FindAsync(id);
            if (experiment == null)
            {
                return NotFound();
            }
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", experiment.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", experiment.UserId);
            ViewData["projectId"] = new SelectList(_context.Set<Project>(), "ID", "fundAmount", experiment.projectId);
            return View(experiment);
        }

        // POST: Experiments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,projectId,Title,Superv,Date,Desc,LabDayId,UserId")] Experiment experiment)
        {
            if (id != experiment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperimentExists(experiment.ID))
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
            ViewData["LabDayId"] = new SelectList(_context.Set<LabDay>(), "ID", "ID", experiment.LabDayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", experiment.UserId);
            ViewData["projectId"] = new SelectList(_context.Set<Project>(), "ID", "fundAmount", experiment.projectId);
            return View(experiment);
        }

        // GET: Experiments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiment = await _context.Experiment
                .Include(e => e.LabDay)
                .Include(e => e.User)
                .Include(e => e.project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experiment == null)
            {
                return NotFound();
            }

            return View(experiment);
        }

        // POST: Experiments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiment = await _context.Experiment.FindAsync(id);
            _context.Experiment.Remove(experiment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperimentExists(int id)
        {
            return _context.Experiment.Any(e => e.ID == id);
        }
    }
}
