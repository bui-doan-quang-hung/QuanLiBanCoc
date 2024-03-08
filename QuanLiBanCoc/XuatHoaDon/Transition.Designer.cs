namespace QuanLiBanCoc
{
    partial class Transition
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
            this.btnHDB = new System.Windows.Forms.Button();
            this.btnHDN = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHDB
            // 
            this.btnHDB.BackColor = System.Drawing.Color.Black;
            this.btnHDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHDB.FlatAppearance.BorderSize = 0;
            this.btnHDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHDB.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDB.ForeColor = System.Drawing.Color.White;
            this.btnHDB.Location = new System.Drawing.Point(12, 33);
            this.btnHDB.Name = "btnHDB";
            this.btnHDB.Size = new System.Drawing.Size(136, 52);
            this.btnHDB.TabIndex = 4;
            this.btnHDB.Text = "Hóa đơn bán";
            this.btnHDB.UseVisualStyleBackColor = false;
            this.btnHDB.Click += new System.EventHandler(this.btnHDB_Click);
            // 
            // btnHDN
            // 
            this.btnHDN.BackColor = System.Drawing.Color.Black;
            this.btnHDN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHDN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHDN.FlatAppearance.BorderSize = 0;
            this.btnHDN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHDN.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDN.ForeColor = System.Drawing.Color.White;
            this.btnHDN.Location = new System.Drawing.Point(196, 33);
            this.btnHDN.Name = "btnHDN";
            this.btnHDN.Size = new System.Drawing.Size(146, 52);
            this.btnHDN.TabIndex = 5;
            this.btnHDN.Text = "Hóa đơn nhập";
            this.btnHDN.UseVisualStyleBackColor = false;
            this.btnHDN.Click += new System.EventHandler(this.btnHDN_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("SVN-Radiant Slender", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(125, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 52);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Transition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(354, 193);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHDN);
            this.Controls.Add(this.btnHDB);
            this.Name = "Transition";
            this.Text = "Transition";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHDB;
        private System.Windows.Forms.Button btnHDN;
        private System.Windows.Forms.Button btnCancel;
    }
}