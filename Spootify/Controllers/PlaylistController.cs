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
    [RoutePrefix("Playlist")]
    public class PlaylistController : Controller
    {
        // GET: Playlist
        [Route("")]
        public ActionResult Index()
        {
            PlaylistRepo repo = new PlaylistRepo(new PlaylistSQLContext());
            return View(repo.GetPlaylists((Account)Session["User"]));
        }

        [Route("{PlaylistID}")]
        public ActionResult Playlist(int playlistID)
        {
            SongRepo repo = new SongRepo(new SongSQLContext());
            return View(repo.GetSongsPlaylist(new Playlist(playlistID, 0, null)));
        }

        [Route("Aanbevelingen")]
        public ActionResult Aanbevelingen()
        {
            SongRepo repo = new SongRepo(new SongSQLContext());
            return View(repo.GetSongsRecommended((Account)Session["User"]));
        }

        [Route("New")]
        public ActionResult New()
        {

            return View();
        }
    }
}