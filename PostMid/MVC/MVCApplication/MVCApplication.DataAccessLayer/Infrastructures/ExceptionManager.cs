using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplication.DataAccessLayer.Infrastructures
{
    public class ExceptionManager
    {
        private static ILogger _logger;

        static ExceptionManager()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public static Exception Manage(Exception e)
        {
            _logger.Error(e);
            return e;
        }
    }
}
