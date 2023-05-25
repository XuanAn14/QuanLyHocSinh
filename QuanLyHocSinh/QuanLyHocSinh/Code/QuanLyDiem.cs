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
            this.CenterToScreen();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "Select * from Diem";  
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); 
            DataTable dt = new DataTable(); 
            da.Fill(dt);  
            cnn.Close();  
            dataGridView1.DataSource = dt; 


        }

        private void FormQuanLyDiem_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            LayMaMH();
            textB_Diem15.Focus();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = dataGridView1.Rows.Count;
            for(int i = 0; i<count; i++)
            {
                if (i < 9)
                {
                textB_MaDiem.Text = "MD0" + (i+1);
                }
                else
                {
                    textB_MaDiem.Text = "MD" + (i+1);
                }
            }

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
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = comboB_MaMH.SelectedItem.ToString();
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

                if (textB_MaHS.Text =="" || textB_MaDiem.Text == "" || textB_Diem15.Text == "" || textB_Diem1T.Text == "")
                {
                    LoiNhapDuLieu loiNhapDuLieu = new LoiNhapDuLieu();
                    throw loiNhapDuLieu;
                }

                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm không thành công");
            }
            catch(LoiNhapDuLieu ex)
            {
                MessageBox.Show("Nhập dữ liệu không thành công vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(ArithmeticException aex)
            {
                MessageBox.Show("Nhập điểm không thành công vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
            catch(FormatException fex)
            {
                MessageBox.Show("Nhập sai điểm vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cnn.Close();
            ketnoicsdl();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            cnn.Open();
            int CurrentIndex = dataGridView1.CurrentCell.RowIndex;

            string sql = "update Diem set MaHS= '"+dataGridView1.Rows[CurrentIndex].Cells[2].Value.ToString() +"'" +
                ", MaMH = '" + dataGridView1.Rows[CurrentIndex].Cells[3].Value.ToString() + "'" +
                ", HocKy = '" + dataGridView1.Rows[CurrentIndex].Cells[4].Value.ToString() + "'" +
                ", Diem15p = '" + dataGridView1.Rows[CurrentIndex].Cells[5].Value.ToString() + "'" +
                ", Diem1Tiet = '" + dataGridView1.Rows[CurrentIndex].Cells[6].Value.ToString() + "'" +
                " where MaDiem = '" + dataGridView1.Rows[CurrentIndex].Cells[1].Value.ToString() + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, cnn);
            sqlCommand.CommandType = CommandType.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Sửa thành công");
            else
                MessageBox.Show("Sửa không thành công");
            cnn.Close();
            ketnoicsdl();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].FormattedValue)
                {
                    cnn.Open();
                    string sql = "Delete from Diem where MaDiem ='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    int ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                        MessageBox.Show("Xóa thành công");
                    else
                        MessageBox.Show("Xóa không thành công");
                    cnn.Close();
                }
            }
            ketnoicsdl();
        }

        private void btn_DSDiem_Click(object sender, EventArgs e)
        {
            ketnoicsdl();
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
            dataGridView1.DataSource = dt;
            cnn.Close();
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
            dataGridView1.DataSource = dt;
            cnn.Close();
        }

        private void LayMaMH()
        {
            string sql = "select MaMH from MonHoc";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboB_MaMH.Items.Add(dr[0]);
            }
            cnn.Close();
            comboB_MaMH.SelectedIndex = 0;
        }

        private void FormQuanLyDiem_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormTrangChu f = new FormTrangChu();
            f.Show();
        }
    }
}
