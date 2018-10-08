using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Asp.Models;
using Vidly_Asp.ViewModel;

namespace Vidly_Asp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var Movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List", Movies);
            
            return View("ReadOnlyList", Movies);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
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

                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var newMovie = _context.Movies.Single(m => m.Id == movie.Id);
                newMovie.Name = movie.Name;
                newMovie.GenreId = movie.GenreId;
                newMovie.NumberInStock = movie.NumberInStock;
                newMovie.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(m => m.Genre ).SingleOrDefault(m => m.Id == id);
            if (Movie == null)
                return HttpNotFound();

            return View( Movie);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var NewMovieViewModel  = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm",NewMovieViewModel);
        }
    }
}