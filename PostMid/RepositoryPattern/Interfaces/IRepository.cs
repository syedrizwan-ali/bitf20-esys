using RepositoryPattern.HelperClasses;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T : AuditInfo
    {
        long Save(T user);
        T Update(T user);
        bool Delete(long id);
        T Get(long id);
        IEnumerable<T> Get();
        IEnumerable<T> Search(Predicate<T> criteria);
        PagedList<T> Page(Predicate<T> criteria, PagingInfo pagingInfo);
    }
}
