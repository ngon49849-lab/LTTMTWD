using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class StudentAccess
    {
        Model1 db = new Model1();

        public List<Student> GetAllStudents()
        {
            // Thêm Include("Major") để tải kèm thông tin chuyên ngành
            return db.Students.Include("Faculty").Include("Major").ToList();
        }

        public List<Faculty> GetAllFaculties()
        {
            return db.Faculties.ToList();
        }

        public Student GetStudentByID(string id)
        {
            return db.Students.FirstOrDefault(p => p.StudentID == id);
        }

        public void Add(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
        }

        public void Update(Student s)
        {
            var existing = db.Students.FirstOrDefault(p => p.StudentID == s.StudentID);
            if (existing != null)
            {
                existing.StudentName = s.StudentName;
                existing.AverageScore = s.AverageScore;
                existing.FacultyID = s.FacultyID;

                // Chỉ cập nhật Avatar nếu có giá trị mới truyền vào
                if (!string.IsNullOrEmpty(s.Avatar))
                {
                    existing.Avatar = s.Avatar;
                }

                db.SaveChanges();
            }
        }
        // Trong class StudentAccess
        public void UpdateMajor(string studentID, int? majorID)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentID == studentID);
            if (student != null)
            {
                student.MajorID = majorID;
                db.SaveChanges(); // <-- Bắt buộc phải có dòng này
            }
        }
        public void Delete(string id)
        {
            var existing = db.Students.FirstOrDefault(p => p.StudentID == id);
            if (existing != null)
            {
                db.Students.Remove(existing);
                db.SaveChanges();
            }
        }
    }
}