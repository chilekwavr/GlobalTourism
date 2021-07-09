using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTour
{
    public class ConnectionStringFactory
    {
        private static string _conStr;

        public ConnectionStringFactory(string conStr)
        {
            _conStr = conStr;
        }
        public static string GetConnectionString()
        {
            return _conStr;
        }
    }
}
