using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BUS
{
    public class StudentService
    {
        StudentAccess studentAccess = new StudentAccess();

        public List<Student> GetAll()
        {
            return studentAccess.GetAllStudents();
        }

        public List<Faculty> GetAllFaculties()
        {
            return studentAccess.GetAllFaculties();
        }
        // Thêm vào class StudentService hiện tại
        public List<Student> GetStudentsNoMajor(int facultyID)
        {
            // Lấy SV thuộc khoa đó NHƯNG MajorID là null
            return studentAccess.GetAllStudents()
                                .Where(s => s.FacultyID == facultyID && s.MajorID == null)
                                .ToList();
        }

        public void RegisterMajor(string studentID, int majorID)
        {
            studentAccess.UpdateMajor(studentID, majorID);
        }
        public bool Insert(Student s)
        {
            if (studentAccess.GetStudentByID(s.StudentID) != null)
                return false;

            studentAccess.Add(s);
            return true;
        }

        public bool Update(Student s)
        {
            if (studentAccess.GetStudentByID(s.StudentID) == null)
                return false;

            studentAccess.Update(s);
            return true;
        }

        public bool Delete(string id)
        {
            if (studentAccess.GetStudentByID(id) == null)
                return false;

            studentAccess.Delete(id);
            return true;
        }
    }
}