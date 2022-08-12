using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.Models;
using VidlyNew.Dtos;
using System.Data.Entity;
using AutoMapper;

namespace VidlyNew.Controllers.Api
{
    
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        ////GET api/movies
        public IHttpActionResult GetMovies(string query = null)///optional bisa null
        {

            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m=>m.NumberInStock > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m=>m.Name.Contains(query));

               var movieDto= moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDto);
        }

        /// GET api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movies = _context.Movies
                .Include(m=> m.Genre)
                .SingleOrDefault(d=>d.Id==id);
            if (movies == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movies));

        }

        [HttpPost]
        ///POST api/movies
        public IHttpActionResult createMovies(MovieDto movieDto)
        {
            if (!ModelState.IsValid) //// melakukan pengecekan request
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri+ "/" + movie.Id),movieDto );

        }

        [HttpPut]
        ///PUT api/movies/1
        public IHttpActionResult UpdateMovies(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(d=>d.Id == id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDto,movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovies(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(m=>m.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
