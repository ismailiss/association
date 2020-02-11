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
using association.Data;

namespace association.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FacturesGenereesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturesGenereesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturesGenerees
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.FacturesGeneree.Include(f => f.Association);
            return View(await myDbContext.ToListAsync());
        }

        // GET: FacturesGenerees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturesGeneree = await _context.FacturesGeneree
                .Include(f => f.Association).Include(c => c.Factures)
                
                .FirstOrDefaultAsync(m => m.FacturesGenereeID == id);
            if (facturesGeneree == null)
            {
                return NotFound();
            }

            return View(facturesGeneree);
        }

        // GET: FacturesGenerees/Create
        public IActionResult Create()
        {
            ViewData["AssociationID"] = new SelectList(_context.Associations, "AssociationID", "Nom");
            var model = new FacturesGeneree();
            model.DateFactures  = DateTime.Now;
            model.FactureDe = DateTime.Now;
            model.DateGeneration = DateTime.Now;


            return View(model);
        }

        // POST: FacturesGenerees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacturesGenereeID,DateFactures,DateGeneration,FactureDe,AssociationID")] FacturesGeneree facturesGeneree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturesGeneree);
                
                List<CompteurEau> compteurs = _context.CompteurEaus.Where(c => c.Actif == true && c.Client.AssociationID == facturesGeneree.AssociationID).ToList();
                for(int i=0;i< compteurs.Count();i++)
                {
                    Facture facture = new Facture();
                    facture.CompteurEauID = compteurs[i].CompteurEauID;
       
                    facture.DateFacture = facturesGeneree.DateFactures;
                    facture.FactureDe = facturesGeneree.FactureDe;
                    facture.FacturesGenereeID = facturesGeneree.FacturesGenereeID;
                    var f = await _context.Factures.OrderByDescending(m => m.FactureDe).FirstOrDefaultAsync(m => m.CompteurEauID == compteurs[i].CompteurEauID);
                    if(f != null)
                    facture.ValeurCompteurPrecedente = f.ValeurCompteur;
                    facture.isPayee = false;
                    _context.Add(facture);
                    facturesGeneree.Factures.Add(facture);

                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationID"] = new SelectList(_context.Associations, "AssociationID", "AssociationID", facturesGeneree.AssociationID);
            return View(facturesGeneree);
        }

        // GET: FacturesGenerees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturesGeneree = await _context.FacturesGeneree.FindAsync(id);
            if (facturesGeneree == null)
            {
                return NotFound();
            }
            ViewData["AssociationID"] = new SelectList(_context.Associations, "AssociationID", "AssociationID", facturesGeneree.AssociationID);
            return View(facturesGeneree);
        }

        // POST: FacturesGenerees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacturesGenereeID,DateFactures,DateGeneration,FactureDe,AssociationID")] FacturesGeneree facturesGeneree)
        {
            if (id != facturesGeneree.FacturesGenereeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturesGeneree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturesGenereeExists(facturesGeneree.FacturesGenereeID))
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
            ViewData["AssociationID"] = new SelectList(_context.Associations, "AssociationID", "AssociationID", facturesGeneree.AssociationID);
            return View(facturesGeneree);
        }

        // GET: FacturesGenerees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturesGeneree = await _context.FacturesGeneree
                .Include(f => f.Association)
                .FirstOrDefaultAsync(m => m.FacturesGenereeID == id);
            if (facturesGeneree == null)
            {
                return NotFound();
            }

            return View(facturesGeneree);
        }

        // POST: FacturesGenerees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturesGeneree = await _context.FacturesGeneree.FindAsync(id);
            _context.FacturesGeneree.Remove(facturesGeneree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturesGenereeExists(int id)
        {
            return _context.FacturesGeneree.Any(e => e.FacturesGenereeID == id);
        }
    }
}
