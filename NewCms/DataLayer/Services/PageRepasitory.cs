using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepasitory : IPageRepasitory
    {

        NCmsContext db;
        public PageRepasitory(NCmsContext db)
        {
            this.db = db;
        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.pages;
        }

        public Page GetPageById(int pageId)
        {
            return db.pages.Find(pageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.pages.Add(page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdatePage(Page page)
        {

            try
            {
                db.Entry(page).State=EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(int pageId)
        {

            try
            {
                var p = GetPageById(pageId);
                DeletePage(p);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(Page page)
        {

            try
            {
                db.Entry(page).State =EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
