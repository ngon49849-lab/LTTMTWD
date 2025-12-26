using System.Collections.Generic;
using DAL;

namespace BUS
{
    public class MajorService
    {
        MajorAccess majorAccess = new MajorAccess();

        public List<Major> GetAllByFaculty(int facultyID)
        {
            return majorAccess.GetAllMajors(facultyID);
        }
    }
}