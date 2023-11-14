using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.HelperClasses
{
    public class PagedList<T> where T : AuditInfo
    {
        public IEnumerable<T> Page { get; set; }
        public int PageNumber { get; set; }
        public int NumberOfPages { get; set; }
    }
}
