namespace GUI
{
    partial class frmStudent
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.chkUnregisterMajor = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDangKy = new System.Windows.Forms.ToolStripMenuItem();
            this.chkLocDiem = new System.Windows.Forms.CheckBox();
            this.txtLocDiem = new System.Windows.Forms.TextBox();
            this.chartMajor = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // --- 1. KHỞI TẠO NÚT LOAD ---
            this.btnLoad = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMajor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudent
            // 
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSV,
            this.colHoTen,
            this.colTenKhoa,
            this.colDiemTB});
            this.dgvStudent.Location = new System.Drawing.Point(368, 94);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudent.Size = new System.Drawing.Size(572, 275);
            this.dgvStudent.TabIndex = 2;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);
            // 
            // colMaSV
            // 
            this.colMaSV.HeaderText = "Mã SV";
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.Width = 80;
            // 
            // colHoTen
            // 
            this.colHoTen.HeaderText = "Họ Tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.Width = 150;
            // 
            // colTenKhoa
            // 
            this.colTenKhoa.HeaderText = "Khoa/Chuyên Ngành";
            this.colTenKhoa.Name = "colTenKhoa";
            this.colTenKhoa.Width = 150;
            // 
            // colDiemTB
            // 
            this.colDiemTB.HeaderText = "ĐTB";
            this.colDiemTB.Name = "colDiemTB";
            this.colDiemTB.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.picAvatar);
            this.groupBox1.Controls.Add(this.cboKhoa);
            this.groupBox1.Controls.Add(this.txtDiemTB);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.txtMaSV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(20, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 433);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Sinh Viên";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(212, 193);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(40, 23);
            this.btnUpload.TabIndex = 11;
            this.btnUpload.Text = "...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(52, 32);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(145, 184);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 10;
            this.picAvatar.TabStop = false;
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.Location = new System.Drawing.Point(80, 331);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(207, 23);
            this.cboKhoa.TabIndex = 12;
            // 
            // txtDiemTB
            // 
            this.txtDiemTB.Location = new System.Drawing.Point(80, 371);
            this.txtDiemTB.Name = "txtDiemTB";
            this.txtDiemTB.Size = new System.Drawing.Size(207, 21);
            this.txtDiemTB.TabIndex = 13;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(80, 291);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(207, 21);
            this.txtHoTen.TabIndex = 14;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(80, 251);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(207, 21);
            this.txtMaSV.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Điểm TB:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Khoa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Họ Tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã SV:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(52, 581);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(142, 581);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(232, 581);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // --- 2. CẤU HÌNH THUỘC TÍNH NÚT LOAD ---
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(322, 581); // Đặt kế bên nút Xóa
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 30);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click); // Bạn nhớ tạo hàm này bên Form1.cs

            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(881, 608);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 30);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelTitle.Location = new System.Drawing.Point(317, 24);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(346, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "QUẢN LÝ SINH VIÊN";
            // 
            // chkUnregisterMajor
            // 
            this.chkUnregisterMajor.AutoSize = true;
            this.chkUnregisterMajor.Location = new System.Drawing.Point(368, 69);
            this.chkUnregisterMajor.Name = "chkUnregisterMajor";
            this.chkUnregisterMajor.Size = new System.Drawing.Size(164, 17);
            this.chkUnregisterMajor.TabIndex = 9;
            this.chkUnregisterMajor.Text = "Chưa đăng ký chuyên ngành";
            this.chkUnregisterMajor.UseVisualStyleBackColor = true;
            this.chkUnregisterMajor.CheckedChanged += new System.EventHandler(this.chkUnregisterMajor_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(968, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDangKy});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.chứcNăngToolStripMenuItem.Text = "Chức Năng";
            // 
            // btnDangKy
            // 
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(200, 22);
            this.btnDangKy.Text = "Đăng ký Chuyen Nganh";
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // chkLocDiem
            // 
            this.chkLocDiem.AutoSize = true;
            this.chkLocDiem.Location = new System.Drawing.Point(560, 69);
            this.chkLocDiem.Name = "chkLocDiem";
            this.chkLocDiem.Size = new System.Drawing.Size(84, 17);
            this.chkLocDiem.TabIndex = 15;
            this.chkLocDiem.Text = "Lọc ĐTB >=";
            this.chkLocDiem.UseVisualStyleBackColor = true;
            this.chkLocDiem.CheckedChanged += new System.EventHandler(this.chkLocDiem_CheckedChanged);
            // 
            // txtLocDiem
            // 
            this.txtLocDiem.Location = new System.Drawing.Point(650, 67);
            this.txtLocDiem.Name = "txtLocDiem";
            this.txtLocDiem.Size = new System.Drawing.Size(50, 20);
            this.txtLocDiem.TabIndex = 16;
            this.txtLocDiem.Text = "8.0";
            this.txtLocDiem.TextChanged += new System.EventHandler(this.txtLocDiem_TextChanged);
            // 
            // chartMajor
            // 
            chartArea3.Name = "ChartArea1";
            this.chartMajor.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartMajor.Legends.Add(legend3);
            this.chartMajor.Location = new System.Drawing.Point(368, 380);
            this.chartMajor.Name = "chartMajor";
            this.chartMajor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "SoLuongSV";
            this.chartMajor.Series.Add(series3);
            this.chartMajor.Size = new System.Drawing.Size(572, 190);
            this.chartMajor.TabIndex = 17;
            this.chartMajor.Text = "Biểu đồ SV";
            // 
            // frmStudent
            // 
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(968, 650);
            this.Controls.Add(this.chartMajor);
            this.Controls.Add(this.txtLocDiem);
            this.Controls.Add(this.chkLocDiem);
            this.Controls.Add(this.chkUnregisterMajor);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvStudent);

            // --- 3. THÊM NÚT LOAD VÀO FORM ---
            this.Controls.Add(this.btnLoad);

            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sinh Viên";
            this.Load += new System.EventHandler(this.frmStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMajor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1, label2, label3, label4;
        private System.Windows.Forms.TextBox txtMaSV, txtHoTen, txtDiemTB;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.CheckBox chkUnregisterMajor;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV, colHoTen, colTenKhoa, colDiemTB;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnThoat;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDangKy;

        // CÁC CONTROL KHAI BÁO MỚI
        private System.Windows.Forms.CheckBox chkLocDiem;
        private System.Windows.Forms.TextBox txtLocDiem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMajor;

        // --- 4. KHAI BÁO BIẾN NÚT LOAD ---
        private System.Windows.Forms.Button btnLoad;
    }
}