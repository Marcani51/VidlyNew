using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModels;

namespace VidlyNew.Controllers
{
    public class RentalController : Controller
    {
        private ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Rental
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
            return View("ReadOnlyIndex");
            
        }

        
    }
}