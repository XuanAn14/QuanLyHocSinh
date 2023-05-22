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
        FormThayDoiQuyDinh tdqd = new View.FormThayDoiQuyDinh();

        public FormQuanLyLop()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "Select * from Lop";
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); 
            DataTable dt = new DataTable(); 
            da.Fill(dt);  
            cnn.Close();  
            dataGridView1.DataSource = dt; 

        }

        private void FormQuanLyLop_Load(object sender, EventArgs e)
        {
            ketnoicsdl();

            LayLop();
            comboB_KhoiLop.SelectedIndex = 0;
            comboB_TenLop.SelectedIndex = 0;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (i < 9)
                {
                    textB_MaLop.Text = "LH0" + (i + 1);
                }
                else
                {
                    textB_MaLop.Text = "LH" + (i + 1);
                }
            }
            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            try
            {

                string sql = "insert into Lop values(@MaLop,@KhoiLop,@TenLop)";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = cnn;

                sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = textB_MaLop.Text;
                sqlCommand.Parameters.Add("@KhoiLop", SqlDbType.VarChar).Value = comboB_KhoiLop.SelectedItem.ToString();
                sqlCommand.Parameters.Add("@TenLop", SqlDbType.VarChar).Value = comboB_TenLop.SelectedItem.ToString();
                if (count > tdqd.LaySLLopQD())
                {
                    Exception LoiSoLuongLop = new LoiSoLuongLop();
                    throw LoiSoLuongLop;
                }

                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm không thành công");

            }
            catch (LoiSoLuongLop ex)
            {
                MessageBox.Show("Số lượng lớp vượt quá quy định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cnn.Close();
            ketnoicsdl();
            textB_MaLop.Text = "";
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            
            cnn.Open();
            int CurrentIndex = dataGridView1.CurrentCell.RowIndex;

            string sql = "update Lop set KhoiLop = '" + dataGridView1.Rows[CurrentIndex].Cells[2].Value.ToString() + "'," +
                " TenLop = '"+ dataGridView1.Rows[CurrentIndex].Cells[3].Value.ToString()+"'" +
                " where MaLop = '" + dataGridView1.Rows[CurrentIndex].Cells[1].Value.ToString() + "'";
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
                    string sql = "Delete from Lop where MaLop ='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
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

        private void btn_dslop_Click(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            string sql = "Select concat(l.KhoiLop,l.TenLop) as[TenLop], HoVaTen, GioiTinh,Year(NgaySinh)as [NamSinh], DiaChi From Lop l ,HocSinh hs Where  concat(l.KhoiLop,l.TenLop) = '"+comboB_Lop.SelectedItem.ToString()+ "' and l.MaLop = hs.MaLop";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;

            string sql2 = "Select (count(MaHS))as SiSo from Lop l, HocSinh hs where l.MaLop = hs.MaLop and concat(l.KhoiLop,l.TenLop) = '" + comboB_Lop.SelectedItem.ToString() + "' group by l.MaLop";

            int ret = sqlCommand.ExecuteNonQuery();

            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); 
            DataTable dt = new DataTable(); 
            da.Fill(dt);  
            cnn.Close();  
            dataGridView1.DataSource = dt;

            label_KetQua.Text = LaySiSo().ToString();
        }

        private void LayLop()
        {
            string sql = "select concat(KhoiLop,TenLop)as[Lop] from Lop";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
            comboB_Lop.Items.Add(dr[0]);
            }
            cnn.Close();
        }

        private int LaySiSo()
        {
            int ketqua = 0;
            cnn.Open();
            string sql = "Select (count(MaHS))as SiSo from Lop l, HocSinh hs where l.MaLop = hs.MaLop and concat(l.KhoiLop,l.TenLop) = '"+comboB_Lop.SelectedItem.ToString() + "' group by l.MaLop";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                ketqua = int.Parse(datareader[0].ToString());
                
            }
            cnn.Close();
            return ketqua;
        }

        private void FormQuanLyLop_FormClosed(object sender, FormClosedEventArgs e)
        {
            View.FormTrangChu f = new View.FormTrangChu();
            f.Show();
        }
    }
}
