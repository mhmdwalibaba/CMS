using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using DataLayer;
using DataLayer.Context;
using Microsoft.Ajax.Utilities;

namespace NewCms.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private NCmsContext db = new NCmsContext();
        IPageRepasitory pageRepasitory;
        IPageGroupRepasitory pageGroupRepasitory;
        public PagesController()
        {
            pageRepasitory = new PageRepasitory(db);
            pageGroupRepasitory = new PageGroupRepasitory(db);
        }
        // GET: Admin/Pages
        public ActionResult Index()
        {
           
            return View(pageRepasitory.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var page = pageRepasitory.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepasitory.GetAllPageGroup(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Tags,Visit,ImageName,showInslider,CreateDate")] Page page,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;
                if(imgUp != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/" + page.ImageName));
                }
                pageRepasitory.InsertPage(page);
                pageRepasitory.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(pageGroupRepasitory.GetAllPageGroup(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var page = pageRepasitory.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepasitory.GetAllPageGroup(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Tags,Visit,ImageName,showInslider,CreateDate")] Page page,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (page.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/" + page.ImageName));
                    }
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/" + page.ImageName));
                }
                pageRepasitory.UpdatePage(page);
                pageRepasitory.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(pageGroupRepasitory.GetAllPageGroup(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var page = pageRepasitory.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pageRepasitory.GetPageById(id);
            System.IO.File.Delete(Server.MapPath("/Images/" + page.ImageName));
            pageRepasitory.DeletePage(page);
            pageRepasitory.Save();
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageRepasitory.Dispose();
                pageGroupRepasitory.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
