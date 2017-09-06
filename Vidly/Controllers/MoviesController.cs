using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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

        public ActionResult Add(string name)
        {

            if (String.IsNullOrWhiteSpace(name))
                name = "[enter movie]";

            return Content("name=" + name);

        }


        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            else
            if (id < 1)
                return RedirectToAction("Add", "Movies", new { name = "[not found, enter movie]" });
            else
                return Content("id=" + id);
        }


        public ActionResult View(int? id)
        {
            if (!id.HasValue)
                return new EmptyResult();
            else
                return Content("id=" + id);
        }

        // Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;


            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }


        //MVC5 attribute-based routing
        [Route("movies/released/{year:range(2015, 2017)}/{month:regex(\\d{2}):range(1, 12)}")]
        // Movies/ByReleaseDate
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}