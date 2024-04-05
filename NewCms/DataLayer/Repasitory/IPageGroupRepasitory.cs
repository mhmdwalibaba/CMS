using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepasitory:IDisposable
    {
        IEnumerable<PageGroup> GetAllPageGroup();
        PageGroup GetPageGroupById(int pageGroupId);
        bool AddPageGroup(PageGroup pageGroup);
        bool UpdatePageGroup(PageGroup pageGroup);
        bool DeletePageGroup(int pageGroupId); 
        bool DeletePageGroup(PageGroup pageGroup);
        IEnumerable<ShowGroupTitleAndPageCount> GetPageGroupTitleAndPageCount();
        void Save();

    }
}
