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
            try
            {
                SongRepo repo = new SongRepo(new SongSQLContext());
                Song song = repo.GetSong(SongID);
                return View(song);
            }
            catch (Exception ex)
            {
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                return RedirectToAction("Index", "Error", new {error = ex.Message});
            }

        }

        [Route("New")]
        public ActionResult New()
        {
            try
            {
                GenreRepo repo = new GenreRepo(new GenreSQLContext());
                List<Genre> genre = repo.GetGenres();
                return View(genre);
            }
            catch (Exception ex)
            {
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            
        }
        
        [HttpPost]
        public ActionResult NewSong()
        {
            try
            {
                SongRepo repo = new SongRepo(new SongSQLContext());
                Song song = new Song(Request.Form["InputSong"], Request.Form["InputName"],
                    Convert.ToInt32(Request.Form["InputDuration"]), Request.Form["InputFoto"], DateTime.Now);

                repo.NewSong(song);
                //GenreRepo genreRepo = new GenreRepo(new GenreSQLContext());
                return RedirectToAction("Index", "Genre");
            }
            catch (Exception ex)
            {
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }

        }
    }
}