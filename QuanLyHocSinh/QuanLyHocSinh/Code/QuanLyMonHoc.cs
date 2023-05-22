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
        FormThayDoiQuyDinh tdqd = new View.FormThayDoiQuyDinh();
        public FormQuanLyMonHoc()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");

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
            int count = 0;
            count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (i < 9)
                {
                    textB_MaMH.Text = "MH0" + (i + 1);
                }
                else
                {
                    textB_MaMH.Text = "MH" + (i + 1);
                }
            }
            textB_TenMH.Focus();

            cnn.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            try
            {
                string sql = "insert into MonHoc values(@MaMH,@TenMH)";
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = cnn;

                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = textB_MaMH.Text;
                sqlCommand.Parameters.Add("@TenMH", SqlDbType.NVarChar).Value = textB_TenMH.Text;

                if (count > tdqd.LaySLMonHocQD())
                {
                    Exception SoLuongMonQuaQD = new SoLuongMonQuaQD();
                    throw SoLuongMonQuaQD;
                }

                if(textB_TenMH.Text == "")
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
            catch(LoiNhapDuLieu ex)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SoLuongMonQuaQD ex)
            {
                MessageBox.Show("Số lượng môn vượt quá quy định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cnn.Close();
            ketnoicsdl();
            textB_MaMH.Text = "";
            textB_TenMH.Text = "";

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            cnn.Open();
            int CurrentIndex = dataGridView1.CurrentCell.RowIndex;
            string sql = "Update MonHoc set TenMH = '" + dataGridView1.Rows[CurrentIndex].Cells[2].Value.ToString() + "' where MaMH = '" + dataGridView1.Rows[CurrentIndex].Cells[1].Value.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            int ret = cmd.ExecuteNonQuery();
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
                    string sql = "Delete from MonHoc where MaMH ='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
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

        private void FormQuanLyMonHoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormTrangChu f = new FormTrangChu();
            f.Show();
        }
    }
}
