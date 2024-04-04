using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepasitory : IPageGroupRepasitory
    {
        NCmsContext db;
        public PageGroupRepasitory(NCmsContext db)
        {
            this.db = db;
        }
        public IEnumerable<PageGroup> GetAllPageGroup()
        {
            return db.pageGroups;
        }

        public PageGroup GetPageGroupById(int pageGroupId)
        {
            return db.pageGroups.Find(pageGroupId);
        }

        public bool AddPageGroup(PageGroup pageGroup)
        {
            try
            {
                db.pageGroups.Add(pageGroup);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePageGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State=EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePageGroup(int pageGroupId)
        {
            try
            {
                var p = GetPageGroupById(pageGroupId);
                DeletePageGroup(p);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePageGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch
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
