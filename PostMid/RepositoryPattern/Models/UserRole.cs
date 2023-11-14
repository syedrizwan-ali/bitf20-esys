using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class UserRole : Identity
    {
        public long UserID { get; set; }
        public long RoleID { get; set; }
    }
}
