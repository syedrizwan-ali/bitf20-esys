using MVCApplication.DataAccessLayer.Infrastructures;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplication.DataAccessLayer.Repositories
{
    public class StudentRepository
    {
        DbEntities entities = new DbEntities();

        public List<Student> Get()
        {   
            try
            {
                return entities.Students.ToList();
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }

        public Student Get(long id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Invalid Identifier");

                var result = entities.Students.Where(x => x.ID == id).FirstOrDefault();
                if (ReferenceEquals(result, null))
                {
                    throw new Exception($"No row found with given identifier {id}");
                }
                return result;
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }

        public long Save(Student student)
        {
            try
            {
                if (ReferenceEquals(student, null))
                    throw new Exception("No content received");

                student.CreatedBy = "admin";
                student.CreatedOn = DateTime.UtcNow;

                entities.Students.Add(student);
                var rowsWritten = entities.SaveChanges();

                if (rowsWritten > 0)
                {
                    var lastId = entities.Students.Max(x => x.ID);
                    return lastId;
                }
                else
                {
                    return -1;
                }
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }

        public Student Update(Student student)
        {
            try
            {
                if (ReferenceEquals(student, null))
                    throw new Exception("No content received");

                if (student.ID <= 0)
                    throw new Exception("Invalid Identifier");

                var dbEntity = entities.Students.Where(x => x.ID == student.ID).First();

                dbEntity.ModifiedBy = "admin";
                dbEntity.ModifiedOn = DateTime.UtcNow;
                dbEntity.Name = student.Name;
                dbEntity.RollNumber = student.RollNumber;

                var rowsWritten = entities.SaveChanges();

                return entities.Students.Where(x => x.ID == student.ID).FirstOrDefault();
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }

        public bool Delete(long id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Invalid Identifier");

                var dbEntity = entities.Students.Where(x => x.ID == id).First();
                entities.Students.Remove(dbEntity);
                return entities.SaveChanges() > 0;
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }
    }
}
