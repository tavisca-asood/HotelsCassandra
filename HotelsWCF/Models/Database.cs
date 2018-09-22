using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsWCF
{
    public class Database
    {
        public IRepository instance;
        public Database()
        {
            instance = new CassandraDB();
        }
    }
}