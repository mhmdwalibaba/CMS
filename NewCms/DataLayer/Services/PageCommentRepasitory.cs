using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepasitory : IPageCommentRepasitory
    {
        NCmsContext db;
        public PageCommentRepasitory(NCmsContext db)
        {
            this.db = db;
        }
        public bool AddComment(PageComment comment)
        {
            try
            {
                db.pageComments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<PageComment> GetCommentByPageId(int pageId)
        {
            return db.pageComments.Where(c=>c.PageID==pageId);
        }
    }
}
