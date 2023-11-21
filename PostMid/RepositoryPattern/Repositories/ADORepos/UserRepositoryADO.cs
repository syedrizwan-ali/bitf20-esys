using RepositoryPattern.Common.Helpers;
using RepositoryPattern.HelperClasses;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Repositories
{
    public class UserRepositoryADO : IRepository<User>
    {
        public long Save(User user) => 0;

        public User Update(User user)
        {
            if (user.ID <= 0)
            {
                throw new Exception("Invalid Identifier");
            }

            //fetch from DB on the basis of ID
            //update in memory the fetched model
            //update in DB

            return user;
        }

        public bool Delete(long id) => false;

        public User Get(long id)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                return null;
            }
            catch(Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public IEnumerable<User> Get()
        {
            Console.WriteLine("UserRepositoryADO Get");
            return null;
        }

        public IEnumerable<User> Search(Predicate<User> criteria) => null;

        public IEnumerable<User> Search(string searchText, string email, string name, DateTime? startDate, DateTime? endDate) => null;
        
        public PagedList<User> Page(string searchText, string email, string name, DateTime? startDate, DateTime? endDate, PagingInfo pagingInfo) => null;

        public PagedList<User> Page(Predicate<User> criteria, PagingInfo pagingInfo)
        {
            throw new NotImplementedException();
        }
    }
}
