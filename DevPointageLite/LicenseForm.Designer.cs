namespace DevPointageLite
{
    partial class LicenseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseForm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(71, 25);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(448, 31);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "قم بكتابة الكود الذي تم إرساله عبر البريد الخاص بك";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(81, 63);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(429, 53);
            this.txtKey.TabIndex = 1;
            // 
            // btnValidate
            // 
            this.btnValidate.BackColor = System.Drawing.Color.LightCoral;
            this.btnValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidate.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.ForeColor = System.Drawing.Color.White;
            this.btnValidate.Image = ((System.Drawing.Image)(resources.GetObject("btnValidate.Image")));
            this.btnValidate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValidate.Location = new System.Drawing.Point(179, 131);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnValidate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnValidate.Size = new System.Drawing.Size(232, 53);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "تفعيل البرنامج";
            this.btnValidate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 234);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.txtKey);
            this.Name = "LicenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تفعيل البرنامج";
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.TextBox txtKey;
    }
}