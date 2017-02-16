using MesTaches.Models;
using MesTaches.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MesTaches.Controllers
{
    public class TachesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TachesController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: Taches
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult MesTaches()
        {
            var userId = User.Identity.GetUserId();
            var taches = _context.Taches.Where(t => t.UserId == userId)
                .Include(t => t.Projet)                
                .ToList();
            TachesProjetsViewModel _vm = new TachesProjetsViewModel();
            var projets = from t in taches
                          select t.Projet;
            _vm.Projets = projets.ToList();
            _vm.Taches = taches;

           
            return View(_vm);
        }


        // GET: Taches/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Taches/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new TacheFormViewModel
            {
                Projets = _context.Projets.ToList()
            };
            return View(viewModel);
        }

        // POST: Taches/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TacheFormViewModel _vm)
        {
            if (!ModelState.IsValid)
            {
                _vm.Projets = _context.Projets.ToList();
                return View("Create", _vm);
            }
            var tache = new Tache
            {
                Name = _vm.Name,
                UserId = User.Identity.GetUserId(),
                CreateDT = _vm.getCreateDT(),
                EndDT = _vm.getEndDT(),
                ProjetId = _vm.Projet
            };

            _context.Taches.Add(tache);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: Taches/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Taches/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Taches/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Taches/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
