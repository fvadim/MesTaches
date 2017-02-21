using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MesTaches.Models;
using MesTaches.ViewModels;

namespace MesTaches.Controllers
{
    public class ProjetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projets
        [Authorize]
        public ActionResult Index()
        {
            var allTaches = db.Taches
                .Include(t => t.Projet)
                .Include(t => t.User);

            TachesProjetsViewModel _vm = new TachesProjetsViewModel();
            _vm.Projets = db.Projets.ToList();
            _vm.Taches = allTaches;
            return View(_vm);
        }

        // GET: Projets/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TachesProjetsViewModel _vm = new TachesProjetsViewModel();
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            
            _vm.Projets = new List<Projet>();
            _vm.Projets.Add(projet);

            var tachesDeProjet = db.Taches
                .Include(t => t.User)
                .Where(t => t.ProjetId == projet.Id);

            _vm.Taches = tachesDeProjet;

            return View(_vm);
        }

        // GET: Projets/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Projets.Add(projet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projet);
        }

        // GET: Projets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projet);
        }

        // GET: Projets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projet projet = db.Projets.Find(id);
             
            

            var taches = from t in db.Taches
                         where t.ProjetId.Equals(projet.Id)
                         select t;

            db.Taches.RemoveRange(taches);
            db.Projets.Remove(projet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
