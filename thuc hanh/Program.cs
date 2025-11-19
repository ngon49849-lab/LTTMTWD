using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHocSinhLINQ
{
    // Định nghĩa lớp Student
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập Console để hiển thị tiếng Việt có dấu
            Console.OutputEncoding = Encoding.UTF8;

            // 1. Tạo danh sách (List) các đối tượng Student
            List<Student> students = new List<Student>
            {
                new Student { Id = 101, Name = "Nguyen Van A", Age = 16 },
                new Student { Id = 102, Name = "Tran Thi B", Age = 19 },
                new Student { Id = 103, Name = "Le Van C", Age = 15 },
                new Student { Id = 104, Name = "Pham Thi D", Age = 17 },
                new Student { Id = 105, Name = "Hoang Dinh E", Age = 20 },
                new Student { Id = 106, Name = "An Dinh G", Age = 17 } // Thêm học sinh thứ 6
            };

            Console.WriteLine("--- 📋 Danh sách Học sinh BAN ĐẦU ---");
            // Yêu cầu a. In danh sách toàn bộ danh sách học sinh.
            YeuCau_a(students);

            // ---

            Console.WriteLine("\n--- 🔎 Yêu cầu b: Học sinh có tuổi từ 15 đến 18 ---");
            YeuCau_b(students);

            // ---

            Console.WriteLine("\n--- 🔎 Yêu cầu c: Học sinh có tên bắt đầu bằng chữ \"A\" ---");
            YeuCau_c(students);

            // ---

            Console.WriteLine("\n--- ➕ Yêu cầu d: Tính tổng tuổi của tất cả học sinh ---");
            YeuCau_d(students);

            // ---

            Console.WriteLine("\n--- 🥇 Yêu cầu e: Học sinh có tuổi lớn nhất ---");
            YeuCau_e(students);

            // ---

            Console.WriteLine("\n--- ⬆️ Yêu cầu f: Sắp xếp theo tuổi tăng dần ---");
            YeuCau_f(students);
        }

        // a. In danh sách toàn bộ danh sách học sinh.
        static void YeuCau_a(List<Student> students)
        {
            // LINQ: Lấy toàn bộ danh sách (có thể bỏ qua LINQ, nhưng dùng để thống nhất)
            var allStudents = students.Select(s => s);

            foreach (var student in allStudents)
            {
                Console.WriteLine(student);
            }
        }

        // b. Tìm và in ra danh sách các học sinh có tuổi từ 15 đến 18.
        static void YeuCau_b(List<Student> students)
        {
            // LINQ: Sử dụng Where để lọc điều kiện tuổi
            var filteredStudents = students.Where(s => s.Age >= 15 && s.Age <= 18);

            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }

        // c. Tìm và in ra học sinh có tên bắt đầu bằng chữ "A".
        static void YeuCau_c(List<Student> students)
        {
            // LINQ: Sử dụng Where kết hợp với phương thức string.StartsWith()
            var studentsStartingWithA = students.Where(s => s.Name.StartsWith("A"));

            foreach (var student in studentsStartingWithA)
            {
                Console.WriteLine(student);
            }
        }

        // d. Tính tổng tuổi của tất cả học sinh trong danh sách.
        static void YeuCau_d(List<Student> students)
        {
            // LINQ: Sử dụng phương thức Sum()
            int totalAge = students.Sum(s => s.Age);

            Console.WriteLine($"Tổng tuổi của tất cả học sinh là: {totalAge}");
        }

        // e. Tìm và in ra học sinh có tuổi lớn nhất.
        static void YeuCau_e(List<Student> students)
        {
            // Bước 1: Tìm tuổi lớn nhất
            int maxAge = students.Max(s => s.Age);

            // Bước 2: Lọc ra học sinh có tuổi bằng tuổi lớn nhất (có thể có nhiều hơn 1)
            var oldestStudents = students.Where(s => s.Age == maxAge);

            Console.WriteLine($"Tuổi lớn nhất là: {maxAge}");
            Console.WriteLine("Danh sách học sinh có tuổi lớn nhất:");
            foreach (var student in oldestStudents)
            {
                Console.WriteLine(student);
            }
        }

        static void YeuCau_f(List<Student> students)
        {
            // LINQ: Sử dụng OrderBy()
            var sortedStudents = students.OrderBy(s => s.Age);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}