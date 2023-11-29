using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
{
    public class StudentVM : AuditInformationVM
    {
        public string Name { get; set; }
        public string RollNumber { get; set; }
    }
}