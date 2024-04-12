using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepasitory : ILoginRepasitory
    {
        NCmsContext db;
        public LoginRepasitory(NCmsContext db)
        {
            this.db = db;
        }
        public bool IsExitLogin(string username, string password)
        {
            return db.logins.Any(l => l.Password == password && l.UserName == username);
        }
    }
}
