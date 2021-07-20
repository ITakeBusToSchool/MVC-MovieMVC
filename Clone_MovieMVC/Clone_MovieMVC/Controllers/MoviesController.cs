using Clone_MovieMVC_Entities;
using Clone_MovieMVC_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clone_MovieMVC.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
            /*
             * when you run your application, the MoviesContrller and has the IMovieService as a 
             * parameter datatype, passing those classes which initiatice those interface(IMovieService)
             */
        }

        // GET: Movies

        [Route("Index/{Id}")]
        public ActionResult Index(int Id)
        {
            var movies = _movieService.GetMoviesByGenreId(Id);
            return View("Index", movies);
        }
        //Many method can use same View


        [Route("topmovies")]
        public ActionResult TopMovies()
        {
            var movies = _movieService.GetTopGrossingMovies();
            return View("Index", movies);
        }

        public ActionResult TopRevenueMovie()
        {
            var movies = _movieService.GetTopGrossingMovies();
            return View("Index", movies);
        }

        public ActionResult TopRatedMovies()
        {
            var movies = _movieService.GetTopRatedMovies();
            return View("TopRatedMovies", movies);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                //save to database only when Model is valid(a;; cibstraubs passed)
                //redirect to index action method
                return RedirectToAction("TopRevenueMovie");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    }
}