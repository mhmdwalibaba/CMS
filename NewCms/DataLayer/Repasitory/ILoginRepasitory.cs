using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  interface ILoginRepasitory
    {
        bool IsExitLogin(string username, string password);
    }
}
