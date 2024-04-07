using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepasitory
    {
        bool AddComment(PageComment comment);
        IEnumerable<PageComment> GetCommentByPageId(int pageId);
    }
}
