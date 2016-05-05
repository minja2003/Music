using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music.Models
{
    public class Album
    {

        public int AlbumID { get; set; }
        [Required(ErrorMessage = "Album title is required")]
        public string Title { get; set; }
        [Display(Name = "Genre")]
        public int GenreID { get; set; }
        public Genre GenreL { get; set; }
        [Required(ErrorMessage = "Album price is required")]
        [Range(0.01, 100.0, ErrorMessage = "The value must be between 1.00 and 100.0")]
        public decimal Price { get; set; }
        [Display(Name = "Artist")]
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        [Display(Name = "Likes")]
        public int Likes { get; set; }


    }
}