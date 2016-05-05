namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompleteMusic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PlaylistL_PlaylistID = c.Int(),
                    })
                .PrimaryKey(t => t.PlaylistID)
                .ForeignKey("dbo.Playlists", t => t.PlaylistL_PlaylistID)
                .Index(t => t.PlaylistL_PlaylistID);
            
            AddColumn("dbo.Albums", "Likes", c => c.Int(nullable: false));
            AddColumn("dbo.Artists", "ArtistL_ArtistID", c => c.Int());
            AddColumn("dbo.Genres", "GenreL_GenreID", c => c.Int());
            AlterColumn("dbo.Artists", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Artists", "ArtistL_ArtistID");
            CreateIndex("dbo.Genres", "GenreL_GenreID");
            AddForeignKey("dbo.Artists", "ArtistL_ArtistID", "dbo.Artists", "ArtistID");
            AddForeignKey("dbo.Genres", "GenreL_GenreID", "dbo.Genres", "GenreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playlists", "PlaylistL_PlaylistID", "dbo.Playlists");
            DropForeignKey("dbo.Genres", "GenreL_GenreID", "dbo.Genres");
            DropForeignKey("dbo.Artists", "ArtistL_ArtistID", "dbo.Artists");
            DropIndex("dbo.Playlists", new[] { "PlaylistL_PlaylistID" });
            DropIndex("dbo.Genres", new[] { "GenreL_GenreID" });
            DropIndex("dbo.Artists", new[] { "ArtistL_ArtistID" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Artists", "Name", c => c.String());
            DropColumn("dbo.Genres", "GenreL_GenreID");
            DropColumn("dbo.Artists", "ArtistL_ArtistID");
            DropColumn("dbo.Albums", "Likes");
            DropTable("dbo.Playlists");
        }
    }
}
