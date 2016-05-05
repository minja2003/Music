namespace Music.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }

        public Playlist PlaylistL { get; set; }
        public string Name { get; set; }
    }
}