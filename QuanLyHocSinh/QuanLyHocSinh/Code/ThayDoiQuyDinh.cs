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
    public partial class FormThayDoiQuyDinh : Form
    {
        public FormThayDoiQuyDinh()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "Select * from ThayDoiQuyDinh";
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;

        }

        private void FormThayDoiQuyDinh_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        public int LayTuoiMin()
        {
            cnn.Open();
            int tuoi = 0;
            string sql = "select TuoiToiThieu from ThayDoiQuyDinh";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                tuoi = int.Parse(datareader[0].ToString());
                break;
            }
            cnn.Close();
            return tuoi;
        }
        public int LayTuoiMax()
        {
            cnn.Open();
            int tuoi = 0;
            string sql = "select TuoiToiDa from ThayDoiQuyDinh";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                tuoi = int.Parse(datareader[0].ToString());
                break;
            }
            cnn.Close();
            return tuoi;
        }

        public int LaySiSoMax()
        {
            cnn.Open();
            int siso = 0;
            string sql = "select SiSoMax from ThayDoiQuyDinh";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                siso = int.Parse(datareader[0].ToString());
                break;
            }
            cnn.Close();
            return siso;
        }
        public int LaySLLopQD()
        {
            cnn.Open();
            int soluong = 0;
            string sql = "select SoLuongLop from ThayDoiQuyDinh";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                soluong = int.Parse(datareader[0].ToString());
                break;
            }
            cnn.Close();
            return soluong;
        }

        public int LaySLMonHocQD()
        {
            cnn.Open();
            int soluong = 0;
            string sql = "select SoLuongMon from ThayDoiQuyDinh";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                soluong = int.Parse(datareader[0].ToString());
                break;
            }
            cnn.Close();
            return soluong;
        }

        public int LayDiemDat()
        {
            cnn.Open();
            int diemdat = 0;
            string sql = "select DiemDat from ThayDoiQuyDinh";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                diemdat = int.Parse(datareader[0].ToString());
                break;
            }
            cnn.Close();
            return diemdat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            try
            {
                string sql = "update ThayDoiQuyDinh set  TuoiToiThieu = @TuoiToiThieu,TuoiToiDa = @TuoiToiDa,SiSoMax = @SiSoMax,SoLuongLop = @SoLuongLop,SoLuongMon = @SoLuongMon, DiemDat = @DiemDat";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = cnn;

                sqlCommand.Parameters.Add("@TuoiToiThieu", SqlDbType.Int).Value = textB_TuoiMin.Text;
                sqlCommand.Parameters.Add("@TuoiToiDa", SqlDbType.Int).Value = textB_TuoiMax.Text;
                sqlCommand.Parameters.Add("@SiSoMax", SqlDbType.Int).Value = textB_SiSoMax.Text;
                sqlCommand.Parameters.Add("@SoLuongLop", SqlDbType.Int).Value = textB_SoLLop.Text;
                sqlCommand.Parameters.Add("@SoLuongMon", SqlDbType.Int).Value = textB_SoLM.Text;
                sqlCommand.Parameters.Add("@DiemDat", SqlDbType.Int).Value = textB_DiemDat.Text;
                if(textB_DiemDat.Text =="" || textB_SiSoMax.Text =="" || textB_SoLLop.Text =="" || textB_SoLM.Text == ""|| textB_TuoiMax.Text =="" || textB_TuoiMin.Text == "")
                {
                    LoiNhapDuLieu loiNhapDuLieu = new LoiNhapDuLieu();
                    throw loiNhapDuLieu;
                }

                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thay đổi thành công", "Thông báo", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Thay đổi không thành công vui lòng nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch(LoiNhapDuLieu lnd)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            cnn.Close();
            ketnoicsdl();
            textB_DiemDat.Text = "";
            textB_SiSoMax.Text = "";
            textB_SoLLop.Text = "";
            textB_SoLM.Text = "";
            textB_TuoiMax.Text = "";
            textB_TuoiMin.Text = "";
            
        }

        private void FormThayDoiQuyDinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormTrangChu f = new FormTrangChu();
            f.Show();
        }
    }
}
