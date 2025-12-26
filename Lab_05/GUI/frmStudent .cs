using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;

// LƯU Ý: Đổi tên namespace 'GUI' thành tên project của bạn nếu cần (ví dụ: Lab05)
namespace GUI
{
    public partial class frmStudent : Form
    {
        private readonly StudentService studentService = new StudentService();
        private string avatarFilePath = "";

        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);

                FillFalcultyCombobox();
                ApplyFilters();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FillFalcultyCombobox()
        {
            var listFaculties = studentService.GetAllFaculties();
            cboKhoa.DataSource = listFaculties;
            cboKhoa.DisplayMember = "FacultyName";
            cboKhoa.ValueMember = "FacultyID";
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.StudentName;

                if (item.Major != null)
                    dgvStudent.Rows[index].Cells[2].Value = item.Major.Name;
                else if (item.Faculty != null)
                    dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName + " (Chưa ĐK)";

                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
                dgvStudent.Rows[index].Tag = item.Avatar;
            }
        }

        private void BindChart(List<Student> listStudents)
        {
            chartMajor.Series["SoLuongSV"].Points.Clear();
            chartMajor.Titles.Clear();
            chartMajor.Titles.Add("Thống kê Sinh Viên theo Chuyên Ngành");

            var stats = listStudents.GroupBy(s => s.Major != null ? s.Major.Name : "Chưa ĐK CN")
                                    .Select(g => new { Name = g.Key, Count = g.Count() })
                                    .ToList();

            foreach (var item in stats)
            {
                chartMajor.Series["SoLuongSV"].Points.AddXY(item.Name, item.Count);
            }
        }

        private void ApplyFilters()
        {
            var list = studentService.GetAll();
            if (chkUnregisterMajor.Checked) list = list.Where(s => s.MajorID == null).ToList();

            if (chkLocDiem.Checked)
            {
                double scoreRef;
                if (double.TryParse(txtLocDiem.Text, out scoreRef))
                    list = list.Where(s => s.AverageScore >= scoreRef).ToList();
            }

            BindGrid(list);
            BindChart(list);
        }

        // --- CÁC SỰ KIỆN (EVENTS) ---
        // Đảm bảo tên hàm ở đây khớp với Designer
        private void chkUnregisterMajor_CheckedChanged(object sender, EventArgs e) { ApplyFilters(); }
        private void chkLocDiem_CheckedChanged(object sender, EventArgs e) { ApplyFilters(); }
        private void txtLocDiem_TextChanged(object sender, EventArgs e) { if (chkLocDiem.Checked) ApplyFilters(); }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Image Files|*.jpg;*.png";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                avatarFilePath = openDlg.FileName;
                if (File.Exists(avatarFilePath))
                {
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(avatarFilePath)))
                        picAvatar.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e) { HandleUpdate(true); }
        private void btnSua_Click(object sender, EventArgs e) { HandleUpdate(false); }

        private void HandleUpdate(bool isInsert)
        {
            try
            {
                string avatar = null;
                if (!string.IsNullOrEmpty(avatarFilePath))
                {
                    string folder = Path.Combine(Application.StartupPath, "Images");
                    string ext = Path.GetExtension(avatarFilePath);
                    string fileName = txtMaSV.Text + ext;
                    File.Copy(avatarFilePath, Path.Combine(folder, fileName), true);
                    avatar = fileName;
                }

                Student s = new Student()
                {
                    StudentID = txtMaSV.Text,
                    StudentName = txtHoTen.Text,
                    AverageScore = double.Parse(txtDiemTB.Text),
                    FacultyID = (int)cboKhoa.SelectedValue,
                    Avatar = avatar
                };

                bool result = isInsert ? studentService.Insert(s) : studentService.Update(s);
                if (result)
                {
                    MessageBox.Show("Thành công!");
                    ApplyFilters();
                    ResetInput();
                }
                else MessageBox.Show("Thất bại!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa?", "Warn", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (studentService.Delete(txtMaSV.Text)) { ApplyFilters(); ResetInput(); }
            }
        }

        // --- SỰ KIỆN CHO NÚT LOAD ---
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Tải lại danh sách Khoa (đề phòng bên khác có thay đổi)
                FillFalcultyCombobox();

                // 2. Tải lại danh sách sinh viên (vẫn giữ các điều kiện lọc hiện tại nếu có)
                ApplyFilters();

                // 3. Xóa trắng các ô nhập liệu để sẵn sàng nhập mới
                ResetInput();

                MessageBox.Show("Đã tải lại dữ liệu mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message);
            }
        }
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudent.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtDiemTB.Text = row.Cells[3].Value.ToString();

                string imgName = row.Tag as string;
                if (!string.IsNullOrEmpty(imgName))
                {
                    string path = Path.Combine(Application.StartupPath, "Images", imgName);
                    if (File.Exists(path))
                    {
                        using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
                            picAvatar.Image = Image.FromStream(ms);
                    }
                    else picAvatar.Image = null;
                }
                else picAvatar.Image = null;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.ShowDialog();
            ApplyFilters();
        }

        private void btnThoat_Click(object sender, EventArgs e) { Close(); }

        private void ResetInput() { txtMaSV.Clear(); txtHoTen.Clear(); txtDiemTB.Clear(); picAvatar.Image = null; avatarFilePath = ""; }
    }
}