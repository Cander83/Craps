using Craps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Craps.Controllers
{
    public class CrapsController : Controller
    {
        // GET: Craps
        public ActionResult Index(HomeModel inputModel)
        {
            return RedirectToAction("Index", inputModel);
        }
    }
}