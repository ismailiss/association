using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using association.Models;
using association.Services;
using Microsoft.AspNetCore.Authorization;
using association.Models.asso_config;
using Microsoft.AspNetCore.Identity;
using association.Data;

namespace association.Controllers
{
    [Authorize(Roles = "Admin,User")]

    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ClientsController(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
             _userManager = userManager;

        }

        // GET: Clients
        public async Task<IActionResult> Index(int page = 0, int size = 4, string motCle = "")
        {
          
            if (motCle is null) motCle = "";
            int position = page * size;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var myDbContext = User.IsInRole("Admin") ?
                _context.Clients.
                Where(p => p.Nom.Contains(motCle) || p.Prenom.Contains(motCle) || p.CIN.Contains(motCle))
                .Skip(position).Take(size).Include(c => c.Association).OrderBy(c => c.Nom) :

                _context.Clients.
                Where(p => p.AssociationID == user.AssociationID).
                Where(p => p.Nom.Contains(motCle) || p.Prenom.Contains(motCle) || p.CIN.Contains(motCle))
                .Skip(position).Take(size).Include(c => c.Association).OrderBy(c => c.Nom);

            ViewBag.currentPage = page;
            int totalPages;
            int nbCompteurs =
                User.IsInRole("Admin") ?
                _context.Clients.
                Where(p => p.Nom.Contains(motCle) || p.Prenom.Contains(motCle) || p.CIN.Contains(motCle))
                .Include(c => c.Association).OrderBy(c => c.Nom).Count() :

                _context.Clients.
                Where(p => p.AssociationID == user.AssociationID).
                Where(p => p.Nom.Contains(motCle) || p.Prenom.Contains(motCle) || p.CIN.Contains(motCle))
                .Include(c => c.Association).OrderBy(c => c.Nom).Count();

            if ((nbCompteurs % size) == 0) totalPages = nbCompteurs / size;
            else totalPages = 1 + (nbCompteurs / size);
            int aa =myDbContext.Count();
            ViewBag.totalPages = totalPages;
            ViewBag.motCle = motCle;
            return View(await myDbContext.ToListAsync()); 

           
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Association).Include(c => c.Compteurs)
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["Association"] =
                User.IsInRole("Admin") ? new SelectList(_context.Associations, "AssociationID", "Nom") :
                new SelectList(_context.Associations.
                Where(p => p.AssociationID == user.AssociationID), "AssociationID", "Nom")
                ;
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,Nom,Prenom,CIN,Adresse,Telephone,AssociationID")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["Association"] =
                User.IsInRole("Admin") ? new SelectList(_context.Associations, "AssociationID", "Nom") :
                new SelectList(_context.Associations.
                Where(p => p.AssociationID == user.AssociationID), "AssociationID", "Nom")
                ;
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["Association"] =
                User.IsInRole("Admin") ? new SelectList(_context.Associations, "AssociationID", "Nom") :
                new SelectList(_context.Associations.
                Where(p => p.AssociationID == user.AssociationID), "AssociationID", "Nom")
                ;
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,Nom,Prenom,CIN,Adresse,Telephone,AssociationID")] Client client)
        {
            if (id != client.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientID))
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

            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["Association"] =
                User.IsInRole("Admin") ? new SelectList(_context.Associations, "AssociationID", "Nom") :
                new SelectList(_context.Associations.
                Where(p => p.AssociationID == user.AssociationID), "AssociationID", "Nom")
                ;
            return View(client);
        }
        [Authorize(Roles = "Admin")]

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Association)
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }
        [Authorize(Roles = "Admin")]

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientID == id);
        }
    }
}
