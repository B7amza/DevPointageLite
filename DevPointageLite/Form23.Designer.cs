namespace DevPointageLite
{
    partial class Form23
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form23));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_nom_prenom = new System.Windows.Forms.TextBox();
            this.txt_matricule = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cb_horaire_travail = new System.Windows.Forms.ComboBox();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.dt_au = new System.Windows.Forms.DateTimePicker();
            this.dt_du = new System.Windows.Forms.DateTimePicker();
            this.bt_ajouter = new DevExpress.XtraEditors.SimpleButton();
            this.bt_modifier = new DevExpress.XtraEditors.SimpleButton();
            this.bt_enregistrer = new DevExpress.XtraEditors.SimpleButton();
            this.tableau_horaire = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableau_horaire)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 279);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableau_horaire);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 448);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bt_enregistrer);
            this.panel3.Controls.Add(this.bt_modifier);
            this.panel3.Controls.Add(this.bt_ajouter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(509, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(135, 279);
            this.panel3.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.dt_au);
            this.groupControl1.Controls.Add(this.dt_du);
            this.groupControl1.Controls.Add(this.cb_horaire_travail);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.txt_nom_prenom);
            this.groupControl1.Controls.Add(this.txt_matricule);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(13, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(474, 248);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Details Employee ...";
            // 
            // txt_nom_prenom
            // 
            this.txt_nom_prenom.Enabled = false;
            this.txt_nom_prenom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom_prenom.Location = new System.Drawing.Point(140, 86);
            this.txt_nom_prenom.Name = "txt_nom_prenom";
            this.txt_nom_prenom.Size = new System.Drawing.Size(323, 32);
            this.txt_nom_prenom.TabIndex = 5;
            // 
            // txt_matricule
            // 
            this.txt_matricule.Enabled = false;
            this.txt_matricule.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_matricule.Location = new System.Drawing.Point(140, 38);
            this.txt_matricule.Name = "txt_matricule";
            this.txt_matricule.Size = new System.Drawing.Size(126, 32);
            this.txt_matricule.TabIndex = 1;
            this.txt_matricule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_matricule_KeyDown);
            this.txt_matricule.Leave += new System.EventHandler(this.txt_matricule_Leave);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(3, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(134, 24);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Nom & Prenom :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(17, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 24);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Matricule :";
            // 
            // cb_horaire_travail
            // 
            this.cb_horaire_travail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_horaire_travail.Enabled = false;
            this.cb_horaire_travail.FormattingEnabled = true;
            this.cb_horaire_travail.Location = new System.Drawing.Point(203, 141);
            this.cb_horaire_travail.Name = "cb_horaire_travail";
            this.cb_horaire_travail.Size = new System.Drawing.Size(260, 24);
            this.cb_horaire_travail.TabIndex = 2;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(4, 141);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(175, 24);
            this.labelControl11.TabIndex = 12;
            this.labelControl11.Text = "Periode de Travail :";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(302, 205);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(36, 24);
            this.labelControl13.TabIndex = 29;
            this.labelControl13.Text = "Au :";
            this.labelControl13.Click += new System.EventHandler(this.labelControl13_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(16, 206);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(38, 24);
            this.labelControl12.TabIndex = 26;
            this.labelControl12.Text = "Du :";
            // 
            // dt_au
            // 
            this.dt_au.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_au.Location = new System.Drawing.Point(344, 206);
            this.dt_au.Name = "dt_au";
            this.dt_au.Size = new System.Drawing.Size(119, 23);
            this.dt_au.TabIndex = 4;
            this.dt_au.ValueChanged += new System.EventHandler(this.dt_au_ValueChanged);
            // 
            // dt_du
            // 
            this.dt_du.Enabled = false;
            this.dt_du.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_du.Location = new System.Drawing.Point(60, 207);
            this.dt_du.Name = "dt_du";
            this.dt_du.Size = new System.Drawing.Size(119, 23);
            this.dt_du.TabIndex = 3;
            // 
            // bt_ajouter
            // 
            this.bt_ajouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_ajouter.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ajouter.Appearance.Options.UseFont = true;
            this.bt_ajouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_ajouter.ImageOptions.Image")));
            this.bt_ajouter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_ajouter.Location = new System.Drawing.Point(12, 13);
            this.bt_ajouter.Name = "bt_ajouter";
            this.bt_ajouter.Size = new System.Drawing.Size(111, 84);
            this.bt_ajouter.TabIndex = 15;
            this.bt_ajouter.Text = "Ajouter";
            this.bt_ajouter.Click += new System.EventHandler(this.bt_ajouter_Click);
            // 
            // bt_modifier
            // 
            this.bt_modifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_modifier.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_modifier.Appearance.Options.UseFont = true;
            this.bt_modifier.Enabled = false;
            this.bt_modifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_modifier.ImageOptions.Image")));
            this.bt_modifier.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_modifier.Location = new System.Drawing.Point(12, 103);
            this.bt_modifier.Name = "bt_modifier";
            this.bt_modifier.Size = new System.Drawing.Size(111, 75);
            this.bt_modifier.TabIndex = 16;
            this.bt_modifier.Text = "Modifier";
            this.bt_modifier.Click += new System.EventHandler(this.bt_modifier_Click);
            // 
            // bt_enregistrer
            // 
            this.bt_enregistrer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_enregistrer.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_enregistrer.Appearance.Options.UseFont = true;
            this.bt_enregistrer.Enabled = false;
            this.bt_enregistrer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_enregistrer.ImageOptions.Image")));
            this.bt_enregistrer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_enregistrer.Location = new System.Drawing.Point(12, 190);
            this.bt_enregistrer.Name = "bt_enregistrer";
            this.bt_enregistrer.Size = new System.Drawing.Size(111, 83);
            this.bt_enregistrer.TabIndex = 5;
            this.bt_enregistrer.Text = "Enregistrer";
            this.bt_enregistrer.Click += new System.EventHandler(this.bt_enregistrer_Click);
            // 
            // tableau_horaire
            // 
            this.tableau_horaire.AllowUserToAddRows = false;
            this.tableau_horaire.AllowUserToDeleteRows = false;
            this.tableau_horaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableau_horaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableau_horaire.Location = new System.Drawing.Point(0, 0);
            this.tableau_horaire.Name = "tableau_horaire";
            this.tableau_horaire.ReadOnly = true;
            this.tableau_horaire.RowHeadersWidth = 51;
            this.tableau_horaire.RowTemplate.Height = 24;
            this.tableau_horaire.Size = new System.Drawing.Size(644, 448);
            this.tableau_horaire.TabIndex = 0;
            this.tableau_horaire.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableau_horaire_CellClick);
            // 
            // Form23
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 727);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form23";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temps Employee ";
            this.Load += new System.EventHandler(this.Form23_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableau_horaire)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txt_nom_prenom;
        public System.Windows.Forms.TextBox txt_matricule;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public System.Windows.Forms.ComboBox cb_horaire_travail;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private System.Windows.Forms.DateTimePicker dt_au;
        private System.Windows.Forms.DateTimePicker dt_du;
        public DevExpress.XtraEditors.SimpleButton bt_ajouter;
        public DevExpress.XtraEditors.SimpleButton bt_modifier;
        public DevExpress.XtraEditors.SimpleButton bt_enregistrer;
        private System.Windows.Forms.DataGridView tableau_horaire;
    }
}