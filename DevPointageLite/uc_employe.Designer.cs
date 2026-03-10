namespace DevPointageLite
{
    partial class uc_employe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_employe));
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.bt_ajouter = new DevExpress.XtraEditors.SimpleButton();
            this.bt_modifier = new DevExpress.XtraEditors.SimpleButton();
            this.bt_exportexcel = new DevExpress.XtraEditors.SimpleButton();
            this.bt_exportpdf = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.bt_ajouter);
            this.panel1.Controls.Add(this.bt_modifier);
            this.panel1.Controls.Add(this.bt_exportexcel);
            this.panel1.Controls.Add(this.bt_exportpdf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 636);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1325, 156);
            this.panel1.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(577, 37);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(173, 75);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "&Vers Historique";
            // 
            // bt_ajouter
            // 
            this.bt_ajouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_ajouter.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ajouter.Appearance.Options.UseFont = true;
            this.bt_ajouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_ajouter.ImageOptions.Image")));
            this.bt_ajouter.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.bt_ajouter.Location = new System.Drawing.Point(215, 37);
            this.bt_ajouter.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ajouter.Name = "bt_ajouter";
            this.bt_ajouter.Size = new System.Drawing.Size(173, 75);
            this.bt_ajouter.TabIndex = 6;
            this.bt_ajouter.Text = "&Ajouter";
            this.bt_ajouter.Click += new System.EventHandler(this.bt_ajouter_Click);
            // 
            // bt_modifier
            // 
            this.bt_modifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_modifier.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_modifier.Appearance.Options.UseFont = true;
            this.bt_modifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_modifier.ImageOptions.Image")));
            this.bt_modifier.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.bt_modifier.Location = new System.Drawing.Point(395, 37);
            this.bt_modifier.Margin = new System.Windows.Forms.Padding(4);
            this.bt_modifier.Name = "bt_modifier";
            this.bt_modifier.Size = new System.Drawing.Size(173, 75);
            this.bt_modifier.TabIndex = 5;
            this.bt_modifier.Text = "&Modifier";
            this.bt_modifier.Click += new System.EventHandler(this.bt_modifier_Click);
            // 
            // bt_exportexcel
            // 
            this.bt_exportexcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_exportexcel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_exportexcel.Appearance.Options.UseFont = true;
            this.bt_exportexcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_exportexcel.ImageOptions.Image")));
            this.bt_exportexcel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.bt_exportexcel.Location = new System.Drawing.Point(758, 37);
            this.bt_exportexcel.Margin = new System.Windows.Forms.Padding(4);
            this.bt_exportexcel.Name = "bt_exportexcel";
            this.bt_exportexcel.Size = new System.Drawing.Size(173, 75);
            this.bt_exportexcel.TabIndex = 4;
            this.bt_exportexcel.Text = "&Export Excel";
            this.bt_exportexcel.Click += new System.EventHandler(this.bt_exportexcel_Click);
            // 
            // bt_exportpdf
            // 
            this.bt_exportpdf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_exportpdf.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_exportpdf.Appearance.Options.UseFont = true;
            this.bt_exportpdf.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_exportpdf.ImageOptions.Image")));
            this.bt_exportpdf.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.bt_exportpdf.Location = new System.Drawing.Point(936, 37);
            this.bt_exportpdf.Margin = new System.Windows.Forms.Padding(4);
            this.bt_exportpdf.Name = "bt_exportpdf";
            this.bt_exportpdf.Size = new System.Drawing.Size(173, 75);
            this.bt_exportpdf.TabIndex = 3;
            this.bt_exportpdf.Text = "&Export PDF";
            this.bt_exportpdf.Click += new System.EventHandler(this.bt_exportpdf_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1325, 636);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // uc_employe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "uc_employe";
            this.Size = new System.Drawing.Size(1325, 792);
            this.Load += new System.EventHandler(this.uc_employe_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton bt_ajouter;
        private DevExpress.XtraEditors.SimpleButton bt_modifier;
        private DevExpress.XtraEditors.SimpleButton bt_exportexcel;
        private DevExpress.XtraEditors.SimpleButton bt_exportpdf;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
