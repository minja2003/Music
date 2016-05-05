using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class GenresController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Albums
        public ActionResult Index()
        {
            var genres = db.Genres.Include(g => g.GenreL);
            return View(genres.ToList());
        }

        public ActionResult DisplayGenre(int? id)
        {
            var album = db.Albums.Where(a => a.GenreID == id);
            return View(album.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Include(a => a.Artist).Include(a => a.GenreL).Where(a => a.AlbumID == id).Single();
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Genre genre)
        {
            if (db.Genres.Any(o => o.Name == genre.Name))
            {
                ViewBag.Message = "Name already in database";
                return View();
            }
            else {
                if (ModelState.IsValid)
                {
                    db.Genres.Add(genre);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(genre);
        }
    }
}
