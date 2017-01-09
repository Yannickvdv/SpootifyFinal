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
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index(string SongID)
        {
            SongRepo repo = new SongRepo(new SongSQLContext());
            Song song = repo.GetSong(SongID);
            return View();
        }
    }
}