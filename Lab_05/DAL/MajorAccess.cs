using System.Collections.Generic;
using System.Linq;
namespace DAL
{
    public class MajorAccess
    {
        Model1 db = new Model1();
        public List<Major> GetAllMajors(int facultyID)
        {
            return db.Majors.Where(m => m.FacultyID == facultyID).ToList();
        }
    }
}