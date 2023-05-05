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
    public partial class FormQuanLyLop : Form
    {
        public FormQuanLyLop()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-5RUVB35;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "Select l.MaLop,l.KhoiLop,l.TenLop, (count(MaHS))as SiSo from Lop l, HocSinh hs where l.MaLop = hs.MaLop group by l.MaLop,l.KhoiLop,l.TenLop";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); 
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview

        }

        private void FormQuanLyLop_Load(object sender, EventArgs e)
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
                if (textB_KhoiLop.Text == "" || textB_MaLop.Text == "" || textB_TenLop.Text == "")
                {
                    throw new Exception();
                }
                string sql = "insert into Lop values(@MaLop,@KhoiLop,@TenLop)";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = cnn;

                sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = textB_MaLop.Text;
                sqlCommand.Parameters.Add("@KhoiLop", SqlDbType.VarChar).Value = textB_KhoiLop.Text;
                sqlCommand.Parameters.Add("@TenLop", SqlDbType.VarChar).Value = textB_TenLop.Text;


                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm không thành công");
                //ref
                string sqlstm = "select * from Lop";
                SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
                DataSet DS = new System.Data.DataSet();
                SDA.Fill(DS);
                cnn.Close();
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhập dữ liệu không thành công vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string strConnection = (@"Data Source=DESKTOP-5RUVB35;Initial Catalog=QLHS;Integrated Security=True");
            SqlConnection sqlConnection = new SqlConnection(strConnection);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            string sql = "update Lop set KhoiLop = @KhoiLop, TenLop = @TenLop where MaLop = @MaLop";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = textB_MaLop.Text;

            sqlCommand.Parameters.Add("@KhoiLop", SqlDbType.VarChar).Value = textB_KhoiLop.Text;
            sqlCommand.Parameters.Add("@TenLop", SqlDbType.VarChar).Value = textB_TenLop.Text;
            //listBox_Lop.Items.Add(textB_KhoiLop.Text + "" + textB_TenLop.Text);

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Sửa thành công");
            else
                MessageBox.Show("Sửa không thành công");
            //ref
            string sqlstm = "select * from Lop";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string strConnection = (@"Data Source=DESKTOP-5RUVB35;Initial Catalog=QLHS;Integrated Security=True");
            SqlConnection sqlConnection = new SqlConnection(strConnection);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            string sql = "delete from Lop where MaLop = @MaLop";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = textB_MaLop.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa không thành công");
            //ref
            string sqlstm = "select * from Lop";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "Select concat(l.KhoiLop,l.TenLop) as[TenLop], HoVaTen, GioiTinh,Year(NgaySinh)as [NamSinh], DiaChi From Lop l ,HocSinh hs Where  l.MaLop = hs.MaLop ";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }

        private void btn_dslop_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "Select l.MaLop,l.KhoiLop,l.TenLop, (count(MaHS))as SiSo from Lop l, HocSinh hs where l.MaLop = hs.MaLop group by l.MaLop,l.KhoiLop,l.TenLop ";  // lay het du lieu trong bang sinh vien
            //string sql = "Select* from Lop";
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            string sql = "declare @MaLop varchar(10) = '"+ textB_timkiem.Text + "' Select * from Lop where MaLop = @MaLop";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;


            int ret = sqlCommand.ExecuteNonQuery();

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
