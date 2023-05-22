namespace WindowsFormsApp1.View
{
    partial class FormTrangChu
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_TDQD = new System.Windows.Forms.Button();
            this.btn_QLTaiKhoan = new System.Windows.Forms.Button();
            this.btn_QLMH = new System.Windows.Forms.Button();
            this.btn_QLDiem = new System.Windows.Forms.Button();
            this.btn_QLLop = new System.Windows.Forms.Button();
            this.btn_BCMon = new System.Windows.Forms.Button();
            this.btn_QLHocSinh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_BCM = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_DSHS = new System.Windows.Forms.Button();
            this.btn_DsLop = new System.Windows.Forms.Button();
            this.btn_DSMH = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(221, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phần Mềm Quản Lý Sinh Viên";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_TDQD);
            this.panel1.Controls.Add(this.btn_QLTaiKhoan);
            this.panel1.Controls.Add(this.btn_QLMH);
            this.panel1.Controls.Add(this.btn_QLDiem);
            this.panel1.Controls.Add(this.btn_QLLop);
            this.panel1.Controls.Add(this.btn_BCMon);
            this.panel1.Controls.Add(this.btn_QLHocSinh);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 674);
            this.panel1.TabIndex = 2;
            // 
            // btn_TDQD
            // 
            this.btn_TDQD.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_TDQD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TDQD.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TDQD.ForeColor = System.Drawing.Color.White;
            this.btn_TDQD.Location = new System.Drawing.Point(11, 480);
            this.btn_TDQD.Name = "btn_TDQD";
            this.btn_TDQD.Size = new System.Drawing.Size(206, 57);
            this.btn_TDQD.TabIndex = 0;
            this.btn_TDQD.Text = "Thay Đổi Quy Định";
            this.btn_TDQD.UseVisualStyleBackColor = false;
            this.btn_TDQD.Click += new System.EventHandler(this.btn_TDQD_Click);
            // 
            // btn_QLTaiKhoan
            // 
            this.btn_QLTaiKhoan.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_QLTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QLTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btn_QLTaiKhoan.Location = new System.Drawing.Point(12, 56);
            this.btn_QLTaiKhoan.Name = "btn_QLTaiKhoan";
            this.btn_QLTaiKhoan.Size = new System.Drawing.Size(206, 50);
            this.btn_QLTaiKhoan.TabIndex = 0;
            this.btn_QLTaiKhoan.Text = "Quản Lý Tài Khoản";
            this.btn_QLTaiKhoan.UseVisualStyleBackColor = false;
            this.btn_QLTaiKhoan.Click += new System.EventHandler(this.btn_QLTaiKhoan_Click);
            // 
            // btn_QLMH
            // 
            this.btn_QLMH.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_QLMH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QLMH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLMH.ForeColor = System.Drawing.Color.White;
            this.btn_QLMH.Location = new System.Drawing.Point(12, 122);
            this.btn_QLMH.Name = "btn_QLMH";
            this.btn_QLMH.Size = new System.Drawing.Size(206, 50);
            this.btn_QLMH.TabIndex = 0;
            this.btn_QLMH.Text = "Quản Lý Môn Học";
            this.btn_QLMH.UseVisualStyleBackColor = false;
            this.btn_QLMH.Click += new System.EventHandler(this.btn_QLMH_Click);
            // 
            // btn_QLDiem
            // 
            this.btn_QLDiem.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_QLDiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QLDiem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLDiem.ForeColor = System.Drawing.Color.White;
            this.btn_QLDiem.Location = new System.Drawing.Point(12, 327);
            this.btn_QLDiem.Name = "btn_QLDiem";
            this.btn_QLDiem.Size = new System.Drawing.Size(206, 50);
            this.btn_QLDiem.TabIndex = 0;
            this.btn_QLDiem.Text = "Quản Lý Điểm";
            this.btn_QLDiem.UseVisualStyleBackColor = false;
            this.btn_QLDiem.Click += new System.EventHandler(this.btn_QLDiem_Click);
            // 
            // btn_QLLop
            // 
            this.btn_QLLop.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_QLLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QLLop.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLLop.ForeColor = System.Drawing.Color.White;
            this.btn_QLLop.Location = new System.Drawing.Point(12, 191);
            this.btn_QLLop.Name = "btn_QLLop";
            this.btn_QLLop.Size = new System.Drawing.Size(206, 50);
            this.btn_QLLop.TabIndex = 0;
            this.btn_QLLop.Text = "Quản Lý Lớp Học";
            this.btn_QLLop.UseVisualStyleBackColor = false;
            this.btn_QLLop.Click += new System.EventHandler(this.btn_QLLop_Click);
            // 
            // btn_BCMon
            // 
            this.btn_BCMon.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_BCMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BCMon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BCMon.ForeColor = System.Drawing.Color.White;
            this.btn_BCMon.Location = new System.Drawing.Point(12, 397);
            this.btn_BCMon.Name = "btn_BCMon";
            this.btn_BCMon.Size = new System.Drawing.Size(206, 57);
            this.btn_BCMon.TabIndex = 0;
            this.btn_BCMon.Text = "Lập Báo Cáo Tổng Kết Môn";
            this.btn_BCMon.UseVisualStyleBackColor = false;
            this.btn_BCMon.Click += new System.EventHandler(this.btn_BCMon_Click);
            // 
            // btn_QLHocSinh
            // 
            this.btn_QLHocSinh.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_QLHocSinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QLHocSinh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLHocSinh.ForeColor = System.Drawing.Color.White;
            this.btn_QLHocSinh.Location = new System.Drawing.Point(12, 259);
            this.btn_QLHocSinh.Name = "btn_QLHocSinh";
            this.btn_QLHocSinh.Size = new System.Drawing.Size(206, 50);
            this.btn_QLHocSinh.TabIndex = 0;
            this.btn_QLHocSinh.Text = "Quản Lý Sinh Viên";
            this.btn_QLHocSinh.UseVisualStyleBackColor = false;
            this.btn_QLHocSinh.Click += new System.EventHandler(this.btn_QLHocSinh_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btn_BCM);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.btn_DSHS);
            this.panel3.Controls.Add(this.btn_DsLop);
            this.panel3.Controls.Add(this.btn_DSMH);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(276, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(701, 501);
            this.panel3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(17, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btn_BCM
            // 
            this.btn_BCM.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_BCM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BCM.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BCM.ForeColor = System.Drawing.Color.White;
            this.btn_BCM.Location = new System.Drawing.Point(501, 444);
            this.btn_BCM.Name = "btn_BCM";
            this.btn_BCM.Size = new System.Drawing.Size(111, 36);
            this.btn_BCM.TabIndex = 5;
            this.btn_BCM.Text = "Báo Cáo Môn";
            this.btn_BCM.UseVisualStyleBackColor = false;
            this.btn_BCM.Click += new System.EventHandler(this.btn_BCM_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(663, 361);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_DSHS
            // 
            this.btn_DSHS.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_DSHS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DSHS.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSHS.ForeColor = System.Drawing.Color.White;
            this.btn_DSHS.Location = new System.Drawing.Point(369, 444);
            this.btn_DSHS.Name = "btn_DSHS";
            this.btn_DSHS.Size = new System.Drawing.Size(111, 36);
            this.btn_DSHS.TabIndex = 5;
            this.btn_DSHS.Text = "DS Sinh Viên";
            this.btn_DSHS.UseVisualStyleBackColor = false;
            this.btn_DSHS.Click += new System.EventHandler(this.btn_DSHS_Click);
            // 
            // btn_DsLop
            // 
            this.btn_DsLop.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_DsLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DsLop.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DsLop.ForeColor = System.Drawing.Color.White;
            this.btn_DsLop.Location = new System.Drawing.Point(109, 444);
            this.btn_DsLop.Name = "btn_DsLop";
            this.btn_DsLop.Size = new System.Drawing.Size(111, 36);
            this.btn_DsLop.TabIndex = 5;
            this.btn_DsLop.Text = "DS Lớp";
            this.btn_DsLop.UseVisualStyleBackColor = false;
            this.btn_DsLop.Click += new System.EventHandler(this.btn_DsLop_Click);
            // 
            // btn_DSMH
            // 
            this.btn_DSMH.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_DSMH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DSMH.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DSMH.ForeColor = System.Drawing.Color.White;
            this.btn_DSMH.Location = new System.Drawing.Point(240, 444);
            this.btn_DSMH.Name = "btn_DSMH";
            this.btn_DSMH.Size = new System.Drawing.Size(111, 36);
            this.btn_DSMH.TabIndex = 5;
            this.btn_DSMH.Text = "DS Môn Học";
            this.btn_DSMH.UseVisualStyleBackColor = false;
            this.btn_DSMH.Click += new System.EventHandler(this.btn_DSMH_Click);
            // 
            // FormTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(998, 606);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormTrangChu";
            this.Text = "Quản Lý Sinh Viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTrangChu_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_QLMH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_QLLop;
        private System.Windows.Forms.Button btn_BCMon;
        private System.Windows.Forms.Button btn_QLHocSinh;
        private System.Windows.Forms.Button btn_TDQD;
        private System.Windows.Forms.Button btn_QLDiem;
        private System.Windows.Forms.Button btn_QLTaiKhoan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_DsLop;
        private System.Windows.Forms.Button btn_DSMH;
        private System.Windows.Forms.Button btn_DSHS;
        private System.Windows.Forms.Button btn_BCM;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}