using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Modify modify;
        NhanVien nhanVien;
        private void Form1_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.getAllNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex}");
            }
        }

        private void button1_Click(object sender, EventArgs e) //add function
        {
            string id = this.textBox1.Text;
            string name = this.textBox2.Text;
            string sex = (radioButton1.Checked ? radioButton1.Text : radioButton2.Text);
            DateTime dateOfBirth = this.dateTimePicker1.Value;
            string address = this.textBox3.Text;
            string phoneNumber = this.textBox4.Text;    
            nhanVien = new NhanVien(id, name, sex, dateOfBirth,address,phoneNumber);
            if (modify.insert(nhanVien))
            {
                dataGridView1.DataSource = modify.getAllNhanVien();
            }
            else
            {
                MessageBox.Show("Lỗi: ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.delete(id))
            {
                dataGridView1.DataSource = modify.getAllNhanVien();
            }
            else
            {
                MessageBox.Show("Lỗi: ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = this.textBox1.Text;
            string name = this.textBox2.Text;
            string sex = (radioButton1.Checked ? radioButton1.Text : radioButton2.Text);
            DateTime dateOfBirth = this.dateTimePicker1.Value;
            string address = this.textBox3.Text;
            string phoneNumber = this.textBox4.Text;
            nhanVien = new NhanVien(id, name, sex, dateOfBirth, address, phoneNumber);
            if (modify.update(nhanVien))
            {
                dataGridView1.DataSource = modify.getAllNhanVien();
            }
            else
            {
                MessageBox.Show("Lỗi: ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(string path)
        {
            //export
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i <= dataGridView1.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
