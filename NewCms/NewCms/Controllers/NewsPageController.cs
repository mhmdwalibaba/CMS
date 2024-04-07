using DataLayer;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        IPageCommentRepasitory commentRepasitory;
        public NewsPageController()
        {
            pageGroupRepasitory = new PageGroupRepasitory(db);
            pageRepasitory = new PageRepasitory(db);
            commentRepasitory = new PageCommentRepasitory(db);
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
            return View(pageRepasitory.GetAllPage());
        }

        [Route("Group/{title}/{id}")]
        public ActionResult ShowNewsPageByGroupId(string title,int id)
        {
            ViewBag.name=title;
            return View(pageRepasitory.GetPageByGroupId(id));
        }
        [Route("News/{id}")]
        public ActionResult ShowPageNews(int id)
        {
            var page = pageRepasitory.GetPageById(id);
            if (page == null)
            {
               return HttpNotFound();
            }
            page.Visit += 1;
            pageRepasitory.UpdatePage(page);
            pageRepasitory.Save();
            return View(page);
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            PageComment addComment = new PageComment()
            {
                PageID = id,
                Name=name,
                Email=email,
                CommentText=comment,
                CreatedDate=DateTime.Now

             };
            commentRepasitory.AddComment(addComment);
            
            return PartialView("ShowComment", commentRepasitory.GetCommentByPageId(id)); 
        }
        public ActionResult ShowComment(int id)
        {
            return PartialView(commentRepasitory.GetCommentByPageId(id));
        }
    }
}