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
    public class RoleRepositoryADO : IRepository<Role>
    {
        public long Save(Role role) => 0;

        public Role Update(Role role)
        {
            if (role.ID <= 0)
            {
                throw new Exception("Invalid Identifier");
            }

            //fetch from DB on the basis of ID
            //update in memory the fetched model
            //update in DB

            return role;
        }

        public bool Delete(long id) => false;

        public Role Get(long id) => null;

        public IEnumerable<Role> Get() => null;

        public IEnumerable<Role> Search(Predicate<Role> criteria) => null;

        public IEnumerable<Role> Search(string searchText, string email, string name, DateTime? startDate, DateTime? endDate) => null;

        public PagedList<Role> Page(string searchText, string email, string name, DateTime? startDate, DateTime? endDate, PagingInfo pagingInfo) => null;

        public PagedList<Role> Page(Predicate<Role> criteria, PagingInfo pagingInfo)
        {
            throw new NotImplementedException();
        }
    }
}
