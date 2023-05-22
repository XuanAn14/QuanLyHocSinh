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
    public partial class FormQuanLyTaiKhoan : Form
    {
        public FormQuanLyTaiKhoan()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");
        private Boolean KtraMKCu()
        {
            cnn.Open();
            Boolean ktra = false;
            string sql = "select MatKhau from TaiKhoan";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                if (textB_oldPass.Text == datareader[0].ToString())
                {
                    ktra = true;

                }
                cnn.Close();
                break;
            }

            return ktra;

        }

        private void btn_DoiMK_Click(object sender, EventArgs e)
        {
            try
            {
                if (KtraMKCu().ToString() == "" ||textB_newPass.Text == "")
                {
                    LoiNhapDuLieu loiNhapDuLieu = new LoiNhapDuLieu();
                    throw loiNhapDuLieu;
                }else
                {
                    cnn.Open();

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.Text;

                    string sql = "Update TaiKhoan set MatKhau = '" + textB_newPass.Text + "'";
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = cnn;
                    int ret = sqlCommand.ExecuteNonQuery();
                    if (ret > 0)
                        MessageBox.Show("Đổi mật khẩu thành công");
                    else
                        MessageBox.Show("Đổi mật khẩu không thành công");
                    cnn.Close();
                }
            }
            catch (LoiNhapDuLieu ex)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            textB_newPass.Text = "";
            textB_oldPass.Text = "";
        }


        private void FormQuanLyTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            View.FormTrangChu f = new View.FormTrangChu();
            f.Show();
        }
    }
}
