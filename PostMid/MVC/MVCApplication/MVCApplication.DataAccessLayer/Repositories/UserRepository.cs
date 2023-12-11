using MVCApplication.DataAccessLayer.Helpers;
using MVCApplication.DataAccessLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplication.DataAccessLayer.Repositories
{
    public class UserRepository
    {
        DbEntities entities = new DbEntities();

        public long Create(User user)
        {
            try
            {
                if (ReferenceEquals(user, null))
                {
                    throw new Exception("No content received.");
                }

                user.CreatedBy = "rizwan";
                user.CreatedOn = DateTime.UtcNow;

                entities.Users.Add(user);
                var rowsEffected = entities.SaveChanges();

                if (rowsEffected > 0)
                {
                    return entities.Users.Last().ID;
                }
                return -1;
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }

        public User Check(string email, string password)
        {
            try
            {
                //var hash = new PasswordMaskingHelper().Mask(password);
                var user = entities.Users.Where(x => x.Email == email.Trim()).FirstOrDefault();

                if (user != null && user.Password == password)
                    return user;
                return null;
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }

        public IEnumerable<User> Get()
        {
            return entities.Users.ToList();
        }

        public User Get(long id)
        {
            return entities.Users.Where(x => x.ID == id).FirstOrDefault();
        }

        public User UpdatePassword(long id, string newPassword)
        {
            try
            {
                var user = entities.Users.Where(x => x.ID == id).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("No such user with given identifier exists.");
                }

                var hash = new PasswordMaskingHelper().Mask(newPassword);
                user.Password = hash;

                var rowsUpdated = entities.SaveChanges();
                if (rowsUpdated > 0)
                {
                    return user;
                }

                return null;
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }
    }
}
