using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spootify.Context;
using Spootify.Context.Interfaces;
using Spootify.Models;
using Spootify.Repos;

namespace Spootify.Controllers
{
    [RoutePrefix("Song")]
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index(string SongID)
        {
            SongRepo repo = new SongRepo(new SongSQLContext());
            Song song = repo.GetSong(SongID);
            return View(song);
        }

        [Route("New")]
        public ActionResult New()
        {
            GenreRepo repo = new GenreRepo(new GenreSQLContext());
            List<Genre> genre = repo.GetGenres();
            return View(genre);
        }
        
        [HttpPost]
        public ActionResult NewSong()
        {
            SongRepo repo = new SongRepo(new SongSQLContext());
            repo.NewSong(new Song(Convert.ToString(Request.Form["InputSong"]), Request.Form["InputName"],
                Convert.ToInt32(Request.Form["InputDuration"]), Request.Form["InputSong"], DateTime.Now));
            return RedirectToAction("Homescreen", "Home");

        }
    }
}