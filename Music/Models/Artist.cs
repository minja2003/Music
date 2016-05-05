using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }

        public Artist ArtistL { get; set; }
        [Required(ErrorMessage = "Artist is Required")]
        public string Name { get; set; }

        public List<Album> Albums
        {
            get;

            private set;
        }
    }
}