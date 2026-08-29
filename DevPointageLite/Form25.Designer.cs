namespace DevPointageLite
{
    partial class Form25
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form25));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdatabase = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btbackup = new System.Windows.Forms.Button();
            this.btbrowser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btbackup);
            this.groupBox1.Controls.Add(this.btbrowser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtdatabase);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 186);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(747, 245);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات حول قاعدة البيانات";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "اختر المجلد الذي ستحفظ فيه نسخة القاعدة:";
            // 
            // txtdatabase
            // 
            this.txtdatabase.Location = new System.Drawing.Point(224, 106);
            this.txtdatabase.Margin = new System.Windows.Forms.Padding(4);
            this.txtdatabase.Name = "txtdatabase";
            this.txtdatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtdatabase.Size = new System.Drawing.Size(492, 38);
            this.txtdatabase.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::DevPointageLite.Properties.Resources.sync;
            this.pictureBox1.Location = new System.Drawing.Point(322, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btbackup
            // 
            this.btbackup.BackColor = System.Drawing.Color.MintCream;
            this.btbackup.Enabled = false;
            this.btbackup.FlatAppearance.BorderSize = 0;
            this.btbackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btbackup.ForeColor = System.Drawing.Color.Teal;
            this.btbackup.Image = ((System.Drawing.Image)(resources.GetObject("btbackup.Image")));
            this.btbackup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btbackup.Location = new System.Drawing.Point(273, 166);
            this.btbackup.Margin = new System.Windows.Forms.Padding(4);
            this.btbackup.Name = "btbackup";
            this.btbackup.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.btbackup.Size = new System.Drawing.Size(213, 59);
            this.btbackup.TabIndex = 10;
            this.btbackup.Text = "حفظ القاعدة";
            this.btbackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btbackup.UseVisualStyleBackColor = false;
            this.btbackup.Click += new System.EventHandler(this.btbackup_Click);
            // 
            // btbrowser
            // 
            this.btbrowser.BackColor = System.Drawing.Color.PapayaWhip;
            this.btbrowser.FlatAppearance.BorderSize = 0;
            this.btbrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btbrowser.ForeColor = System.Drawing.Color.Maroon;
            this.btbrowser.Image = ((System.Drawing.Image)(resources.GetObject("btbrowser.Image")));
            this.btbrowser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btbrowser.Location = new System.Drawing.Point(33, 100);
            this.btbrowser.Margin = new System.Windows.Forms.Padding(4);
            this.btbrowser.Name = "btbrowser";
            this.btbrowser.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.btbrowser.Size = new System.Drawing.Size(160, 49);
            this.btbrowser.TabIndex = 13;
            this.btbrowser.Text = "تصفح";
            this.btbrowser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btbrowser.UseVisualStyleBackColor = false;
            this.btbrowser.Click += new System.EventHandler(this.btbrowser_Click);
            // 
            // Form25
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 449);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form25";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حفظ قاعدة البيانات ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btbackup;
        private System.Windows.Forms.Button btbrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdatabase;
    }
}