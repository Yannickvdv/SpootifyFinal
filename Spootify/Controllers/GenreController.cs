using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spootify.Context;
using Spootify.Models;
using Spootify.Repos;

namespace Spootify.Controllers
{
    [RoutePrefix("Genre")]
    public class GenreController : Controller
    {

        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                Genre genre = new Genre();
                GenreRepo repo = new GenreRepo(new GenreSQLContext());
                List<Genre>genres = repo.GetGenres();
                return View("Genres", genres);
            }
            catch (Exception ex)
            {
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                return RedirectToAction("Index", "Error", new
                {
                    error = ex.Message
                });
            }

        }


        [Route("{genreID?}")]
        public ActionResult Songs(int genreID)
        {
            try
            {
                List<Song> songs = new List<Song>();
                Genre genre = new Genre();
                if (genreID != 0)
                {
                    songs = genre.GetSongsGenre(genreID);
                }
                return View("Songs", songs);
            }
            catch (Exception ex)
            {
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                return RedirectToAction("Index", "Error", new
                {
                    error = ex.Message
                });
            }
        }
    }
}