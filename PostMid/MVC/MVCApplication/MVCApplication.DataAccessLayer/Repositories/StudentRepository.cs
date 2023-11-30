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
            return entities.Students.ToList();
        }

        public Student Get(long id)
        {
            if (id <= 0)
                throw new Exception("Invalid Identifier");

            return entities.Students.Where(x => x.ID == id).FirstOrDefault();
        }

        public long Save(Student student)
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

        public Student Update(Student student)
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

        public bool Delete(long id)
        {
            if (id <= 0)
                throw new Exception("Invalid Identifier");

            var dbEntity = entities.Students.Where(x => x.ID == id).First();
            entities.Students.Remove(dbEntity);
            return entities.SaveChanges() > 0;
        }
    }
}
