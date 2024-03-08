namespace QuanLiBanCoc.NhanVien
{
    partial class FormTimKiemNV
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnFind = new System.Windows.Forms.Button();
			this.txt2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt1 = new System.Windows.Forms.TextBox();
			this.labelID = new System.Windows.Forms.Label();
			this.txt3 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.Black;
			this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancel.FlatAppearance.BorderSize = 0;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.btnCancel.ForeColor = System.Drawing.Color.White;
			this.btnCancel.Location = new System.Drawing.Point(219, 191);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(111, 40);
			this.btnCancel.TabIndex = 26;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnFind
			// 
			this.btnFind.BackColor = System.Drawing.Color.Black;
			this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFind.FlatAppearance.BorderSize = 0;
			this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFind.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.btnFind.ForeColor = System.Drawing.Color.White;
			this.btnFind.Location = new System.Drawing.Point(38, 191);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(111, 40);
			this.btnFind.TabIndex = 25;
			this.btnFind.Text = "Tìm Kiếm";
			this.btnFind.UseVisualStyleBackColor = false;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// txt2
			// 
			this.txt2.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt2.Location = new System.Drawing.Point(173, 77);
			this.txt2.Name = "txt2";
			this.txt2.Size = new System.Drawing.Size(157, 34);
			this.txt2.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(33, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 26);
			this.label1.TabIndex = 23;
			this.label1.Text = "Chức vụ";
			// 
			// txt1
			// 
			this.txt1.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt1.Location = new System.Drawing.Point(173, 22);
			this.txt1.Name = "txt1";
			this.txt1.Size = new System.Drawing.Size(157, 34);
			this.txt1.TabIndex = 22;
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelID.Location = new System.Drawing.Point(33, 25);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(64, 26);
			this.labelID.TabIndex = 21;
			this.labelID.Text = "Mã NV";
			// 
			// txt3
			// 
			this.txt3.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt3.Location = new System.Drawing.Point(173, 133);
			this.txt3.Name = "txt3";
			this.txt3.Size = new System.Drawing.Size(157, 34);
			this.txt3.TabIndex = 28;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(33, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 26);
			this.label2.TabIndex = 27;
			this.label2.Text = "Tên NV";
			// 
			// FormTimKiemNV
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(363, 252);
			this.Controls.Add(this.txt3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnFind);
			this.Controls.Add(this.txt2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt1);
			this.Controls.Add(this.labelID);
			this.Name = "FormTimKiemNV";
			this.Text = "FormTimKiemNV";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label labelID;
		private System.Windows.Forms.TextBox txt3;
		private System.Windows.Forms.Label label2;
	}
}