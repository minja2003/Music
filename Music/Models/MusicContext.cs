﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Music.Models
{
    public class MusicContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MusicContext() : base("name=MusicContext")
        {
        }

        public System.Data.Entity.DbSet<Music.Models.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<Music.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<Music.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<Music.Models.Playlist> Playlists { get; set; }
    }
}
