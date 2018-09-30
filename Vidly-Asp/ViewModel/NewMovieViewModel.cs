using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Asp.Models;

namespace Vidly_Asp.ViewModel
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}