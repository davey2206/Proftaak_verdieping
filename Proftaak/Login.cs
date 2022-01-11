using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    internal class Login
    {
        private Database db = new Database();

        public int checkLogin(string username, string password)
        {
            int id = db.login(username, password);
            if (id != 0)
            {
                return id;
            }
            return 0;
        }
    }
}