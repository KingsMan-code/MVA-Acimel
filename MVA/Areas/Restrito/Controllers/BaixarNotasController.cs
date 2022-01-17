using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVA.Areas.Restrito.Controllers
{
    [Authorize]
    public class BaixarNotasController : Controller
    {
        // GET: Restrito/BaixarNotas
        public ActionResult Index()
        {
            return View();
        }
    }
}