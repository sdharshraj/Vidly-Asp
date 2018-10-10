using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_Asp.Dtos;
using Vidly_Asp.Models;

namespace Vidly_Asp.Controllers.Api
{

    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            //not needed when its for internal use. We can use optimistic approach and delete some of the checks
            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("No movies ids have been given.");
            
            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == newRentalDto.CustomerId);

            //Check if customer is valid or not
            if (customer == null)
                return BadRequest("Invalid Customer.");

            var movies = _context.Movies.Where(
                m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One or more movies ids are invalid.");

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie not available.");
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }

    }
}
