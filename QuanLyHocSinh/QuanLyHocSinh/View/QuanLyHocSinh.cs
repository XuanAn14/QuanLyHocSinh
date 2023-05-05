using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{

    public partial class FormQuanLyHocSinh : Form
    {
        View.FormThayDoiQuyDinh tdqd = new View.FormThayDoiQuyDinh();
        public FormQuanLyHocSinh()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-5RUVB35;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "select * from HocSinh ";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview

        }

        private void QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            try
            {
                string sql = "insert into HocSinh values(@MaHS , @HoVaTen, @GioiTinh, @NgaySinh, @DiaChi, @Email,@MaLop)";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = cnn;

                sqlCommand.Parameters.Add("@MaHS", SqlDbType.VarChar).Value = textB_MaHS.Text;
                sqlCommand.Parameters.Add("@HoVaTen", SqlDbType.NVarChar).Value = textB_HoVaTen.Text;
                sqlCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = textB_DiaChi.Text;
                string gioiTinh = "";
                if (radioB_Nam.Checked)
                {
                    gioiTinh = radioB_Nam.Text;
                }
                else if (radioB_Nu.Checked)
                {
                    gioiTinh = radioB_Nu.Text;
                }
                sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = gioiTinh.ToString();

                int tuoihs = DateTime.Now.Year - dateTimePicker1.Value.Year;

                sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dateTimePicker1.Value.ToShortDateString();
                if (tuoihs < tdqd.LayTuoiMin() || tuoihs > tdqd.LayTuoiMax())
                {
                    throw new ArithmeticException("Nhập sai độ tuổi quy định");
                }
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = textB_Email.Text;
                sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = textBox_MaLop.Text;
                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm không thành công");
            }
            catch (ArithmeticException ex)
            {
                MessageBox.Show("Vui lòng nhập đúng tuổi quy định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            //ref
            string sqlstm = "select * from HocSinh";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            string sql = "update HocSinh set  HoVaTen = @HoVaTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DiaChi = @DiaChi, Email = @Email,MaLop = @MaLop where MaHS = @MaHS";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection =cnn;

            sqlCommand.Parameters.Add("@MaHS", SqlDbType.VarChar).Value = textB_MaHS.Text;
            sqlCommand.Parameters.Add("@HoVaTen", SqlDbType.NVarChar).Value = textB_HoVaTen.Text;
            sqlCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = textB_DiaChi.Text;
            string gioiTinh = "";
            if (radioB_Nam.Checked)
            {
                gioiTinh = radioB_Nam.Text;
            }
            else if (radioB_Nu.Checked)
            {
                gioiTinh = radioB_Nu.Text;
            }
            sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = gioiTinh.ToString();
            sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dateTimePicker1.Value.ToShortDateString();
            sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = textB_Email.Text;
            sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = textBox_MaLop.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Sửa thành công");
            else
                MessageBox.Show("Sửa không thành công vui lòng nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //ref
            string sqlstm = "select * from HocSinh";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            string sql = "delete from HocSinh where MaHS = @MaHS";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;

            sqlCommand.Parameters.Add("@MaHS", SqlDbType.VarChar).Value = textB_MaHS.Text;
            

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa không thành công vui lòng nhập mã học sinh muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //ref
            string sqlstm = "select * from HocSinh";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                string sql = "Select * from HocSinh hs where hs.MaHS = @MaHS";
                if (radioButton_1.Checked)
                {
                    sql = "declare @MaHS varchar(10)= '" + textB_TKMaHS.Text + "' " +
                        "select hs.HoVaTen,concat(l.KhoiLop,l.TenLop) as[TenLop], mh.TenMH ,Round(AVG((Diem15p + Diem1Tiet*2)/3), 1) as [TBHocKyI] from Diem d, HocSinh hs, Lop l, MonHoc mh where HocKy =1 and hs.MaHS = d.MaHS and l.MaLop = hs.MaLop and @MaHS = hs.MaHS and mh.MaMH = d.MaMH group by hs.HoVaTen,l.KhoiLop,l.TenLop,mh.TenMH";
                }
                else if (radioButton_2.Checked)
                {
                    sql = "declare @MaHS varchar(10)= '" + textB_TKMaHS.Text + "' " +
                        "select hs.HoVaTen,concat(l.KhoiLop,l.TenLop) as[TenLop], mh.TenMH ,Round(AVG((Diem15p + Diem1Tiet*2)/3), 1) as [TBHocKyII] from Diem d, HocSinh hs, Lop l, MonHoc mh where HocKy =2 and hs.MaHS = d.MaHS and l.MaLop = hs.MaLop and @MaHS = hs.MaHS and mh.MaMH = d.MaMH group by hs.HoVaTen,l.KhoiLop,l.TenLop,mh.TenMH";
                }
                SqlCommand com = new SqlCommand(sql, cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập mã học sinh, học kỳ cần tra cứu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btn_HSHocSinh_Click(object sender, EventArgs e)
        {
            string sqlstm = "select * from HocSinh ";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        
    }
}
