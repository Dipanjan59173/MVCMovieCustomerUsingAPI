using MovieCustomerWithAuthMVC_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MovieCustomerWithAuthMVC_app.Models.ViewModel;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MovieCustomerWithAuthMVC_app.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/movies
        public IHttpActionResult GetMovie()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            //return _context.Customers.ToList();
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        public IHttpActionResult GetMovie(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Movies Id");
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(movie);

        }
        //POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest("model data is invalid");
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok(movie);
        }
        //public Movie GetMovie(Movie movie)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    _context.Movies.Add(movie);
        //    _context.SaveChanges();
        //    return movie;
        //}





        //PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid data ");

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();
            movieInDb.MovieName = movie.MovieName;
            movieInDb.GenreId = movie.GenreId;
            movie.ReleaseDate = movie.ReleaseDate;
            movie.NoInStocks = movie.NoInStocks;
            _context.SaveChanges();
            return Ok();
        }
        //[HttpPut]
        //public void UpdateMovie(int id, Movie movie)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
        //    if (movieInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    movieInDb.Name = movie.Name;



        //    //movieInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
        //    _context.SaveChanges();
        //}
        public IHttpActionResult DeleteMovie(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Customer Id");
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
            ;
        }
        //public void DeleteMovie(int id)
        //{
        //    var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
        //    if (movieInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    _context.Movies.Remove(movieInDb);
        //    _context.SaveChanges();
        //



    }


}

