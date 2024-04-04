using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepasitory:IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageById(int pageId);   
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(int pageId);
        bool DeletePage(Page page);
        void Save();

    }
}
