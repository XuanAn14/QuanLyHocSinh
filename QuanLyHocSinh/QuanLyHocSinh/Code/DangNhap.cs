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
using System.Data.Sql;

namespace WindowsFormsApp1
{
    public partial class FormDangNhap : Form
    {
        View.FormTrangChu ftc = new View.FormTrangChu();
        public FormDangNhap()
        {
            InitializeComponent();
            textB_password.PasswordChar = '*';
            this.CenterToScreen();

        }

        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=QLHS;Integrated Security=True");

        private Boolean KtraTenTK()
        {
            cnn.Open();
            Boolean ktra = false;
            string sql = "select TenNguoiDung from TaiKhoan";
            SqlCommand cmd = new SqlCommand(sql, cnn); 
            
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                if (textB_username.Text == datareader[0].ToString())
                {
                    ktra = true;
                }
               
                break;
            }
            cnn.Close();
            return ktra;
        }

        private Boolean KtraMK()
        {
            cnn.Open();
            Boolean ktra = false;
            string sql = "select MatKhau from TaiKhoan";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                if (textB_password.Text == datareader[0].ToString())
                {
                    ktra = true;

                }
               
                break;
            }
            cnn.Close();
            return ktra;
            
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if(KtraTenTK() && KtraMK())
            {
                this.Hide();
                ftc.ShowDialog();
            } else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không tồn tại, vui lòng nhập lại","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textB_password.PasswordChar = '\0';
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textB_password.PasswordChar = '*';
        }
    }
}
