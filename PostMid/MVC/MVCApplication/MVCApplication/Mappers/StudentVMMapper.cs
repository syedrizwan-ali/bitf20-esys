using MVCApplication.DataAccessLayer;
using MVCApplication.Infrastructures.Mappers;
using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Mappers
{
    public class StudentVMMapper : AuditInfoVMMapper<Student, StudentVM>
    {
        public override Student Map(StudentVM obj)
        {
            if (ReferenceEquals(obj, null))
                return null;

            return new Student()
            {
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                ID = obj.ID,
                ModifiedBy = obj.ModifiedBy,
                ModifiedOn = obj.ModifiedOn,
                Name = obj.Name,
                RollNumber = obj.RollNumber
            };
        }

        public override StudentVM Map(Student obj)
        {
            if (ReferenceEquals(obj, null))
                return null;

            return new StudentVM()
            {
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                ID = obj.ID,
                ModifiedBy = obj.ModifiedBy,
                ModifiedOn = obj.ModifiedOn,
                Name = obj.Name,
                RollNumber = obj.RollNumber
            };
        }
    }
}