using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1.View
{
    public partial class FormTrangChu : Form
    {
        FormQuanLyTaiKhoan qltk = new FormQuanLyTaiKhoan();
        FormQuanLyHocSinh qlhs = new FormQuanLyHocSinh();
        FormQuanLyLop qll = new FormQuanLyLop();
        FormQuanLyDiem qld = new FormQuanLyDiem();
        FormQuanLyMonHoc qlmh = new FormQuanLyMonHoc();
        FormBCTongKetMon bctkm = new FormBCTongKetMon();
        FormThayDoiQuyDinh tdqd = new FormThayDoiQuyDinh();
        public FormTrangChu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");

        private void btn_QLHocSinh_Click(object sender, EventArgs e)
        {
            this.Hide();
            qlhs.ShowDialog();
            
        }

        private void btn_QLTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();
            qltk.ShowDialog();
        }

        private void btn_QLMH_Click(object sender, EventArgs e)
        {
            this.Hide();
            qlmh.ShowDialog();
        }

        private void btn_QLLop_Click(object sender, EventArgs e)
        {
            this.Hide();
            qll.ShowDialog();
        }

        private void btn_QLDiem_Click(object sender, EventArgs e)
        {
            this.Hide();
            qld.ShowDialog();
        }

        private void btn_BCMon_Click(object sender, EventArgs e)
        {
            this.Hide();
            bctkm.ShowDialog();
        }

        private void btn_TDQD_Click(object sender, EventArgs e)
        {
            this.Hide();
            tdqd.ShowDialog();
        }

        private void btn_DsLop_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "Select l.MaLop,l.KhoiLop,l.TenLop, (count(MaHS))as SiSo from Lop l, HocSinh hs where l.MaLop = hs.MaLop group by l.MaLop,l.KhoiLop,l.TenLop";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);  
            cnn.Close();  
            dataGridView1.DataSource = dt;
        }

        private void btn_DSMH_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "Select * from MonHoc";
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
        }

        private void btn_DSHS_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "select * from HocSinh "; 
            SqlCommand com = new SqlCommand(sql, cnn); 
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable(); 
            da.Fill(dt);  
            cnn.Close(); 
            dataGridView1.DataSource = dt;
        }

        private void btn_BCM_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "Select * from BCTongKetMon ";
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
        }

        private void FormTrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
