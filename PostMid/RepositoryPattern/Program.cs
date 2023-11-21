using Ninject;
using RepositoryPattern.Common.Infrastructure;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            new ReferenceFinder();

            var repo = ReferenceFinder.Find<IRepository<User>>();
            repo.Get();
        }
    }
}
