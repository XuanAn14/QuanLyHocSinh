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
    public partial class FormBCTKHocKy : Form
    {
        public FormBCTKHocKy()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-5RUVB35;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "Select * from BCTongKetHocKy ";
            SqlCommand com = new SqlCommand(sql, cnn); 
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable(); 
            da.Fill(dt); 
            cnn.Close();  
            dataGridView1.DataSource = dt; 


        }

        private void FormBCTKHocKy_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            string sql = "insert into BCTongKetHocKy values (@MaBCTongKetHocKy,@MaLop,@HocKy,@SoLuongDat, @TiLe)";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;

            sqlCommand.Parameters.Add("@MaBCTongKetHocKy", SqlDbType.VarChar).Value = textB_MaBC.Text;
            sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = textB_MaLop.Text;
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
            sqlCommand.Parameters.Add("@SoLuongDat", SqlDbType.Int).Value = textB_SoLuongDat.Text;
            sqlCommand.Parameters.Add("@TiLe", SqlDbType.Float).Value = textB_Tile.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Thêm thành công");
            else
                MessageBox.Show("Thêm không thành công");
            //ref
            string sqlstm = "select * from BCTongKetHocKy";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, cnn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            cnn.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void radioButton_1_CheckedChanged(object sender, EventArgs e)
        {
            cnn.Open();

            string sql = "select MaBCTongKetHocKy, concat(l.KhoiLop,l.TenLop) as[Lop], count(hs.MaHS)as SiSo,  SoLuongDat, TiLe from Lop l, HocSinh hs, BCTongKetHocKy  bchk where l.MaLop = hs.MaLop and bchk.MaLop= l.MaLop and HocKy =1 group by l.KhoiLop,l.TenLop,MaBCTongKetHocKy,SoLuongDat, TiLe";
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

            string sql = "select MaBCTongKetHocKy, concat(l.KhoiLop,l.TenLop) as[Lop], count(hs.MaHS)as SiSo,  SoLuongDat, TiLe from Lop l, HocSinh hs, BCTongKetHocKy  bchk where l.MaLop = hs.MaLop and bchk.MaLop= l.MaLop and HocKy =2 group by l.KhoiLop,l.TenLop,MaBCTongKetHocKy,SoLuongDat, TiLe";
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa kết nối máy in");
        }
    }
}
