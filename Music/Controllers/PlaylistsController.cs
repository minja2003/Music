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
    public class PlaylistsController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Albums
        public ActionResult Index()
        {
            var playlists = db.Playlists.Include(p => p.PlaylistL);
            return View(playlists.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Playlist playlist = db.Playlists.Find(id);
            db.Playlists.Remove(playlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Playlist playlist)
        {
            if (db.Playlists.Any(o => o.Name == playlist.Name))
            {
                ViewBag.Message = "Name already in database";
                return View();
            }
            else {
                if (ModelState.IsValid)
                {
                    db.Playlists.Add(playlist);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(playlist);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", album.ArtistID);
            return View(album);
        }
    }
}
