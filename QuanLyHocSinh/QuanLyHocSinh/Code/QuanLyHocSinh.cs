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
        View.FormQuanLyLop qll = new View.FormQuanLyLop();
        public FormQuanLyHocSinh()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");
        private void ketnoicsdl()
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


        private void QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            LayMaLop();
            textB_HoVaTen.Focus();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (i < 9)
                {
                    textB_MaHS.Text = "SV0" + (i + 1);
                }
                else
                {
                    textB_MaHS.Text = "SV" + (i + 1);
                }
            }


            int siso = LaySiSo();
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
                sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.VarChar).Value = dateTimePicker1.Value.ToShortDateString();
                if (tuoihs < tdqd.LayTuoiMin() || tuoihs > tdqd.LayTuoiMax())
                {
                    throw new ArithmeticException();
                }
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = textB_Email.Text;
                sqlCommand.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = comboB_Lop.SelectedItem.ToString();
                if (siso > tdqd.LaySiSoMax())
                {
                    Exception loiSiSo = new LoiSiSo();
                    throw loiSiSo;
                }
                if(textB_DiaChi.Text ==""||textB_Email.Text =="" || textB_HoVaTen.Text =="")
                {
                    Exception loiNhapDuLieu = new LoiNhapDuLieu();
                    throw loiNhapDuLieu;
                }

                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm không thành công");
            }
            catch (LoiNhapDuLieu)
            {
                MessageBox.Show("Nhập dữ liệu không thành công vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (LoiSiSo lss)
            {
                MessageBox.Show("Sĩ số vượt quá quy định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArithmeticException aex)
            {
                MessageBox.Show("Vui lòng nhập đúng tuổi quy định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cnn.Close();
            ketnoicsdl();
            textB_HoVaTen.Text = "";
            textB_DiaChi.Text = "";
            textB_MaHS.Text = "";
            textB_Email.Text = "";
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            
            cnn.Open();
            int CurrentIndex = dataGridView1.CurrentCell.RowIndex;

            string sql = "update HocSinh set  " +
                " HoVaTen = N'"+dataGridView1.Rows[CurrentIndex].Cells[2].Value.ToString() +"'," +
                " GioiTinh = N'" + dataGridView1.Rows[CurrentIndex].Cells[3].Value.ToString() + "'," +
                " NgaySinh = '" + dataGridView1.Rows[CurrentIndex].Cells[4].Value.ToString() + "'," +
                " DiaChi = N'" + dataGridView1.Rows[CurrentIndex].Cells[5].Value.ToString() + "'," +
                " Email = '" + dataGridView1.Rows[CurrentIndex].Cells[6].Value.ToString() + "'," +
                "MaLop = '" + dataGridView1.Rows[CurrentIndex].Cells[7].Value.ToString() + "'" +
                " where MaHS = '" + dataGridView1.Rows[CurrentIndex].Cells[1].Value.ToString() + "'";
            SqlCommand sqlCommand = new SqlCommand(sql,cnn);
            sqlCommand.CommandType = CommandType.Text;

            int ret = sqlCommand.ExecuteNonQuery();
            if (ret > 0)
                MessageBox.Show("Sửa thành công");
            else
                MessageBox.Show("Sửa không thành công vui lòng nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string sql = "Delete from HocSinh where MaHS ='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
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
            ketnoicsdl();
        }

        private void LayMaLop()
        {
            string sql = "select MaLop from Lop";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboB_Lop.Items.Add(dr[0]);
            }
            cnn.Close();
            comboB_Lop.SelectedIndex = 0;
        }

        private int LaySiSo()
        {
            int ketqua = 0;
            cnn.Open();
            string sql = "Select (count(MaHS))as SiSo from Lop l, HocSinh hs where l.MaLop = hs.MaLop and l.MaLop = '" + comboB_Lop.SelectedItem.ToString() + "' group by l.MaLop";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                ketqua = int.Parse(datareader[0].ToString());

            }
            cnn.Close();
            return ketqua;
        }

        private void comboB_Lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ketqua = "";
            cnn.Open();
            string sql = "select concat(KhoiLop,TenLop) from Lop where MaLop = '" + comboB_Lop.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader datareader = cmd.ExecuteReader();
            datareader.Read();
            ketqua = datareader[0].ToString();
            lb_TenLop.Text = ketqua;
            cnn.Close();
        }

        private void FormQuanLyHocSinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            View.FormTrangChu f = new View.FormTrangChu();
            f.Show();
        }
    }
}
