using MesTaches.Models;
using MesTaches.ViewModels;
using System;
using System.Collections.Generic;
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
