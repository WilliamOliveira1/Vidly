using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;
using Vidly1.ViewModels;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {
        // GET:  Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie(){Name = "Shrek!"};

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1 "},
                new Customer {Name = "Customer 2 "},
                new Customer {Name = "Customer 3 "},
                new Customer {Name = "Customer 4 "},
                new Customer {Name = "Customer 5 "},
            };

            var viewModel = new RandomMovieViewModel 
            { 
                Customers = customers,
                Movie = movie
            };

            return View(viewModel);
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {  page = 1, SortBy = "name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id );
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            return Content(String.Format("PageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4}):min(0)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
                return Content(year + "/" + month);
        }
    }
}