using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    [DisplayName("Vidly Movie")]
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre;
        public Movie Movie { get; set; }
    }
}