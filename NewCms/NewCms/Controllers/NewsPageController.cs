using DataLayer;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace NewCms.Controllers
{
    public class NewsPageController : Controller
    {
        NCmsContext db = new NCmsContext();
        IPageGroupRepasitory pageGroupRepasitory;
        IPageRepasitory pageRepasitory;
        public NewsPageController()
        {
            pageGroupRepasitory = new PageGroupRepasitory(db);
            pageRepasitory = new PageRepasitory(db);
        }
        // GET: NewsPage
        public ActionResult ShowNewsGroup()
        {
            return PartialView(pageGroupRepasitory.GetPageGroupTitleAndPageCount());
        }
        public ActionResult ShowGroupTitleInMeno()
        {
            return PartialView(pageGroupRepasitory.GetAllPageGroup());
        }
        public ActionResult ShowNewsMaxVisit()
        {
            return PartialView(pageRepasitory.GetPageMaxVisted());
        }
        public ActionResult ShowLatesNews()
        {
            return PartialView(pageRepasitory.GetLatesPage());
        }
        public ActionResult ArchiveNews()
        {
            return PartialView(pageRepasitory.GetAllPage());
        }

        [Route("Group/{title}/{id}")]
        public ActionResult ShowNewsPageByGroupId(string title,int id)
        {
            ViewBag.name=title;
            return View(pageRepasitory.GetPageByGroupId(id));
        }
    }
}