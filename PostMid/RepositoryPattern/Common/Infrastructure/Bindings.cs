using Ninject.Modules;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Common.Infrastructure
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            var enableAdoRepos = ConfigurationManager.AppSettings["EnableAdoRepos"];

            if (enableAdoRepos.Equals("true"))
            {
                Bind<IRepository<User>>().To<UserRepositoryADO>();
                Bind<IRepository<Role>>().To<RoleRepositoryADO>();
                Bind<IRepository<Permission>>().To<PermissionRepositoryADO>();
            }
            else
            {
                Bind<IRepository<User>>().To<UserRepositoryEF>();
                Bind<IRepository<Role>>().To<RoleRepositoryEF>();
                Bind<IRepository<Permission>>().To<PermissionRepositoryEF>();
            }
        }
    }
}
