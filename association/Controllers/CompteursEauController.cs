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

namespace association.Controllers
{
    [Authorize(Roles = "Admin,User")]

    public class CompteursEauController : Controller
    {
        private readonly MyDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CompteursEauController(MyDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: CompteursEau
        public async Task<IActionResult> Index(int page = 0, int size = 4, string motCle = "")
        {
            if (motCle is null) motCle = "";

            int position = page * size;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var myDbContext = User.IsInRole("Admin") ?
                _context.CompteurEaus.
                Where(p => p.Numero.Contains(motCle) || p.Client.Nom.Contains(motCle) || p.Client.Prenom.Contains(motCle) || p.Client.CIN.Contains(motCle) || p.Client.Association.Nom.Contains(motCle))
                .Include(c => c.Client).OrderByDescending(c => c.Actif).ThenBy(c => c.Client.NomPrenom)
                .Skip(position).Take(size) :
 
                _context.CompteurEaus.
                Where(p => p.Client.AssociationID == user.AssociationID).
                Where(p => p.Numero.Contains(motCle) || p.Client.Nom.Contains(motCle) || p.Client.Prenom.Contains(motCle) || p.Client.CIN.Contains(motCle))
                .Include(c => c.Client).OrderByDescending(c => c.Actif).ThenBy(c => c.Client.NomPrenom)
                .Skip(position).Take(size);
            ViewBag.currentPage = page;
            int totalPages;
            int nbCompteurs = User.IsInRole("Admin") ?
                _context.CompteurEaus.
                Where(p => p.Numero.Contains(motCle) || p.Client.Nom.Contains(motCle) || p.Client.Prenom.Contains(motCle) || p.Client.CIN.Contains(motCle))
                .Include(c => c.Client).OrderByDescending(c => c.Actif).ThenBy(c => c.Client.NomPrenom)
                .Count() :

                _context.CompteurEaus.
                Where(p => p.Client.AssociationID == user.AssociationID).
                Where(p => p.Numero.Contains(motCle) || p.Client.Nom.Contains(motCle) || p.Client.Prenom.Contains(motCle) || p.Client.CIN.Contains(motCle))
                .Include(c => c.Client).OrderByDescending(c => c.Actif).ThenBy(c => c.Client.NomPrenom)
                .Count();
            if ((nbCompteurs % size) == 0) totalPages = nbCompteurs / size;
            else totalPages = 1 + (nbCompteurs / size);

            ViewBag.totalPages = totalPages;
            ViewBag.motCle = motCle;
            return View(await myDbContext.ToListAsync());

            //var myDbContext = _context.CompteurEaus.Include(c => c.Client);
          




        }

        // GET: CompteursEau/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compteurEau = await _context.CompteurEaus.Include(c => c.Factures)
                .Include(c => c.Client).SingleOrDefaultAsync(m => m.CompteurEauID == id);
            if (compteurEau == null)
            {
                return NotFound();
            }

            return View(compteurEau);
        }

        // GET: CompteursEau/Create
        public async Task<IActionResult> Create(int? id)
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (id != null)
            {

                ViewData["Client"] =
               User.IsInRole("Admin") ? new SelectList(_context.Clients, "ClientID", "NomPrenom") :
               new SelectList(_context.Clients.
               Where(p => p.AssociationID == user.AssociationID), "ClientID", "NomPrenom").Where(m => m.Value == id.Value.ToString());

                //ViewData["Client"] = new SelectList(_context.Clients, "ClientID", "NomPrenom").Where(m => m.Value == id.Value.ToString());
            }
            else
                ViewData["Client"] =
                User.IsInRole("Admin") ? new SelectList(_context.Clients, "ClientID", "NomPrenom") :
                new SelectList(_context.Clients.
                Where(p => p.AssociationID == user.AssociationID),  "ClientID", "NomPrenom");

            var model = new CompteurEau();
            model.DateDebut = DateTime.Now;
            return View(model);

        }

        // POST: CompteursEau/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompteurEauID,Actif,ClientID,DateDebut,DateFin,Emplacement,Numero")] CompteurEau compteurEau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compteurEau);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Client"] = new SelectList(_context.Clients, "ClientID", "NomPrenom", compteurEau.ClientID);
            return View(compteurEau);
        }

        // GET: CompteursEau/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compteurEau = await _context.CompteurEaus.SingleOrDefaultAsync(m => m.CompteurEauID == id);
            if (compteurEau == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["Client"] =
                User.IsInRole("Admin") ? new SelectList(_context.Clients, "ClientID", "NomPrenom") :
                new SelectList(_context.Clients.
                Where(p => p.AssociationID == user.AssociationID), "ClientID", "NomPrenom"); return View(compteurEau);
        }

        // POST: CompteursEau/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompteurEauID,Actif,ClientID,DateDebut,DateFin,Emplacement,Numero")] CompteurEau compteurEau)
        {
            if (id != compteurEau.CompteurEauID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compteurEau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompteurEauExists(compteurEau.CompteurEauID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["Client"] = new SelectList(_context.Clients, "ClientID", "NomPrenom", compteurEau.ClientID);
            return View(compteurEau);
        }
        [Authorize(Roles = "Admin")]

        // GET: CompteursEau/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compteurEau = await _context.CompteurEaus.SingleOrDefaultAsync(m => m.CompteurEauID == id);
            if (compteurEau == null)
            {
                return NotFound();
            }

            return View(compteurEau);
        }
        [Authorize(Roles = "Admin")]

        // POST: CompteursEau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compteurEau = await _context.CompteurEaus.SingleOrDefaultAsync(m => m.CompteurEauID == id);
            _context.CompteurEaus.Remove(compteurEau);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompteurEauExists(int id)
        {
            return _context.CompteurEaus.Any(e => e.CompteurEauID == id);
        }
    }
}
