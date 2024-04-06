using DataLayer;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewCms.Controllers
{
    public class HomeController : Controller
    {
        NCmsContext db = new NCmsContext();
        IPageRepasitory pageRepasitory;

        public HomeController()
        {
            pageRepasitory = new PageRepasitory(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ShowNewsInSlider()
        {
            return PartialView(pageRepasitory.GetPageInSlider());
        }
    }
}