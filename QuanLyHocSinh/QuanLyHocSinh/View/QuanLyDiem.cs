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

namespace WindowsFormsApp1.View
{
    public partial class FormQuanLyDiem : Form
    {
        public FormQuanLyDiem()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-5RUVB35;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "Select * from Diem";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview


        }

        private void FormQuanLyDiem_Load(object sender, EventArgs e)
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
                string sql = "insert into Diem values (@MaDiem,@MaHS,@MaMH, @HocKy,@Diem15p, @Diem1Tiet)";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = cnn;

                sqlCommand.Parameters.Add("@MaDiem", SqlDbType.VarChar).Value = textB_MaDiem.Text;
                sqlCommand.Parameters.Add("@MaHS", SqlDbType.VarChar).Value = textB_MaHS.Text;
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = textB_MaMH.Text;
                int hocky = 0;
                if (radioButton1.Checked)
                {
                    hocky = 1;
                }
                else if (radioButton2.Checked)
                {
                    hocky = 2;
                }
                sqlCommand.Parameters.Add("@HocKy", SqlDbType.Int).Value = hocky;
                sqlCommand.Parameters.Add("@Diem15p", SqlDbType.Float).Value = textB_Diem15.Text;
                sqlCommand.Parameters.Add("@Diem1Tiet", SqlDbType.Float).Value = textB_Diem1T.Text;

                string text_d15 = string.Format(textB_Diem15.Text);
                string text_d1t = string.Format(textB_Diem1T.Text);
                float diem15 = float.Parse(text_d15);
                float diem1t = float.Parse(text_d1t);
                if (diem15 < 0 || diem15 > 10)
                {
                    throw new ArithmeticException();
                }
                else if (diem1t < 0 || diem1t > 10)
                {
                    throw new ArithmeticException();
                }

                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm không thành công");
            }
            catch(ArithmeticException aex)
            {
                MessageBox.Show("Nhập dữ liệu không thành công vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
            catch(FormatException fex)
            {
                MessageBox.Show("Nhập sai điểm vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            //ref
            string sqlstm = "select * from Diem";
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

            string sql = "update Diem set MaHS= @MaHS, MaMH = @MaMH, HocKy = @HocKy, Diem15p = @Diem15p, Diem1Tiet = @Diem1Tiet where MaDiem = @MaDiem";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;

            sqlCommand.Parameters.Add("@MaDiem", SqlDbType.VarChar).Value = textB_MaDiem.Text;
            sqlCommand.Parameters.Add("@MaHS", SqlDbType.VarChar).Value = textB_MaHS.Text;
            sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = textB_MaMH.Text;
            int hocky = 0;
            if (radioButton1.Checked)
            {
                hocky = 1;
            }
            else if (radioButton2.Checked)
            {
                hocky = 2;
            }
            sqlCommand.Parameters.Add("@HocKy", SqlDbType.Int).Value = hocky;
            sqlCommand.Parameters.Add("@Diem15p", SqlDbType.Float).Value = textB_Diem15.Text;
            sqlCommand.Parameters.Add("@Diem1Tiet", SqlDbType.Float).Value = textB_Diem1T.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Sửa thành công");
            else
                MessageBox.Show("Sửa không thành công");
            //ref
            string sqlstm = "select * from Diem";
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

            string sql = "delete from Diem where MaDiem = @MaDiem";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;

            sqlCommand.Parameters.Add("@MaDiem", SqlDbType.VarChar).Value = textB_MaDiem.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa không thành công");
            //ref
            string sqlstm = "select * from Diem";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }


        private void radioButton_1_CheckedChanged(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "select concat(l.KhoiLop,l.TenLop) as[TenLop] , TenMH , HoVaTen, Diem15p , Diem1Tiet,Round(AVG((Diem15p + Diem1Tiet*2)/3), 1) as [Diem TB] From Lop l, MonHoc mh, HocSinh hs,Diem d where HocKy =1 and l.MaLop= hs.MaLop and hs.MaHS =d.MaHS and d.MaMH = mh.MaMH group by l.KhoiLop,l.TenLop , TenMH , HoVaTen, Diem15p , Diem1Tiet";

            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
        }

        private void radioButton_2_CheckedChanged(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "select concat(l.KhoiLop,l.TenLop) as[TenLop] , TenMH , HoVaTen, Diem15p , Diem1Tiet,Round(AVG((Diem15p + Diem1Tiet*2)/3), 1) as [Diem TB] From Lop l, MonHoc mh, HocSinh hs,Diem d where HocKy =2 and l.MaLop= hs.MaLop and hs.MaHS =d.MaHS and d.MaMH = mh.MaMH group by l.KhoiLop,l.TenLop , TenMH , HoVaTen, Diem15p , Diem1Tiet";

            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
