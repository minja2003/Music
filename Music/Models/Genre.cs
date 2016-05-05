using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public Genre GenreL { get; set; }
        [Required(ErrorMessage = "Genre is Required")]
        public string Name { get; set; }
        public List<Album> Albums
        {
            get;

            private set;
        }


    }
}