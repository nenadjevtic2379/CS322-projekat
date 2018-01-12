using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS322_PZ01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

      //  [Authorize(Roles = "User")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

      //  [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.mapa = "https://www.google.rs/maps/place/Kneza+Milo%C5%A1a/@44.8053766,20.4584741,17z/data=!3m1!4b1!4m5!3m4!1s0x475a7aa8104af71b:0xdb0b9b96b75f5650!8m2!3d44.8053766!4d20.4606628?hl=en";
            return View();
        }
    }
}