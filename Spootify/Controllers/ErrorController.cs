using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Spootify.Controllers
{
    [RoutePrefix("Error")]
    public class ErrorController : Controller
    {
        public ActionResult Index(string error)
       {
            return View("Index", (object)error);
        }
    }
}