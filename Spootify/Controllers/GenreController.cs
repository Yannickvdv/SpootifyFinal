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
            GenreRepo repo = new GenreRepo(new GenreSQLContext());
            List<Genre> genre = repo.GetGenres();
            return View("Genres", genre);
        }
        

        [Route("{genreID?}")]
        public ActionResult Songs(int genreID)
        {
            SongRepo SongRepo = new SongRepo(new SongSQLContext());
            List<Song> songs = new List<Song>();
            if (genreID != 0)
            {
                songs = SongRepo.GetSongsGenre(genreID);
            }
            return View("Songs", songs);
        }
    }
}