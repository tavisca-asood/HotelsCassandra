using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsAPI.Models
{
    public class Logger
    {
        private static Logger _instance = null;
        private Logger() { }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
        public void Log(Log log)
        {
            SQLEntity entity = new SQLEntity();
            entity.Logs.Add(log);
            entity.SaveChanges();
        }
    }
}
