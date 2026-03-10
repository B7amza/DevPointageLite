namespace DevPointageLite
{
    partial class uc_typeconge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_typeconge));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_details = new DevExpress.XtraEditors.SimpleButton();
            this.bt_imprimer = new DevExpress.XtraEditors.SimpleButton();
            this.bt_validee = new DevExpress.XtraEditors.SimpleButton();
            this.bt_modifier = new DevExpress.XtraEditors.SimpleButton();
            this.bt_supprimer = new DevExpress.XtraEditors.SimpleButton();
            this.bt_ajouter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1224, 531);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_details);
            this.panel1.Controls.Add(this.bt_imprimer);
            this.panel1.Controls.Add(this.bt_validee);
            this.panel1.Controls.Add(this.bt_modifier);
            this.panel1.Controls.Add(this.bt_supprimer);
            this.panel1.Controls.Add(this.bt_ajouter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 136);
            this.panel1.TabIndex = 6;
            // 
            // bt_details
            // 
            this.bt_details.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_details.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_details.Appearance.Options.UseFont = true;
            this.bt_details.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_details.ImageOptions.Image")));
            this.bt_details.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_details.Location = new System.Drawing.Point(908, 20);
            this.bt_details.Name = "bt_details";
            this.bt_details.Size = new System.Drawing.Size(271, 83);
            this.bt_details.TabIndex = 11;
            this.bt_details.Text = "Details ";
            // 
            // bt_imprimer
            // 
            this.bt_imprimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_imprimer.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_imprimer.Appearance.Options.UseFont = true;
            this.bt_imprimer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_imprimer.ImageOptions.Image")));
            this.bt_imprimer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_imprimer.Location = new System.Drawing.Point(687, 20);
            this.bt_imprimer.Name = "bt_imprimer";
            this.bt_imprimer.Size = new System.Drawing.Size(148, 83);
            this.bt_imprimer.TabIndex = 10;
            this.bt_imprimer.Text = "Imprimer";
            // 
            // bt_validee
            // 
            this.bt_validee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_validee.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_validee.Appearance.Options.UseFont = true;
            this.bt_validee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_validee.ImageOptions.Image")));
            this.bt_validee.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_validee.Location = new System.Drawing.Point(379, 20);
            this.bt_validee.Name = "bt_validee";
            this.bt_validee.Size = new System.Drawing.Size(148, 83);
            this.bt_validee.TabIndex = 9;
            this.bt_validee.Text = "Validee";
            // 
            // bt_modifier
            // 
            this.bt_modifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_modifier.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_modifier.Appearance.Options.UseFont = true;
            this.bt_modifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_modifier.ImageOptions.Image")));
            this.bt_modifier.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_modifier.Location = new System.Drawing.Point(225, 20);
            this.bt_modifier.Name = "bt_modifier";
            this.bt_modifier.Size = new System.Drawing.Size(148, 83);
            this.bt_modifier.TabIndex = 8;
            this.bt_modifier.Text = "Modifier";
            this.bt_modifier.Click += new System.EventHandler(this.bt_modifier_Click);
            // 
            // bt_supprimer
            // 
            this.bt_supprimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_supprimer.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_supprimer.Appearance.Options.UseFont = true;
            this.bt_supprimer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_supprimer.ImageOptions.Image")));
            this.bt_supprimer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_supprimer.Location = new System.Drawing.Point(533, 20);
            this.bt_supprimer.Name = "bt_supprimer";
            this.bt_supprimer.Size = new System.Drawing.Size(148, 83);
            this.bt_supprimer.TabIndex = 7;
            this.bt_supprimer.Text = "Supprimer";
            // 
            // bt_ajouter
            // 
            this.bt_ajouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_ajouter.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ajouter.Appearance.Options.UseFont = true;
            this.bt_ajouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_ajouter.ImageOptions.Image")));
            this.bt_ajouter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_ajouter.Location = new System.Drawing.Point(71, 20);
            this.bt_ajouter.Name = "bt_ajouter";
            this.bt_ajouter.Size = new System.Drawing.Size(148, 83);
            this.bt_ajouter.TabIndex = 6;
            this.bt_ajouter.Text = "Ajouter";
            this.bt_ajouter.Click += new System.EventHandler(this.bt_ajouter_Click);
            // 
            // uc_typeconge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "uc_typeconge";
            this.Size = new System.Drawing.Size(1224, 667);
            this.Load += new System.EventHandler(this.uc_typeconge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton bt_details;
        private DevExpress.XtraEditors.SimpleButton bt_imprimer;
        private DevExpress.XtraEditors.SimpleButton bt_validee;
        private DevExpress.XtraEditors.SimpleButton bt_modifier;
        private DevExpress.XtraEditors.SimpleButton bt_supprimer;
        private DevExpress.XtraEditors.SimpleButton bt_ajouter;
    }
}
