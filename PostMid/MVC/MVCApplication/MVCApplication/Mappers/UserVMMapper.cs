using MVCApplication.DataAccessLayer;
using MVCApplication.Infrastructures.Mappers;
using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Mappers
{
    public class UserVMMapper : AuditInfoVMMapper<User, UserVM>
    {
        public override User Map(UserVM obj)
        {
            if (obj == null) return null;

            return new User()
            {
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                Email = obj.Email,
                ID = obj.ID,
                ModifiedBy = obj.ModifiedBy,
                ModifiedOn = obj.ModifiedOn,
                Name = obj.Name,
                Password = obj.Password
            };
        }

        public override UserVM Map(User obj)
        {
            if (obj == null) return null;

            return new UserVM()
            {
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                Email = obj.Email,
                ID = obj.ID,
                ModifiedBy = obj.ModifiedBy,
                ModifiedOn = obj.ModifiedOn,
                Name = obj.Name,
                Password = obj.Password
            };
        }
    }
}