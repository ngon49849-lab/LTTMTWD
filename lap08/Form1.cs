using System;
using System.Data.Entity;
using System.Windows.Forms;
using lap08.Model;

namespace lap08
{
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db.Students.Load();
            bs.DataSource = db.Students.Local.ToBindingList();
            dgvStudents.DataSource = bs;

            txtFullName.DataBindings.Add("Text", bs, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bs, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbMajor.DataBindings.Add("Text", bs, "Major", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newStudent = new Student
            {
                FullName = txtFullName.Text,
                Age = int.TryParse(txtAge.Text, out int age) ? age : 0,
                Major = cmbMajor.Text
            };

            db.Students.Add(newStudent);
            db.SaveChanges();
            bs.MoveLast();
            dgvStudents.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var student = bs.Current as Student;
            if (student == null) return;

            bs.RemoveCurrent();            // removes from the bound list
            db.Students.Remove(student);   // ensure EF will delete it
            db.SaveChanges();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bs.Current != null)
            {
                db.SaveChanges();
                dgvStudents.Refresh();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }
    }
}