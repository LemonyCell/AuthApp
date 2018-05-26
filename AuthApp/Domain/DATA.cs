using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AuthApp.Models;
using AuthApp.Saves;

namespace AuthApp.Domain
{
    class DATA
    {
        public static List<ApplicationUser> ApplicationUsers;// = new List<ApplicationUser>();
        public static void AddUser(ApplicationUser user)
        {
            var saver = new Saver();
            saver.Serialize(user);
            //DATA.ApplicationUsers.Add(user);
            ApplicationUsers = saver.Deserialize();
        }
    }
}
