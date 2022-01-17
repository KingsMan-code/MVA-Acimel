using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVA.Areas.Restrito.Controllers
{
    [Authorize]
    public class LogoutController : Controller
    {
        // GET: Restrito/Logout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home", new { area = "" });
        }
    }
}