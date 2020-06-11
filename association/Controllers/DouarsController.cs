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

namespace association.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DouarsController : Controller
    {
        private readonly MyDbContext _context;

        public DouarsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Douars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Douars.ToListAsync());
        }

        // GET: Douars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Douar = await _context.Douars
                .FirstOrDefaultAsync(m => m.DouarID == id);
            if (Douar == null)
            {
                return NotFound();
            }

            return View(Douar);
        }

        // GET: Douars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Douars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomFr,NomAr")] Douar Douar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Douar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Douar);
        }

        // GET: Douars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Douar = await _context.Douars.FindAsync(id);
            if (Douar == null)
            {
                return NotFound();
            }
            return View(Douar);
        }

        // POST: Douars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DouarID,NomFr,NomAr")] Douar Douar)
        {
            if (id != Douar.DouarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Douar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DouarExists(Douar.DouarID))
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
            return View(Douar);
        }

        // GET: Douars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Douar = await _context.Douars
                .FirstOrDefaultAsync(m => m.DouarID == id);
            if (Douar == null)
            {
                return NotFound();
            }

            return View(Douar);
        }

        // POST: Douars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Douar = await _context.Douars.FindAsync(id);
            _context.Douars.Remove(Douar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DouarExists(int id)
        {
            return _context.Douars.Any(e => e.DouarID == id);
        }
    }
}
