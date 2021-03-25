using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDbContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDbContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EnterMovie(MovieList mr)
        {
            if (ModelState.IsValid)
            {
                
                context.Movies.Add(mr);

                
                context.SaveChanges();

                return View("ViewMovies", context.Movies.Where(m => m.Title != "Independence Day"));
            }

            return View();
        }

        
        public IActionResult ViewMovies()
        {

            return View(context.Movies.Where(m => m.Title != "Independence Day"));
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditMovie(int movieid)
        {

            var MovieToEdit = context.Movies.Where(mv => mv.MovieId == movieid).FirstOrDefault();


            return View(MovieToEdit);
        }


        [HttpPost]
        public IActionResult SaveChanges(MovieList mr, int movieid)
        {

            var MovieToOverwrite = context.Movies.Where(mr => mr.MovieId == movieid).FirstOrDefault();

            if (ModelState.IsValid)
            {

                MovieToOverwrite.Title = mr.Title;
                MovieToOverwrite.Category = mr.Category;
                MovieToOverwrite.Year = mr.Year;
                MovieToOverwrite.Director = mr.Director;
                MovieToOverwrite.Rating = mr.Rating;
                MovieToOverwrite.Edited = mr.Edited;
                MovieToOverwrite.LentTo = mr.LentTo;
                MovieToOverwrite.Notes = mr.Notes;


                context.SaveChanges();

                return View("ViewMovies", context.Movies.Where(m => m.Title != "Independence Day"));
            }

            return View("EditMovie", mr);
        }

        [HttpPost]
        public IActionResult DeleteMovie(int movieid)
        {

            var MovieToDelete = context.Movies.Where(mv => mv.MovieId == movieid).FirstOrDefault();


            context.Remove(MovieToDelete);
            context.SaveChanges();


            return View("ViewMovies", context.Movies.Where(m => m.Title != "Independence Day"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

