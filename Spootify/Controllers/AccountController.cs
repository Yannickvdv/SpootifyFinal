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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View((Account) Session["User"]);
        }

        public ActionResult FavorieteGenres()
        {
            try
            {
                Account account = (Account) Session["User"];
                GenreRepo repo = new GenreRepo(new GenreSQLContext());
                List<Genre> FavGenres = new List<Genre>();
                FavGenres.Add(repo.GetGenre(account.FavGenre1));
                FavGenres.Add(repo.GetGenre(account.FavGenre2));
                FavGenres.Add(repo.GetGenre(account.FavGenre3));


                ViewBag.FavGenres = FavGenres;
                ViewBag.AllGenres = repo.GetGenres();
                return View();
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