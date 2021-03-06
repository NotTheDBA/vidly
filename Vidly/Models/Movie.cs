﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Release Date")]
        [NotFutureReleaseDate]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [NotFutureReleaseDate]
        public DateTime DateAdded { get; set; }

        [Display(Name = "# In Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}