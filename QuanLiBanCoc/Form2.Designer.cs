using System.Drawing;
using System.Windows.Forms;

namespace QuanLiBanCoc
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonQLSP = new System.Windows.Forms.Button();
            this.buttonThanhToan = new System.Windows.Forms.Button();
            this.buttonHoaDon = new System.Windows.Forms.Button();
            this.buttonQLNV = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SVN-Radiant Slender", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.Location = new System.Drawing.Point(324, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome back,";
            // 
            // buttonQLSP
            // 
            this.buttonQLSP.BackColor = System.Drawing.Color.Black;
            this.buttonQLSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonQLSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQLSP.FlatAppearance.BorderSize = 0;
            this.buttonQLSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQLSP.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQLSP.ForeColor = System.Drawing.Color.White;
            this.buttonQLSP.Location = new System.Drawing.Point(95, 74);
            this.buttonQLSP.Name = "buttonQLSP";
            this.buttonQLSP.Size = new System.Drawing.Size(183, 52);
            this.buttonQLSP.TabIndex = 1;
            this.buttonQLSP.Text = "Quản lí sản phẩm";
            this.buttonQLSP.UseVisualStyleBackColor = false;
            this.buttonQLSP.Click += new System.EventHandler(this.buttonQLSP_Click);
            // 
            // buttonThanhToan
            // 
            this.buttonThanhToan.BackColor = System.Drawing.Color.Black;
            this.buttonThanhToan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThanhToan.FlatAppearance.BorderSize = 0;
            this.buttonThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThanhToan.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThanhToan.ForeColor = System.Drawing.Color.White;
            this.buttonThanhToan.Location = new System.Drawing.Point(95, 187);
            this.buttonThanhToan.Name = "buttonThanhToan";
            this.buttonThanhToan.Size = new System.Drawing.Size(183, 52);
            this.buttonThanhToan.TabIndex = 2;
            this.buttonThanhToan.Text = "Bán hàng";
            this.buttonThanhToan.UseVisualStyleBackColor = false;
            this.buttonThanhToan.Click += new System.EventHandler(this.buttonThanhToan_Click);
            // 
            // buttonHoaDon
            // 
            this.buttonHoaDon.BackColor = System.Drawing.Color.Black;
            this.buttonHoaDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHoaDon.FlatAppearance.BorderSize = 0;
            this.buttonHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHoaDon.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHoaDon.ForeColor = System.Drawing.Color.White;
            this.buttonHoaDon.Location = new System.Drawing.Point(647, 74);
            this.buttonHoaDon.Name = "buttonHoaDon";
            this.buttonHoaDon.Size = new System.Drawing.Size(183, 52);
            this.buttonHoaDon.TabIndex = 3;
            this.buttonHoaDon.Text = "Kiểm tra hóa đơn";
            this.buttonHoaDon.UseVisualStyleBackColor = false;
            this.buttonHoaDon.Click += new System.EventHandler(this.buttonHoaDon_Click);
            // 
            // buttonQLNV
            // 
            this.buttonQLNV.BackColor = System.Drawing.Color.Black;
            this.buttonQLNV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonQLNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQLNV.FlatAppearance.BorderSize = 0;
            this.buttonQLNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQLNV.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQLNV.ForeColor = System.Drawing.Color.White;
            this.buttonQLNV.Location = new System.Drawing.Point(371, 74);
            this.buttonQLNV.Name = "buttonQLNV";
            this.buttonQLNV.Size = new System.Drawing.Size(183, 52);
            this.buttonQLNV.TabIndex = 4;
            this.buttonQLNV.Text = "Quản lí nhân sự";
            this.buttonQLNV.UseVisualStyleBackColor = false;
            this.buttonQLNV.Click += new System.EventHandler(this.buttonQLNV_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogOut.FlatAppearance.BorderSize = 0;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonLogOut.ForeColor = System.Drawing.Color.Black;
            this.buttonLogOut.Location = new System.Drawing.Point(21, 12);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(148, 37);
            this.buttonLogOut.TabIndex = 5;
            this.buttonLogOut.Text = "<     Đăng xuất";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("SVN-Radiant Slender", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(647, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "Thông tin khách hàng";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(371, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "Nhập hàng";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(922, 544);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonQLNV);
            this.Controls.Add(this.buttonHoaDon);
            this.Controls.Add(this.buttonThanhToan);
            this.Controls.Add(this.buttonQLSP);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonQLSP;
        private System.Windows.Forms.Button buttonThanhToan;
        private System.Windows.Forms.Button buttonHoaDon;
        private System.Windows.Forms.Button buttonQLNV;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}