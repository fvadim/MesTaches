using MesTaches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MesTaches.ViewModels;


namespace MesTaches.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            
            var allTaches = _context.Taches
                .Include(t => t.Projet)
                .Include(t => t.User);

            TachesProjetsViewModel _vm = new TachesProjetsViewModel();
            _vm.Projets = _context.Projets.ToList();
            _vm.Taches = allTaches;
            
            return View(_vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult SetDone(string _id)
        {
            int id = Int32.Parse(_id);
            var tache = from t in _context.Taches
                        where t.Id == id
                        select t;
            tache.First().EndDT = DateTime.Today;
            _context.SaveChanges();
            //return "<span class=\"glyphicon glyphicon-ok\" aria-hidden=\"true\"></span>";
            return RedirectToAction("Index");
        }
    }
}