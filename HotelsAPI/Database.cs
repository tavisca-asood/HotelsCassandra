using HotelsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsAPI
{
    public class Database
    {
        public IRepository instance;
        public Database()
        {
            instance = new SQLDB();
        }
    }
}
