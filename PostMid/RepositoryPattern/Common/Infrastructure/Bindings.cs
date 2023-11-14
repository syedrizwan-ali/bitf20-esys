using Ninject.Modules;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Common.Infrastructure
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<User>>().To<UserRepository>();
            Bind<IRepository<Role>>().To<RoleRepository>();
            Bind<IRepository<Permission>>().To<PermissionRepository>();
        }
    }
}
