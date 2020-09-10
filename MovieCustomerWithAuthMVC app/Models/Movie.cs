using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerWithAuthMVC_app.Models
{
    public class Movie
    {
        public int Id { get; set; }
       [Required(ErrorMessage ="Name Field is Mandatory")]
        public string MovieName { get; set; }
       // [Required(ErrorMessage = "Genre Field is Required")]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }




        [Required(ErrorMessage = "Release Date Field is Required")]
        public DateTime  ReleaseDate { get; set; }

        [Range(1,20,ErrorMessage ="Field Number in Stock Must be in Between 1 to 20")]
        public int  NoInStocks { get; set; }

    }
}