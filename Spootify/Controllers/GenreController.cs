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
        [Route("")]
        // GET: Genre
        public ActionResult Index()
        {
            return View();
        }

        [Route("{genreID:int}")]
        public ActionResult Songs(string genreID)
        {
            SongRepo SongRepo = new SongRepo(new SongSQLContext());
            List<Song> songs = SongRepo.GetSongsGenre(genreID);
            return View(songs);
        }
    }
}