using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class RolePermission : Identity
    {
        public long PermissionID { get; set; }
        public long RoleID { get; set; }
    }
}
