using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
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
            base.Dispose(disposing);
        }

        // GET: Movies
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            /////This is older, but fragile
            //ViewData["Movie"] = movie;
            ////This was the "fix", but still has similar issues.
            //ViewBag.Movie = movie;
            //return View();
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id is null)
                return RedirectToAction("Index");

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return RedirectToAction("Index");

            return View(movie);
              
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };
            //return View(viewModel);
            //without this, it will look for a form matching the method name.
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int? id)
        {

            if (id is null)
                return RedirectToAction("Index");

            var movie = _context.Movies.Include(m => m.Genre).Single(c => c.Id == id);
            if (movie == null)
                return RedirectToAction("New", "Movies");

            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList()
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
                    Genre = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                //TryUpdateModel(customerInDb);  // officialy recommended; could have security holes
                //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" }); //officialy recommended whitelisting - depends on "magic string" and could break if the model changes.
                //This method allows the same granular control as whitelisting, but will be properly refactored if proprties are renamed.
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                //movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                //Tools such as Auto-Mapper can simplify the code for updating all properties.
                //dto - data transfer objects - can also be used with Auto-Mapper to limit fields to those which can be updated.

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        //// Movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;


        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}


        //MVC5 attribute-based routing
        [Route("movies/released/{year:range(2015, 2017)}/{month:regex(\\d{2}):range(1, 12)}")]
        // Movies/ByReleaseDate
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}