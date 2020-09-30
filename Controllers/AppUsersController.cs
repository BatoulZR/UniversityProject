using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Internal;
using SeniorProject.Data;
//using SeniorProject.Migrations;

namespace SeniorProject.Controllers
{

    
    public class AppUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public AppUsersController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: AppUsers
        public async Task<IActionResult> Index()
        {
            //ViewData["RoleList"] = Items;
            //List<string> roles = new List<string> { "Admin", "Trainee", "PHD", "PHDStudent", "M2Student", "Assistant" };
            //ViewData["Role"] = new SelectList(roles);
            var user = _userManager.Users.Where( u => u.AdminConfirmation == false);
            return View(await user.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            //ViewData["RoleList"] = Items;
            //List<string> roles = new List<string> { "Admin", "Trainee", "PHD", "PHDStudent", "M2Student", "Assistant" };
            //ViewData["Role"] = new SelectList(roles);
            var user = _userManager.Users; 
            return View(await user.ToListAsync());
        }

        // GET: AppUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // GET: AppUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminConfirmation,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,firstName,lastName")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: AppUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminConfirmation,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,role")] AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserExists(appUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (appUser.AdminConfirmation)
                {
                    try
                    {
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                        var confirmEmail = await _userManager.ConfirmEmailAsync(appUser, code);
                    }
                    catch
                    {
                    }


                }
                var listClaims = await _userManager.GetClaimsAsync(appUser);
                if (listClaims.Count() == 0)
                {
                    await _userManager.AddClaimAsync(appUser, new System.Security.Claims.Claim("Role", appUser.role));
                }
                else
                {
                    var exists = false;
                    foreach (var claim in listClaims)
                    {
                        if (claim.Type.Equals("Role"))
                        {
                            exists = true;
                            await _userManager.ReplaceClaimAsync(appUser, claim, new System.Security.Claims.Claim("Role", appUser.role));
                        }
                    }
                    if (!exists)
                    {
                        await _userManager.AddClaimAsync(appUser, new System.Security.Claims.Claim("Role", appUser.role));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }
        // GET: AppUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(appUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppUserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        
        public async Task<IActionResult> Confirm(int? id )
        {

            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users.FindAsync(id);

            //await _userManager.AddClaimAsync(appUser, new System.Security.Claims.Claim("Role", appuser.role));



                appUser.AdminConfirmation = true;
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var confirmEmail = await _userManager.ConfirmEmailAsync(appUser, code);
            var updateUser = await _userManager.UpdateAsync(appUser);

                if (updateUser.Succeeded)
                {
                    await _context.SaveChangesAsync();
                }
            return RedirectToAction(nameof(Index));
                //return RedirectToAction(nameof(chooseRole),id);
            

        }

        //public async Task<IActionResult> chooseRole()
        //{
        //    var rolee = new listOfRole().userId = 1;
        //    return View();
        //}

    }
}
