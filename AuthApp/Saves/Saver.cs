using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AuthApp.Models;
using System.IO;
using Newtonsoft.Json;

namespace AuthApp.Saves
{
    public class Saver
    {
        public void Serialize(ApplicationUser user)
        {
            var fileName = "DATA.json";
            var users = Deserialize();
            users.Add(user);
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(fileName, json);
        }

        public List<ApplicationUser> Deserialize()
        {
            var users = new List<ApplicationUser>();
            var fileName = "DATA.json";

            if (File.Exists(fileName))
            {
                var jsonText = File.ReadAllText(fileName);
                users = JsonConvert.DeserializeObject<List<ApplicationUser>>(jsonText);
            }
            return users;
        }
    }
}
