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
            try
            {
                PlaylistRepo repo = new PlaylistRepo(new PlaylistSQLContext());
                return View(repo.GetPlaylists((Account) Session["User"]));
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

        [Route("{PlaylistID}")]
        public ActionResult Playlist(int playlistID)
        {
            try
            {
                SongRepo repo = new SongRepo(new SongSQLContext());
                return View(repo.GetSongsPlaylist(new Playlist(playlistID, 0, null)));
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

        [Route("Aanbevelingen")]
        public ActionResult Aanbevelingen()
        {
            try
            {
                SongRepo repo = new SongRepo(new SongSQLContext());
                return View(repo.GetSongsRecommended((Account)Session["User"]));
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

        [Route("New")]
        public ActionResult New()
        {
            return View();
        }
    }
}