using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DAL;

namespace GUI
{
    public partial class frmRegister : Form
    {
        StudentService studentService = new StudentService();
        MajorService majorService = new MajorService();

        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                var listFaculties = studentService.GetAllFaculties();
                cboKhoa.DataSource = listFaculties;
                cboKhoa.DisplayMember = "FacultyName";
                cboKhoa.ValueMember = "FacultyID";

                // Kích hoạt sự kiện để load dữ liệu lần đầu
                cboKhoa_SelectedIndexChanged(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // Khi chọn Khoa -> Load Chuyên Ngành tương ứng & Load Sinh viên chưa có chuyên ngành
        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboKhoa.SelectedValue != null)
                {
                    int facultyID = (int)cboKhoa.SelectedValue;

                    // 1. Load Chuyên Ngành
                    var listMajors = majorService.GetAllByFaculty(facultyID);
                    cboChuyenNganh.DataSource = listMajors;
                    cboChuyenNganh.DisplayMember = "Name";
                    cboChuyenNganh.ValueMember = "MajorID";

                    // 2. Load Sinh viên chưa có chuyên ngành thuộc khoa đó
                    var listStudents = studentService.GetStudentsNoMajor(facultyID);
                    BindGrid(listStudents);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<Student> list)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = false; // <-- Gán mặc định false để tránh null
                dgvStudent.Rows[index].Cells[1].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[2].Value = item.StudentName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra chọn chuyên ngành chưa
            if (cboChuyenNganh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn chuyên ngành!", "Lỗi");
                return;
            }

            // 2. Xác nhận kết thúc chỉnh sửa trên lưới (BẮT BUỘC)
            dgvStudent.EndEdit();

            int majorID = (int)cboChuyenNganh.SelectedValue;
            int count = 0;

            // 3. Duyệt qua từng dòng
            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                // --- FIX 1: Bỏ qua dòng trống cuối cùng (nếu có) ---
                if (row.IsNewRow) continue;

                // --- FIX 2: Lấy giá trị bằng TÊN CỘT "colSelect" thay vì số 0 ---
                // (Giúp tránh lỗi nếu cột Checkbox không nằm đầu tiên)
                var cellValue = row.Cells["colSelect"].Value;

                // --- FIX 3: Kiểm tra null kỹ càng ---
                bool isSelected = false;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    // Ép kiểu an toàn: Chuyển sang string rồi sang bool để tránh lỗi format
                    bool.TryParse(cellValue.ToString(), out isSelected);
                }

                if (isSelected)
                {
                    try
                    {
                        // Lấy Mã SV (Thay "colMaSV" bằng tên cột Mã SV của bạn hoặc dùng chỉ số cột nếu chắc chắn)
                        // Ở code designer trước tôi đặt là colMaSV
                        string studentID = row.Cells["colMaSV"].Value.ToString();

                        studentService.RegisterMajor(studentID, majorID);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi dòng {row.Index}: {ex.Message}");
                    }
                }
            }

            // 4. Kết quả
            if (count > 0)
            {
                MessageBox.Show($"Đăng ký thành công {count} sinh viên!");
                cboKhoa_SelectedIndexChanged(sender, e); // Load lại danh sách
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sinh viên nào (hoặc chưa tích vào ô vuông)!");
            }
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}