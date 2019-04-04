using Craps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Craps.Controllers
{
    public class UserController : Controller
    {
        public HomeModel HomeModel { get; set; }

        public ActionResult CreateUser(HomeModel inputModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetUser(HomeModel inputModel)
        {
            try
            {
                // TODO: Add insert logic here

                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DeleteUser(int id)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
