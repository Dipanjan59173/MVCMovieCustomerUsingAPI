using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCustomerWithAuthMVC_app.Models;

namespace MovieCustomerWithAuthMVC_app.Models.ViewModel
{
    public class NewMovieViewModel
    {
        //public NewMovieViewModel(Movie movie)
        //{
        //    Movie = movie;
        //}

        //public IEnumerable<Genre> Genres { get; set; }
        //public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        // public Movie Movie { get; set; }

        public int? Id { get; set; }
        public string MovieName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? GenreId { get; set; }

        public int NoInStocks { get; set; }

        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            MovieName = movie.MovieName;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NoInStocks = movie.NoInStocks;
        }

    }
}