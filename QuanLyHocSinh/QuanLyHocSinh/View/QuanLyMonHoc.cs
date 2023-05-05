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
    public partial class FormQuanLyMonHoc : Form
    {
        public FormQuanLyMonHoc()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-5RUVB35;Initial Catalog=QLHS;Integrated Security=True");

        private void ketnoicsdl()
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

        private void FormQuanLyMonHoc_Load(object sender, EventArgs e)
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
                if (textB_MaMH.Text == "" || textB_TenMH.Text == "")
                {
                    throw new Exception();
                }
                string sql = "insert into MonHoc values(@MaMH,@TenMH)";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = cnn;

                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = textB_MaMH.Text;
                sqlCommand.Parameters.Add("@TenMH", SqlDbType.NVarChar).Value = textB_TenMH.Text;

                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm không thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhập dữ liệu không thành công vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            
            //ref
            string sqlstm = "select * from MonHoc";
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

            string sql = "update MonHoc set TenMH = @TenMH where MaMH = @MaMH";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;

            sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = textB_MaMH.Text;
            sqlCommand.Parameters.Add("@TenMH", SqlDbType.NVarChar).Value = textB_TenMH.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Sửa thành công");
            else
                MessageBox.Show("Sửa không thành công");
            //ref
            string sqlstm = "select * from MonHoc";
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

            string sql = "delete from MonHoc where MaMH = @MaMH";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;

            sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = textB_MaMH.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa không thành công");
            //ref
            string sqlstm = "select * from MonHoc";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}
