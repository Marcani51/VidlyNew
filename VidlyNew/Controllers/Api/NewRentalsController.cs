using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.Dtos;
using VidlyNew.Models;
using System.Data.Entity;
using AutoMapper;

namespace VidlyNew.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
       
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomersId);

            var movies = _context.Movies.Where(
                m => newRental.MoviesId.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberInStock == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberInStock--;

                var rental = new Rental
                {

                    Customer = customer,
                    Movie = movie,
                    RentalPrice = movie.RentalPrice,
                    DateRented = DateTime.Now
                    
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("api/createInv")]
        public IHttpActionResult CreateInvoice(int id) {
            var inV = _context.Rentals.Single(r => r.Id == id);
            if (inV == null)
                return NotFound();
            
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetNewRentals()
        {
            var rentalDtos = _context.Rentals
                .Include(c => c.Customer)
                .Include(m=>m.Movie)
                .Include(m=>m.Movie.Genre)
                .Include(c=>c.Customer.MembershipType)
                .ToList();
            return Ok(rentalDtos);
        }


        [HttpGet]
        public IHttpActionResult GetNewRentals(int id)
        {
            var rentalDtos = _context.Rentals
                .Where(c => c.Id == id);
            if (rentalDtos == null)
                return NotFound();

            return Ok(rentalDtos);
        }

        [HttpGet]
        [Route("api/newrentals/{id}/allrent")]
        public IHttpActionResult GetNewRentals1(int id)
        {
            var rentalDtos = _context.Rentals
                .Include(c => c.Customer)
                .Include(m => m.Movie)
                .Include(c => c.Customer.MembershipType)
                .Where(c => c.Customer.Id == id);
            if (rentalDtos == null)
                return NotFound();

            return Ok(rentalDtos);
        }

        [HttpPut]
        [Route("api/newrentals/{id}/datere")]
        public IHttpActionResult EditRentals(int id, NewRentalDto rentalDto) {
            var rentalInDb = _context.Rentals
                .SingleOrDefault(c => c.Id == id);
            if (rentalInDb == null)
                return NotFound();
            Mapper.Map(rentalDto, rentalInDb);
            _context.SaveChanges();
           
            return Ok();
        }
    }
}
