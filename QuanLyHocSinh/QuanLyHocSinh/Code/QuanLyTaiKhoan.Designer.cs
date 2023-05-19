namespace WindowsFormsApp1.View
{
    partial class FormQuanLyTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.textB_oldPass = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textB_newPass = new System.Windows.Forms.TextBox();
            this.btn_DoiMK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(148, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 31);
            this.label6.TabIndex = 44;
            this.label6.Text = "Quản Lý Tài Khoản";
            // 
            // textB_oldPass
            // 
            this.textB_oldPass.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textB_oldPass.Location = new System.Drawing.Point(184, 32);
            this.textB_oldPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textB_oldPass.Name = "textB_oldPass";
            this.textB_oldPass.Size = new System.Drawing.Size(313, 30);
            this.textB_oldPass.TabIndex = 47;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 37);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 22);
            this.label13.TabIndex = 46;
            this.label13.Text = "Mật Khẩu Cũ: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 22);
            this.label1.TabIndex = 46;
            this.label1.Text = "Mật Khẩu Mới: ";
            // 
            // textB_newPass
            // 
            this.textB_newPass.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textB_newPass.Location = new System.Drawing.Point(184, 94);
            this.textB_newPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textB_newPass.Name = "textB_newPass";
            this.textB_newPass.Size = new System.Drawing.Size(313, 30);
            this.textB_newPass.TabIndex = 47;
            // 
            // btn_DoiMK
            // 
            this.btn_DoiMK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_DoiMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DoiMK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoiMK.ForeColor = System.Drawing.Color.White;
            this.btn_DoiMK.Location = new System.Drawing.Point(185, 175);
            this.btn_DoiMK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_DoiMK.Name = "btn_DoiMK";
            this.btn_DoiMK.Size = new System.Drawing.Size(168, 46);
            this.btn_DoiMK.TabIndex = 48;
            this.btn_DoiMK.Text = "Đổi Mật Khẩu";
            this.btn_DoiMK.UseVisualStyleBackColor = false;
            this.btn_DoiMK.Click += new System.EventHandler(this.btn_DoiMK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_DoiMK);
            this.panel1.Controls.Add(this.textB_newPass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textB_oldPass);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(28, 126);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 244);
            this.panel1.TabIndex = 49;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 27);
            this.label2.TabIndex = 50;
            this.label2.Text = "Đổi Mật Khẩu";
            // 
            // FormQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 433);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormQuanLyTaiKhoan";
            this.Text = "Quản Lý Sinh Viên";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textB_oldPass;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textB_newPass;
        private System.Windows.Forms.Button btn_DoiMK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}