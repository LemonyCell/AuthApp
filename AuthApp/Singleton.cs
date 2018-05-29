using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AuthApp.Models;

namespace AuthApp
{
    class Singleton
    {
        public ApplicationUser User;

        private static Singleton instance;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}
