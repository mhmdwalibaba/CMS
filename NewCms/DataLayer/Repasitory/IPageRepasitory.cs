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
        IEnumerable<Page> GetPageMaxVisted(int take = 4);
        IEnumerable<Page> GetPageInSlider();
        IEnumerable<Page> GetLatesPage(int take=4);
        IEnumerable<Page> GetPageByGroupId(int GroupId);
        IEnumerable<Page> Search(string q);
        void Save();

    }
}
