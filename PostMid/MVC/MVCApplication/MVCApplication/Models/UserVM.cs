using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
{
    public class UserVM : AuditInformationVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}