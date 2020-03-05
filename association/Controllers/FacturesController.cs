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

//using iTextSharp.text;  
//using iTextSharp.text.html.simpleparser;  
//using iTextSharp.text.pdf;
using System.Text;
using System.IO;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

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

            ViewBag.totalPagecs = totalPages;
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
        // GET: Factures/Edit/5
        public async Task<IActionResult> ImprimerRecu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures.Include(f => f.CompteurEau).Include(f => f.CompteurEau.Client).Include(f => f.Tarif).SingleOrDefaultAsync(m => m.FactureID == id);
            //if (facture == null)
            //{
            //    return NotFound();
            //}
            //var user = await _userManager.GetUserAsync(HttpContext.User);

            //ViewData["CompteurEau"] =
            //    User.IsInRole("Admin") ? new SelectList(_context.CompteurEaus, "CompteurEauID", "Numero") :
            //    new SelectList(_context.CompteurEaus.
            //    Where(p => p.Client.AssociationID == user.AssociationID), "CompteurEauID", "Numero");
            //int i = _context.CompteurEaus.Count();
            //ViewData["TarifID"] = new SelectList(_context.Tarifs, "TarifID", "Montant", facture.TarifID);
            
            //StringBuilder sb = new StringBuilder();



            //sb.Append("< !DOCTYPE html >");  
            //sb.Append(" < html >");


            //sb.Append("   < head >");

            //sb.Append("< title > Coucou </ title >");

            //sb.Append("   </ head >");

            //sb.Append("< body >");
            //sb.Append("Cette page est une");
            //sb.Append(" page toute simple");
            //sb.Append("</ body >");
            //sb.Append("</ html >");
            //StringReader sr = new StringReader(sb.ToString());

            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HtmlWorker htmlparser = new HtmlWorker(pdfDoc);
            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            //    pdfDoc.Open();

            //    htmlparser.Parse(sr);
            //    pdfDoc.Close();

            //    byte[] bytes = memoryStream.ToArray();
            //    memoryStream.Close();
            //}

            //// Clears all content output from the buffer stream                 
            //Response.Clear();
            //// Gets or sets the HTTP MIME type of the output stream.
            //Response.ContentType = "application/pdf";
            //// Adds an HTTP header to the output stream
            //Response.Headers("Content-Disposition", "attachment; filename=Invoice.pdf");

            ////Gets or sets a value indicating whether to buffer output and send it after
            //// the complete response is finished processing.
            //Response.buffer = true;
            //// Sets the Cache-Control header to one of the values of System.Web.HttpCacheability.
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //// Writes a string of binary characters to the HTTP output stream. it write the generated bytes .
            //Response.BinaryWrite(bytes);
            //// Sends all currently buffered output to the client, stops execution of the
            //// page, and raises the System.Web.HttpApplication.EndRequest event.

            //Response.End();
            //// Closes the socket connection to a client. it is a necessary step as you must close the response after doing work.its best approach.
            //Response.Close();
            return View(facture);
        }

    }
}
