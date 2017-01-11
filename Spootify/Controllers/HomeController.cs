using System;
using System.Collections;
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
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Homescreen")]
        public ActionResult Homescreen()
        {
            return View();
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Index");
        }

        [HttpPost]
        public ActionResult NewAccount()
        {
            Account account = new Account(Request.Form["newInputName"], Request.Form["newInputPassword"], Request.Form["newInputEmail"], DateTime.Now, Request.Form["newInputFoto"], "NULL", "NULL", "NULL");
            AccountRepo repo = new AccountRepo(new AccountSQLContext());
            repo.NewAccount(account);

            this.Session["User"] = account;
            return RedirectToAction("Index", "Genre");
        }

        [HttpPost]
        public ActionResult LoginAccount()
        {

            AccountRepo repo = new AccountRepo(new AccountSQLContext());
            Account account = repo.LoginAccount(Request.Form["loginInputMail"], Request.Form["loginInputPassword"]);
            if (account == null)
            {
                ViewBag.Login = false;
                return RedirectToAction("Index");
            }
            else
            {
                this.Session["User"] = account;
                return RedirectToAction("Index", "Genre");
            }
            
        }
    }
}