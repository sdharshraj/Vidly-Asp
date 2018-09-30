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
            return View(Movies);
        }
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
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
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);

        }
        public ActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(m => m.Genre ).SingleOrDefault(m => m.Id == id);
            return View(Movie);
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var NewMovieViewModel  = new NewMovieViewModel
            {
                Genres = genres
            };
            return View(NewMovieViewModel);
        }
    }
}