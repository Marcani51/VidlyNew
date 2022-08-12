using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using System.Data.Entity;
using VidlyNew.ViewModels;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace VidlyNew.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var mov = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (mov == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(mov)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                   
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm",viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now; /////add new  
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id); ////update
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.RentalPrice = movie.RentalPrice;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            } 
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Index()
        {
            //  var movie = GetMovies();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
            return View("ReadOnlyIndex");
            //var movie = _context.Movies.Include(c => c.Genre).ToList();
            //return View(movie);
        }

        public ActionResult Details(int id)
        {
            var mov = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (mov == null)
                return HttpNotFound();
            return View(mov);
        }
        public IEnumerable<Movie> GetMovies()
       {
       return new List<Movie>
        {
        new Movie{ Name="Shreek",Id =1},
          new Movie{ Name="Spongebop",Id =2},
            new Movie{ Name="transformers", Id=3}
          };
        }
    }
}