using RepositoryPattern.HelperClasses;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Repositories
{
    public class PermissionRepositoryEF : IRepository<Permission>
    {
        public long Save(Permission permission) => 0;

        public Permission Update(Permission permission)
        {
            if (permission.ID <= 0)
            {
                throw new Exception("Invalid Identifier");
            }

            //fetch from DB on the basis of ID
            //update in memory the fetched model
            //update in DB

            return permission;
        }

        public bool Delete(long id) => false;

        public Permission Get(long id) => null;

        public IEnumerable<Permission> Get() => null;

        public IEnumerable<Permission> Search(Predicate<Permission> criteria) => null;

        public IEnumerable<Permission> Search(string searchText, string email, string name, DateTime? startDate, DateTime? endDate) => null;

        public PagedList<Permission> Page(string searchText, string email, string name, DateTime? startDate, DateTime? endDate, PagingInfo pagingInfo) => null;

        public PagedList<Permission> Page(Predicate<Permission> criteria, PagingInfo pagingInfo)
        {
            throw new NotImplementedException();
        }
    }
}
