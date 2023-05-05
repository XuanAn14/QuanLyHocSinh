namespace WindowsFormsApp1.View
{
    partial class FormQuanLyLop
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
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.textB_MaLop = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textB_TenLop = new System.Windows.Forms.TextBox();
            this.textB_KhoiLop = new System.Windows.Forms.TextBox();
            this.btn_dshs = new System.Windows.Forms.Button();
            this.btn_dslop = new System.Windows.Forms.Button();
            this.textB_timkiem = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Location = new System.Drawing.Point(391, 186);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(143, 37);
            this.btn_Xoa.TabIndex = 16;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Sua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Location = new System.Drawing.Point(211, 186);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(143, 37);
            this.btn_Sua.TabIndex = 17;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Them.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Location = new System.Drawing.Point(33, 186);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(143, 37);
            this.btn_Them.TabIndex = 18;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // textB_MaLop
            // 
            this.textB_MaLop.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textB_MaLop.Location = new System.Drawing.Point(177, 88);
            this.textB_MaLop.Name = "textB_MaLop";
            this.textB_MaLop.Size = new System.Drawing.Size(217, 26);
            this.textB_MaLop.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(233, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Quản Lý Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Khối Lớp: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tên Lớp: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mã Lớp: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 291);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(571, 195);
            this.dataGridView1.TabIndex = 19;
            // 
            // textB_TenLop
            // 
            this.textB_TenLop.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textB_TenLop.Location = new System.Drawing.Point(326, 131);
            this.textB_TenLop.Name = "textB_TenLop";
            this.textB_TenLop.Size = new System.Drawing.Size(68, 26);
            this.textB_TenLop.TabIndex = 15;
            // 
            // textB_KhoiLop
            // 
            this.textB_KhoiLop.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textB_KhoiLop.Location = new System.Drawing.Point(175, 131);
            this.textB_KhoiLop.Name = "textB_KhoiLop";
            this.textB_KhoiLop.Size = new System.Drawing.Size(53, 26);
            this.textB_KhoiLop.TabIndex = 15;
            // 
            // btn_dshs
            // 
            this.btn_dshs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dshs.Location = new System.Drawing.Point(161, 242);
            this.btn_dshs.Name = "btn_dshs";
            this.btn_dshs.Size = new System.Drawing.Size(107, 37);
            this.btn_dshs.TabIndex = 23;
            this.btn_dshs.Text = "DS Học Sinh Trong Lớp";
            this.btn_dshs.UseVisualStyleBackColor = true;
            this.btn_dshs.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_dslop
            // 
            this.btn_dslop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dslop.Location = new System.Drawing.Point(33, 242);
            this.btn_dslop.Name = "btn_dslop";
            this.btn_dslop.Size = new System.Drawing.Size(107, 37);
            this.btn_dslop.TabIndex = 24;
            this.btn_dslop.Text = "DS Lớp";
            this.btn_dslop.UseVisualStyleBackColor = true;
            this.btn_dslop.Click += new System.EventHandler(this.btn_dslop_Click);
            // 
            // textB_timkiem
            // 
            this.textB_timkiem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textB_timkiem.Location = new System.Drawing.Point(391, 248);
            this.textB_timkiem.Name = "textB_timkiem";
            this.textB_timkiem.Size = new System.Drawing.Size(111, 29);
            this.textB_timkiem.TabIndex = 15;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_timkiem.Location = new System.Drawing.Point(520, 248);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(84, 29);
            this.btn_timkiem.TabIndex = 25;
            this.btn_timkiem.Text = "Tìm Kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // FormQuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 508);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.btn_dslop);
            this.Controls.Add(this.btn_dshs);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.textB_KhoiLop);
            this.Controls.Add(this.textB_timkiem);
            this.Controls.Add(this.textB_TenLop);
            this.Controls.Add(this.textB_MaLop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "FormQuanLyLop";
            this.Text = "Quản Lý Học Sinh";
            this.Load += new System.EventHandler(this.FormQuanLyLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.TextBox textB_MaLop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textB_TenLop;
        private System.Windows.Forms.TextBox textB_KhoiLop;
        private System.Windows.Forms.Button btn_dshs;
        private System.Windows.Forms.Button btn_dslop;
        private System.Windows.Forms.TextBox textB_timkiem;
        private System.Windows.Forms.Button btn_timkiem;
    }
}