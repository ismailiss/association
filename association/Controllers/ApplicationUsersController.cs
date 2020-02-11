using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using association.Models;
using association.Services;
using association.Models.asso_config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using association.Data;

namespace association.Controllers
{
    [Authorize(Roles = "Admin")]
    //[Authorize(Policy = "RequireAdminRole")]
    public class ApplicationUsers : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUsers(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ApplicationUsers.Include(c => c.Association);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers
                .Include(c => c.Association)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {

            ViewData["Association"] = new SelectList(_context.Associations, "AssociationID", "Nom");
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,Telephone,AssociationID")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    Nom =  applicationUser.Nom,
                    Prenom = applicationUser.Prenom,
                    Email = applicationUser.Email,
                   UserName = applicationUser.Email,

                    AssociationID = applicationUser.AssociationID
                };
                var result = await _userManager.CreateAsync(user, "Asso@1000");

                await _userManager.AddToRoleAsync(user, "User");
                
                //_context.Add(applicationUser);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationID"] = new SelectList(_context.Associations, "AssociationID", "Nom", applicationUser.AssociationID);
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            ViewData["AssociationID"] = new SelectList(_context.Associations, "AssociationID", "Nom", applicationUser.AssociationID);
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nom,Prenom,Email,PhoneNumber,AssociationID")] ApplicationUser applicationUser)
        {
            ApplicationUser applicationUser1 = await _userManager.FindByIdAsync(id);
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
              
                    applicationUser1.Email = applicationUser.Email;

                    applicationUser1.Nom = applicationUser.Nom;
                    applicationUser1.Prenom = applicationUser.Prenom;
                    applicationUser1.PhoneNumber = applicationUser.PhoneNumber;
                
                    applicationUser1.AssociationID = applicationUser.AssociationID;
                   //applicationUser1.UserName = applicationUser.Nom;


                   var Result = await _userManager.UpdateAsync(applicationUser1);
                   // await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    //if (!ApplicationUserExists(applicationUser.Id))
                    //{
                        foreach (var entry in ex.Entries)
                        {
                            if (entry.Entity is ApplicationUser)
                            {
                                var proposedValues = entry.CurrentValues;
                                var databaseValues = entry.GetDatabaseValues();

                                foreach (var property in proposedValues.Properties)
                                {
                                    var proposedValue = proposedValues[property];
                                    var databaseValue = databaseValues[property];

                                    // TODO: decide which value should be written to database
                                    // proposedValues[property] = <value to be saved>;
                                }

                                // Refresh original values to bypass next concurrency check
                                entry.OriginalValues.SetValues(databaseValues);
                            }
                            else
                            {
                                throw new NotSupportedException(
                                    "Don't know how to handle concurrency conflicts for "
                                    + entry.Metadata.Name);
                            }
                        }
                        //return NotFound();
                      

                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationID"] = new SelectList(_context.Associations, "AssociationID", "Nom", applicationUser.AssociationID);
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers
                .Include(c => c.Association)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }

}
