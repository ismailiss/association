using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using association.Services;
using association.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace association.Controllers
{

    public class CompteurEauController : Controller
    {
        public MyDbContext dbContext { get; set; }
        public CompteurEauController(MyDbContext db)
        {
            this.dbContext = db;
        }
        // GET: /CompteurEaus/Index
        public IActionResult Index(int page=0,int size =3,string motCle="" )
        {
            if (motCle is null) motCle = "";
            int position = page * size;
            IEnumerable<CompteurEau> CompteurEaus = dbContext.CompteurEaus.
                Where(p=>p.Numero.Contains(motCle))
                .Skip(position).Take(size).Include(c=>c.Client).
                //Include(c => c.Douar).
                ToList();
            ViewBag.currentPage = page;
            int totalPages;
            int nbCompteurs = dbContext.CompteurEaus.
                Where(p => p.Numero.Contains(motCle))
                .ToList().Count;
            if ((nbCompteurs % size) == 0) totalPages = nbCompteurs / size;
            else totalPages =1+ (nbCompteurs / size);

            ViewBag.totalPages = totalPages;
            ViewBag.motCle = motCle;
            return View("CompteurEaus", CompteurEaus);
        }

        public IActionResult FormCompteurEau()
        {
            CompteurEau c = new CompteurEau();
            IEnumerable<Client> clts = dbContext.Clients.ToList();
            ViewBag.clients = clts;

            IEnumerable<Douar> Douars = dbContext.Douars.ToList();
            ViewBag.douars = Douars;
            return View("FormCompteurEau",c );
        }

        [HttpPost]
        
        public IActionResult SaveCompteur(CompteurEau c)
        {
            if (ModelState.IsValid) { 
            dbContext.CompteurEaus.Add(c);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
            }
            IEnumerable<Client> clts = dbContext.Clients.ToList();
            ViewBag.clients = clts;

            IEnumerable<Douar> Douars = dbContext.Douars.ToList();
            ViewBag.douars = Douars;
            return View("FormCompteurEau", c);
        }

        [HttpPost]
        public IActionResult EditCompteur(CompteurEau c,string numero="aa")
        {
            if (ModelState.IsValid)
            {
                    var std = dbContext.CompteurEaus.First<CompteurEau>();
                    c.Numero = numero;
                    dbContext.SaveChanges();
                
                
            }
            IEnumerable<Client> clts = dbContext.Clients.ToList();
            ViewBag.clients = clts;

            IEnumerable<Douar> Douars = dbContext.Douars.ToList();
            ViewBag.douars = Douars;
            return View("FormCompteurEau", c);
        }


    }
}
