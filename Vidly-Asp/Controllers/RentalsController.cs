using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Asp.Dtos;
using Vidly_Asp.Models;
using System.Data.Entity;

namespace Vidly_Asp.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }
        public ActionResult ShowRentals()
        {
            var rentals = _context.Rentals.Include(r => r.Customer).Include(r => r.Movie).Where(r => r.DateReturned == null).ToList();
            
            //foreach(var rental in rentals)
            //{
            //    allRentals.Add(new ShowRentalDto() {
            //        CustomerName = _context.Customers.Single(c => c.Id == rental.Customer.Id).Name,

            //});
            //}
            return View(rentals);
        }

        public ActionResult SubmitRental(int id)
        {
            var rental = _context.Rentals.Include(r => r.Movie).SingleOrDefault(r => r.Id == id);
            if (rental == null)
                return HttpNotFound("The given Rental id doesnot exist.");

            rental.DateReturned = DateTime.Now;
            var returnedMovie = _context.Movies.Single(m => m.Id == rental.Movie.Id);
            returnedMovie.NumberAvailable++;

            _context.SaveChanges();

            var rentals = _context.Rentals.Include(r => r.Customer).Include(r => r.Movie).Where(r => r.DateReturned == null).ToList();
            return View("ShowRentals", rentals);
        }
    }
}