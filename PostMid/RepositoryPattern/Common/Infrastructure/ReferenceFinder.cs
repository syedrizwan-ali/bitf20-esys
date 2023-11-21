using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Common.Infrastructure
{
    public class ReferenceFinder
    {
        private static IKernel kernel = new StandardKernel();

        static ReferenceFinder()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
        }

        public static T Find<T>()
        {
            return kernel.Get<T>();
        }
    }
}
