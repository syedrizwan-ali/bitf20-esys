using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Common.Helpers
{
    public class ExceptionHandler
    {
        public static Exception Handle (Exception e)
        {
            Console.WriteLine(e.Message);
            return e;
        }
    }
}
