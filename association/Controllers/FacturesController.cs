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

    public class FacturesController : Controller
    {
        private readonly MyDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FacturesController(MyDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context; _userManager = userManager;
        }

        // GET: Factures
        public async Task<IActionResult> Index(int page = 0, int size = 4, string motCle = "")
        {
            if (motCle is null) motCle = "";

            int position = page * size;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var myDbContext =
            User.IsInRole("Admin") ?
            _context.Factures.
            Where(p => p.CompteurEau.Numero.Contains(motCle) || p.CompteurEau.Client.Nom.Contains(motCle) || p.CompteurEau.Client.Prenom.Contains(motCle) || p.CompteurEau.Client.CIN.Contains(motCle) || p.CompteurEau.Client.Association.Nom.Contains(motCle))
            .OrderBy(f => f.isPayee).ThenByDescending(f => f.DateFacture).Skip(position).Take(size).Include(f => f.CompteurEau).Include(f => f.CompteurEau.Client).Include(f => f.Tarif) :
            _context.Factures.
             Where(p => p.CompteurEau.Client.AssociationID == user.AssociationID).
            Where(p => p.CompteurEau.Numero.Contains(motCle) || p.CompteurEau.Client.Nom.Contains(motCle) || p.CompteurEau.Client.Prenom.Contains(motCle) || p.CompteurEau.Client.CIN.Contains(motCle))
            .OrderBy(f => f.isPayee).ThenByDescending(f => f.DateFacture).Skip(position).Take(size).Include(f => f.CompteurEau).Include(f => f.CompteurEau.Client).Include(f => f.Tarif);

              ViewBag.currentPage = page;
            int totalPages;
            int nbCompteurs  =
             User.IsInRole("Admin") ?
            _context.Factures.
            Where(p => p.CompteurEau.Numero.Contains(motCle) || p.CompteurEau.Client.Nom.Contains(motCle) || p.CompteurEau.Client.Prenom.Contains(motCle) || p.CompteurEau.Client.CIN.Contains(motCle))
            .OrderBy(f => f.isPayee).ThenByDescending(f => f.DateFacture).Include(f => f.CompteurEau).Include(f => f.CompteurEau.Client).Include(f => f.Tarif).Count() :
            _context.Factures.
             Where(p => p.CompteurEau.Client.AssociationID == user.AssociationID).
            Where(p => p.CompteurEau.Numero.Contains(motCle) || p.CompteurEau.Client.Nom.Contains(motCle) || p.CompteurEau.Client.Prenom.Contains(motCle) || p.CompteurEau.Client.CIN.Contains(motCle))
            .OrderBy(f => f.isPayee).ThenByDescending(f => f.DateFacture).Include(f => f.CompteurEau).Include(f => f.CompteurEau.Client).Include(f => f.Tarif).Count();

            if ((nbCompteurs % size) == 0) totalPages = nbCompteurs / size;
            else totalPages = 1 + (nbCompteurs / size);

            ViewBag.totalPages = totalPages;
            ViewBag.motCle = motCle;
            return View(await myDbContext.ToListAsync());
         
        }

        // GET: Factures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //float PrixLittre = 7/1000;
            //ViewBag.PrixLittre= PrixLittre;
            var facture = await _context.Factures.Include(f => f.CompteurEau).Include(f => f.CompteurEau.Client).Include(f => f.Tarif).SingleOrDefaultAsync(m => m.FactureID == id);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }

        // GET: Factures/Create
        public async Task<IActionResult> Create(int? id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (id != null)
            {
                ViewData["CompteurEau"] =
                         User.IsInRole("Admin") ? new SelectList(_context.CompteurEaus, "CompteurEauID", "Numero") :
                         new SelectList(_context.CompteurEaus.
                         Where(p => p.Client.AssociationID == user.AssociationID), "CompteurEauID", "Numero").Where(m => m.Value == id.Value.ToString()); 
            }
            else

                ViewData["CompteurEau"] =
                    User.IsInRole("Admin") ? new SelectList(_context.CompteurEaus, "CompteurEauID", "Numero") :
                    new SelectList(_context.CompteurEaus.
                    Where(p => p.Client.AssociationID == user.AssociationID), "CompteurEauID", "Numero");

//            ViewData["CompteurEau"] = new SelectList(_context.CompteurEaus, "CompteurEauID", "Numero");

  

            ViewData["TarifID"] = new SelectList(_context.Tarifs, "TarifID", "Montant");

            var model = new Facture();
            model.DateFacture = DateTime.Now;
            model.FactureDe = DateTime.Now;
            return View(model);
         
        }

        // POST: Factures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FactureID,CompteurEauID,TarifID,DateFacture,FactureDe,Montant,ValeurCompteur,ValeurCompteurPrecedente,isPayee,Consomation")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facture);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CompteurEauID"] = new SelectList(_context.CompteurEaus, "CompteurEauID", "Numero", facture.CompteurEauID);
            ViewData["TarifID"] = new SelectList(_context.Tarifs, "TarifID", "Montant", facture.TarifID);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures.Include(f => f.CompteurEau).Include(f => f.CompteurEau.Client).Include(f => f.Tarif).SingleOrDefaultAsync(m => m.FactureID == id);
            if (facture == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["CompteurEau"] =
                User.IsInRole("Admin") ? new SelectList(_context.CompteurEaus, "CompteurEauID", "Numero") :
                new SelectList(_context.CompteurEaus.
                Where(p => p.Client.AssociationID == user.AssociationID), "CompteurEauID", "Numero");
            int i = _context.CompteurEaus.Count();
            ViewData["TarifID"] = new SelectList(_context.Tarifs, "TarifID", "Montant", facture.TarifID);

            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FactureID,CompteurEauID,TarifID,DateFacture,FactureDe,Montant,ValeurCompteur,ValeurCompteurPrecedente,isPayee,Consomation")] Facture facture)
        {
            if (id != facture.FactureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactureExists(facture.FactureID))
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
            ViewData["CompteurEauID"] = new SelectList(_context.CompteurEaus, "CompteurEauID", "Numero", facture.CompteurEauID);
            ViewData["TarifID"] = new SelectList(_context.Tarifs, "TarifID", "Montant", facture.TarifID);

            return View(facture);
        }
        [Authorize(Roles = "Admin")]

        // GET: Factures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures.Include(f => f.CompteurEau).Include(f => f.CompteurEau.Client).Include(f => f.Tarif).SingleOrDefaultAsync(m => m.FactureID == id);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }
        [Authorize(Roles = "Admin")]

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facture = await _context.Factures.SingleOrDefaultAsync(m => m.FactureID == id);
            _context.Factures.Remove(facture);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FactureExists(int id)
        {
            return _context.Factures.Any(e => e.FactureID == id);
        }
    }
}