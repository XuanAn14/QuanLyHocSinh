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
    public partial class FormBCTongKetMon : Form
    {
        FormThayDoiQuyDinh tdqd = new FormThayDoiQuyDinh();
        FormQuanLyLop qll = new FormQuanLyLop();
        public FormBCTongKetMon()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
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
        private void FormBCTongKetMon_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            LayMaLop();
            LayMaMH();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (i < 9)
                {
                    textB_MaBC.Text = "BCMH0" + (i + 1);
                }
                else
                {
                    textB_MaBC.Text = "BCMH" + (i + 1);
                }
            }

            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;

            string sql = "insert into BCTongKetMon values (@MaBCTongKetMon,@MaLop,@HocKy,@MaMH,@SoLuongDat, @TiLe)";
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = cnn;

            sqlCommand.Parameters.Add("@MaBCTongKetMon", SqlDbType.VarChar).Value = textB_MaBC.Text;
            sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = comboB_MaLop.SelectedItem.ToString();
            sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = comboB_MaMH.SelectedItem.ToString();
            int hocky = 0;
            if (radioButton_1.Checked)
            {
                hocky = 1;
            }
            else if (radioButton_2.Checked)
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
            cnn.Close();
            ketnoicsdl();
            textB_MaBC.Text = "";
            textB_SoLuongDat.Text = "";
            textB_Tile.Text = "";
        }
        private void radioButton_1_CheckedChanged(object sender, EventArgs e)
        {
            int hocky = 1;
            textB_SoLuongDat.Text = LaySoLuongDat(hocky).ToString();
            textB_Tile.Text = TinhTiLe(hocky);

        }
        private void radioButton_2_CheckedChanged(object sender, EventArgs e)
        {
            int hocky = 2;
            textB_SoLuongDat.Text = LaySoLuongDat(hocky).ToString();
            textB_Tile.Text = TinhTiLe(hocky);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cnn.Open();

            string sql = "Select MaBCTongKetMon, concat(l.KhoiLop,l.TenLop) as[Lop],count(hs.MaHS)as SiSo, TenMH, SoLuongDat, TiLe from BCTongKetMon bcm, Lop l, MonHoc mh, HocSinh hs where l.MaLop = hs.MaLop and l.MaLop = bcm.MaLop and HocKy=1 and mh.MaMH = bcm.MaMH group by MaBCTongKetMon,SoLuongDat, TiLe,l.KhoiLop,l.TenLop, l.MaLop, TenMH";
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cnn.Open();

            string sql = "Select MaBCTongKetMon, concat(l.KhoiLop,l.TenLop) as[Lop],count(hs.MaHS)as SiSo, TenMH, SoLuongDat, TiLe from BCTongKetMon bcm, Lop l, MonHoc mh, HocSinh hs where l.MaLop = hs.MaLop and l.MaLop = bcm.MaLop and HocKy=2 and mh.MaMH = bcm.MaMH group by MaBCTongKetMon,SoLuongDat, TiLe,l.KhoiLop,l.TenLop, l.MaLop, TenMH";
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

        private void comboB_MaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton_1.Checked = false;
            radioButton_2.Checked = false;
        }

        private void comboB_MaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton_1.Checked = false;
            radioButton_2.Checked = false;
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].FormattedValue)
                {
                    cnn.Open();
                    string sql = "Delete from BCTongKetMon where MaBCTongKetMon ='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
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

        private void LayMaLop()
        {
            string sql = "select MaLop from Lop";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboB_MaLop.Items.Add(dr[0]);
            }
            cnn.Close();
            comboB_MaLop.SelectedIndex = 0;
        }

        private string TinhTiLe(int hocky)
        {
            
            float sldat = LaySoLuongDat(hocky);
            float siso = LaySiSo();
            string tile = ((sldat / siso) * 100).ToString();
            return tile;

        }

        private int LaySoLuongDat(int hocky)
        {
            string sql = "select Round(AVG((Diem15p + Diem1Tiet*2)/3), 1 ) From Lop l, MonHoc mh, HocSinh hs,Diem d where HocKy ="+hocky+" and hs.MaLop= l.MaLop and hs.MaHS =d.MaHS and mh.MaMH = d.MaMH  and l.MaLop ='"+comboB_MaLop.SelectedItem.ToString()+"' and mh.MaMH = '"+comboB_MaMH.SelectedItem.ToString()+"'  group by hs.MaHS having Round(AVG((Diem15p + Diem1Tiet*2)/3), 1 ) >"+tdqd.LayDiemDat()+"";
            int count = 0;
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            count = dt.Rows.Count;
            cnn.Close();
            return count;
        }


        public int LaySiSo()
        {
            int ketqua = 0;
            cnn.Open();
            string sql = "Select (count(MaHS))as SiSo from Lop l, HocSinh hs where l.MaLop = hs.MaLop and l.MaLop = '" + comboB_MaLop.SelectedItem.ToString() + "' group by l.MaLop";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                ketqua = int.Parse(datareader[0].ToString());
                break;
            }
            cnn.Close();
            return ketqua;
        }

        private void FormBCTongKetMon_FormClosed(object sender, FormClosedEventArgs e)
        {
            View.FormTrangChu f = new View.FormTrangChu();
            f.Show();
        }
    }
}
