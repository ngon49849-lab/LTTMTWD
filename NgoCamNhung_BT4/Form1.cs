using System;
using System.Windows.Forms;
using System.Drawing;

namespace Lab02_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Yêu cầu 2.1: Thiết lập giá trị mặc định khi Load Form
            cmbFaculty.SelectedIndex = 0; // Khoa mặc định là QTKD
            optFemale.Checked = true;    // Giới tính mặc định là Nữ
            CalculateTotals();           // Khởi tạo tổng SV Nam/Nữ là 0
        }

        // Hàm tìm kiếm dòng (row index) của sinh viên theo MSSV trong DataGridView
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                // Tránh lỗi khi gặp dòng trống hoặc ô MSSV null
                if (dgvStudent.Rows[i].Cells[colStudentID.Index].Value != null &&
                    dgvStudent.Rows[i].Cells[colStudentID.Index].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1; // Không tìm thấy
        }

        // Hàm gán/cập nhật dữ liệu từ controls nhập liệu vào DataGridView
        private void InsertUpdate(int selectedRow)
        {
            // Xác định giới tính
            string gender = optMale.Checked ? "Nam" : "Nữ";

            // Kiểm tra và ép kiểu Điểm TB
            if (!float.TryParse(txtAverageScore.Text, out float score))
            {
                throw new Exception("Điểm TB không hợp lệ. Vui lòng nhập số.");
            }

            // Gán giá trị vào dòng
            dgvStudent.Rows[selectedRow].Cells[colStudentID.Index].Value = txtStudentID.Text;
            dgvStudent.Rows[selectedRow].Cells[colFullName.Index].Value = txtFullName.Text;
            dgvStudent.Rows[selectedRow].Cells[colGender.Index].Value = gender;
            dgvStudent.Rows[selectedRow].Cells[colAverageScore.Index].Value = score.ToString("0.0"); // Format điểm 1 chữ số thập phân
            dgvStudent.Rows[selectedRow].Cells[colFaculty.Index].Value = cmbFaculty.Text;
        }

        // Yêu cầu 2.2: Xử lý sự kiện Thêm/Sửa
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra thông tin bắt buộc
                if (string.IsNullOrWhiteSpace(txtStudentID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtAverageScore.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ Mã SV, Họ Tên và Điểm TB!");
                }

                string studentID = txtStudentID.Text;
                int selectedRow = GetSelectedRow(studentID);

                if (selectedRow == -1)
                {
                    // TH Thêm mới
                    selectedRow = dgvStudent.Rows.Add();
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // TH Cập nhật
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CalculateTotals(); // Cập nhật tổng số SV Nam/Nữ
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Yêu cầu 2.3: Xử lý sự kiện Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentID.Text))
                {
                    MessageBox.Show("Vui lòng nhập MSSV cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRow = GetSelectedRow(txtStudentID.Text);
                if (selectedRow == -1)
                {
                    throw new Exception("Không tìm thấy MSSV cần xóa!");
                }

                // Xuất cảnh báo YES/NO
                DialogResult dr = MessageBox.Show($"Bạn có muốn xóa sinh viên {txtStudentID.Text} không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    dgvStudent.Rows.RemoveAt(selectedRow); // Xóa dòng
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dữ liệu trên ô nhập liệu
                    ClearInputFields();
                    CalculateTotals(); // Cập nhật tổng số SV Nam/Nữ
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Yêu cầu 2.4: Xử lý sự kiện khi click vào DataGridView
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem có click vào header column không
                if (e.RowIndex < 0 || e.RowIndex >= dgvStudent.Rows.Count - 1)
                    return;

                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvStudent.Rows[e.RowIndex];

                // Gán ngược dữ liệu ra các controls nhập liệu
                txtStudentID.Text = selectedRow.Cells[colStudentID.Index].Value?.ToString();
                txtFullName.Text = selectedRow.Cells[colFullName.Index].Value?.ToString();
                txtAverageScore.Text = selectedRow.Cells[colAverageScore.Index].Value?.ToString();
                cmbFaculty.Text = selectedRow.Cells[colFaculty.Index].Value?.ToString();

                string gender = selectedRow.Cells[colGender.Index].Value?.ToString();
                if (gender == "Nam")
                    optMale.Checked = true;
                else if (gender == "Nữ")
                    optFemale.Checked = true;

            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi CellClick khi DataGridView rỗng
            }
        }

        // Yêu cầu 2.5: Hàm tính toán và hiển thị tổng số SV Nam/Nữ
        private void CalculateTotals()
        {
            int totalMale = 0;
            int totalFemale = 0;

            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                // Chỉ xử lý các dòng có dữ liệu (không phải dòng trống cuối cùng)
                if (row.Cells[colStudentID.Index].Value != null)
                {
                    string gender = row.Cells[colGender.Index].Value.ToString();
                    if (gender == "Nam")
                    {
                        totalMale++;
                    }
                    else if (gender == "Nữ")
                    {
                        totalFemale++;
                    }
                }
            }
            lblTotalMale.Text = $"Tổng SV Nam: {totalMale}";
            lblTotalFemale.Text = $"Tổng SV Nữ: {totalFemale}";
        }

        // Hàm dọn dẹp các trường nhập liệu
        private void ClearInputFields()
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtAverageScore.Clear();
            optFemale.Checked = true;
            cmbFaculty.SelectedIndex = 0;
        }
    }
}