using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHocSinhLINQ
{
    // Định nghĩa lớp Student
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // Phương thức để in thông tin Student
        public override string ToString()
        {
            return $"ID: {Id}, Tên: {Name}, Tuổi: {Age}";
        }
    }

   
}
