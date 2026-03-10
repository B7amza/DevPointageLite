namespace DevPointageLite
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableau = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel_button = new System.Windows.Forms.Panel();
            this.bt_ajouter = new DevExpress.XtraEditors.SimpleButton();
            this.bt_telechargerAttlog = new DevExpress.XtraEditors.SimpleButton();
            this.bt_telechargerD = new DevExpress.XtraEditors.SimpleButton();
            this.bt_fermer = new DevExpress.XtraEditors.SimpleButton();
            this.btnSupprimerLogs = new DevExpress.XtraEditors.SimpleButton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableau)).BeginInit();
            this.panel_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 342);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(655, 513);
            this.panel3.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(655, 455);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.progressBar1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 455);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(655, 58);
            this.panel5.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(646, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableau);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 342);
            this.panel2.TabIndex = 4;
            // 
            // tableau
            // 
            this.tableau.AllowUserToAddRows = false;
            this.tableau.AllowUserToDeleteRows = false;
            this.tableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.tableau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableau.Location = new System.Drawing.Point(0, 0);
            this.tableau.Name = "tableau";
            this.tableau.RowHeadersWidth = 10;
            this.tableau.RowTemplate.Height = 24;
            this.tableau.Size = new System.Drawing.Size(655, 284);
            this.tableau.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "N";
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "O";
            this.Column1.Width = 25;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 284);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(655, 58);
            this.panel4.TabIndex = 0;
            // 
            // panel_button
            // 
            this.panel_button.Controls.Add(this.btnSupprimerLogs);
            this.panel_button.Controls.Add(this.bt_ajouter);
            this.panel_button.Controls.Add(this.bt_telechargerAttlog);
            this.panel_button.Controls.Add(this.bt_telechargerD);
            this.panel_button.Controls.Add(this.bt_fermer);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_button.Location = new System.Drawing.Point(655, 0);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(123, 855);
            this.panel_button.TabIndex = 3;
            // 
            // bt_ajouter
            // 
            this.bt_ajouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_ajouter.ImageOptions.Image")));
            this.bt_ajouter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_ajouter.Location = new System.Drawing.Point(30, 101);
            this.bt_ajouter.Name = "bt_ajouter";
            this.bt_ajouter.Size = new System.Drawing.Size(62, 62);
            this.bt_ajouter.TabIndex = 3;
            this.bt_ajouter.Text = "Fermer\r\n";
            this.bt_ajouter.Click += new System.EventHandler(this.bt_ajouter_Click);
            this.bt_ajouter.MouseHover += new System.EventHandler(this.bt_ajouter_MouseHover);
            // 
            // bt_telechargerAttlog
            // 
            this.bt_telechargerAttlog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_telechargerAttlog.ImageOptions.Image")));
            this.bt_telechargerAttlog.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_telechargerAttlog.Location = new System.Drawing.Point(30, 279);
            this.bt_telechargerAttlog.Name = "bt_telechargerAttlog";
            this.bt_telechargerAttlog.Size = new System.Drawing.Size(62, 62);
            this.bt_telechargerAttlog.TabIndex = 2;
            this.bt_telechargerAttlog.Click += new System.EventHandler(this.bt_telechargerAttlog_Click);
            this.bt_telechargerAttlog.MouseHover += new System.EventHandler(this.bt_telechargerAttlog_MouseHover);
            // 
            // bt_telechargerD
            // 
            this.bt_telechargerD.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_telechargerD.ImageOptions.Image")));
            this.bt_telechargerD.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_telechargerD.Location = new System.Drawing.Point(30, 12);
            this.bt_telechargerD.Name = "bt_telechargerD";
            this.bt_telechargerD.Size = new System.Drawing.Size(62, 62);
            this.bt_telechargerD.TabIndex = 1;
            this.bt_telechargerD.Text = "Fermer\r\n";
            this.bt_telechargerD.Click += new System.EventHandler(this.bt_telechargerD_Click);
            this.bt_telechargerD.MouseHover += new System.EventHandler(this.bt_telechargerD_MouseHover);
            // 
            // bt_fermer
            // 
            this.bt_fermer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_fermer.ImageOptions.Image")));
            this.bt_fermer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_fermer.Location = new System.Drawing.Point(28, 720);
            this.bt_fermer.Name = "bt_fermer";
            this.bt_fermer.Size = new System.Drawing.Size(62, 64);
            this.bt_fermer.TabIndex = 0;
            this.bt_fermer.Text = "Fermer\r\n";
            this.bt_fermer.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnSupprimerLogs
            // 
            this.btnSupprimerLogs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSupprimerLogs.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerLogs.Appearance.Options.UseFont = true;
            this.btnSupprimerLogs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSupprimerLogs.ImageOptions.Image")));
            this.btnSupprimerLogs.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnSupprimerLogs.Location = new System.Drawing.Point(30, 190);
            this.btnSupprimerLogs.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimerLogs.Name = "btnSupprimerLogs";
            this.btnSupprimerLogs.Size = new System.Drawing.Size(62, 62);
            this.btnSupprimerLogs.TabIndex = 12;
            this.btnSupprimerLogs.Click += new System.EventHandler(this.btnSupprimerLogs_Click);
            this.btnSupprimerLogs.MouseHover += new System.EventHandler(this.btnSupprimerLogs_MouseHover);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 855);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_button);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telechargement ...";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableau)).EndInit();
            this.panel_button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tableau;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel_button;
        private DevExpress.XtraEditors.SimpleButton bt_telechargerAttlog;
        private DevExpress.XtraEditors.SimpleButton bt_telechargerD;
        private DevExpress.XtraEditors.SimpleButton bt_fermer;
        private DevExpress.XtraEditors.SimpleButton bt_ajouter;
        private DevExpress.XtraEditors.SimpleButton btnSupprimerLogs;
    }
}