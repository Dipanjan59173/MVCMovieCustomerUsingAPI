using MovieCustomerWithAuthMVC_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieCustomerWithAuthMVC_app.Controllers.Api
{
    public class GenreController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public GenreController()
        {
            _context = new ApplicationDbContext();
        }
       
        //public IEnumerable<Genre> GetGenres()
        //{
        //    var genres = _context.Genres.ToList();
        //    return genres;
        //}

        public IHttpActionResult GetAllGenres()
        {
            IEnumerable<Genre> genres;
            genres = _context.Genres.ToList();
            if (genres == null)
                return NotFound();
            return Ok(genres);
        }
    }
}
