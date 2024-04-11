using DataLayer;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewCms.Controllers
{
    public class SearchController : Controller
    {
        NCmsContext db = new NCmsContext();
        IPageRepasitory pageRepasitory;
        public SearchController()
        {
            pageRepasitory = new PageRepasitory(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.name = q;
            return View(pageRepasitory.Search(q));
        }
    }
}