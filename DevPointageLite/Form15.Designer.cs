namespace DevPointageLite
{
    partial class Form15
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form15));
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dt_au = new System.Windows.Forms.DateTimePicker();
            this.dt_du = new System.Windows.Forms.DateTimePicker();
            this.chk_periodique = new System.Windows.Forms.CheckBox();
            this.txt_observation = new System.Windows.Forms.TextBox();
            this.txt_nbrABS = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lb_nbrABS = new DevExpress.XtraEditors.LabelControl();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cb_horaire = new System.Windows.Forms.ComboBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.bt_recherche = new System.Windows.Forms.Button();
            this.lb_nom_prenom = new DevExpress.XtraEditors.LabelControl();
            this.txt_matricule = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_annee = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.liste_mois = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_fermer = new DevExpress.XtraEditors.SimpleButton();
            this.bt_enregistrer = new DevExpress.XtraEditors.SimpleButton();
            this.bt_modifier = new DevExpress.XtraEditors.SimpleButton();
            this.bt_ajouter = new DevExpress.XtraEditors.SimpleButton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 481);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1144, 474);
            this.panel3.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1144, 474);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupControl2);
            this.panel2.Controls.Add(this.groupControl1);
            this.panel2.Controls.Add(this.txt_annee);
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.liste_mois);
            this.panel2.Controls.Add(this.labelControl4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1144, 481);
            this.panel2.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dt_au);
            this.groupControl2.Controls.Add(this.dt_du);
            this.groupControl2.Controls.Add(this.chk_periodique);
            this.groupControl2.Controls.Add(this.txt_observation);
            this.groupControl2.Controls.Add(this.txt_nbrABS);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.lb_nbrABS);
            this.groupControl2.Controls.Add(this.cb_type);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.cb_horaire);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(12, 191);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1099, 284);
            this.groupControl2.TabIndex = 23;
            this.groupControl2.Text = "Filtre Par ...";
            // 
            // dt_au
            // 
            this.dt_au.Enabled = false;
            this.dt_au.Location = new System.Drawing.Point(393, 196);
            this.dt_au.Name = "dt_au";
            this.dt_au.Size = new System.Drawing.Size(200, 23);
            this.dt_au.TabIndex = 6;
            this.dt_au.ValueChanged += new System.EventHandler(this.dt_au_ValueChanged);
            // 
            // dt_du
            // 
            this.dt_du.Enabled = false;
            this.dt_du.Location = new System.Drawing.Point(157, 48);
            this.dt_du.Name = "dt_du";
            this.dt_du.Size = new System.Drawing.Size(200, 23);
            this.dt_du.TabIndex = 2;
            this.dt_du.ValueChanged += new System.EventHandler(this.dt_du_ValueChanged);
            // 
            // chk_periodique
            // 
            this.chk_periodique.AutoSize = true;
            this.chk_periodique.Checked = true;
            this.chk_periodique.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_periodique.Enabled = false;
            this.chk_periodique.Location = new System.Drawing.Point(605, 149);
            this.chk_periodique.Name = "chk_periodique";
            this.chk_periodique.Size = new System.Drawing.Size(88, 20);
            this.chk_periodique.TabIndex = 30;
            this.chk_periodique.Text = "Bon Sortie";
            this.chk_periodique.UseVisualStyleBackColor = true;
            this.chk_periodique.CheckedChanged += new System.EventHandler(this.chk_periodique_CheckedChanged);
            // 
            // txt_observation
            // 
            this.txt_observation.Enabled = false;
            this.txt_observation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_observation.Location = new System.Drawing.Point(157, 234);
            this.txt_observation.Name = "txt_observation";
            this.txt_observation.Size = new System.Drawing.Size(436, 32);
            this.txt_observation.TabIndex = 7;
            // 
            // txt_nbrABS
            // 
            this.txt_nbrABS.Enabled = false;
            this.txt_nbrABS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nbrABS.Location = new System.Drawing.Point(157, 193);
            this.txt_nbrABS.Name = "txt_nbrABS";
            this.txt_nbrABS.Size = new System.Drawing.Size(104, 32);
            this.txt_nbrABS.TabIndex = 5;
            this.txt_nbrABS.Leave += new System.EventHandler(this.txt_nbrABS_Leave);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(16, 237);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(120, 24);
            this.labelControl8.TabIndex = 28;
            this.labelControl8.Text = "Observation :";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(342, 196);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 24);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "Au :";
            // 
            // lb_nbrABS
            // 
            this.lb_nbrABS.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nbrABS.Appearance.Options.UseFont = true;
            this.lb_nbrABS.Location = new System.Drawing.Point(16, 196);
            this.lb_nbrABS.Name = "lb_nbrABS";
            this.lb_nbrABS.Size = new System.Drawing.Size(102, 24);
            this.lb_nbrABS.TabIndex = 26;
            this.lb_nbrABS.Text = "Nbr Heurs :";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.Enabled = false;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(157, 147);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(436, 24);
            this.cb_type.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(16, 147);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 24);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "Nature :";
            // 
            // cb_horaire
            // 
            this.cb_horaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_horaire.Enabled = false;
            this.cb_horaire.FormattingEnabled = true;
            this.cb_horaire.Location = new System.Drawing.Point(157, 99);
            this.cb_horaire.Name = "cb_horaire";
            this.cb_horaire.Size = new System.Drawing.Size(436, 24);
            this.cb_horaire.TabIndex = 3;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(5, 99);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(146, 24);
            this.labelControl9.TabIndex = 22;
            this.labelControl9.Text = "Horaire Travail :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(16, 51);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(89, 24);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "Date DU :";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.bt_recherche);
            this.groupControl1.Controls.Add(this.lb_nom_prenom);
            this.groupControl1.Controls.Add(this.txt_matricule);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 27);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(791, 158);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Filtre Par ...";
            // 
            // bt_recherche
            // 
            this.bt_recherche.Location = new System.Drawing.Point(240, 50);
            this.bt_recherche.Name = "bt_recherche";
            this.bt_recherche.Size = new System.Drawing.Size(28, 32);
            this.bt_recherche.TabIndex = 21;
            this.bt_recherche.UseVisualStyleBackColor = true;
            // 
            // lb_nom_prenom
            // 
            this.lb_nom_prenom.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_prenom.Appearance.Options.UseFont = true;
            this.lb_nom_prenom.Location = new System.Drawing.Point(130, 110);
            this.lb_nom_prenom.Name = "lb_nom_prenom";
            this.lb_nom_prenom.Size = new System.Drawing.Size(121, 24);
            this.lb_nom_prenom.TabIndex = 18;
            this.lb_nom_prenom.Text = "Nom & Prenom";
            this.lb_nom_prenom.Visible = false;
            // 
            // txt_matricule
            // 
            this.txt_matricule.Enabled = false;
            this.txt_matricule.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_matricule.Location = new System.Drawing.Point(130, 51);
            this.txt_matricule.Name = "txt_matricule";
            this.txt_matricule.Size = new System.Drawing.Size(104, 32);
            this.txt_matricule.TabIndex = 1;
            this.txt_matricule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_matricule_KeyDown);
            this.txt_matricule.Leave += new System.EventHandler(this.txt_matricule_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 24);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Matricule :";
            // 
            // txt_annee
            // 
            this.txt_annee.Enabled = false;
            this.txt_annee.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_annee.Location = new System.Drawing.Point(929, 27);
            this.txt_annee.Name = "txt_annee";
            this.txt_annee.Size = new System.Drawing.Size(182, 32);
            this.txt_annee.TabIndex = 20;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(854, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 24);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Anneé :";
            // 
            // liste_mois
            // 
            this.liste_mois.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.liste_mois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.liste_mois.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liste_mois.FormattingEnabled = true;
            this.liste_mois.Items.AddRange(new object[] {
            "Janvier",
            "Février",
            "Mars",
            "Avril",
            "Mai",
            "Juin",
            "Juillet",
            "Aout",
            "Septembre",
            "Ocrobre",
            "Novembre",
            "Décembre"});
            this.liste_mois.Location = new System.Drawing.Point(929, 78);
            this.liste_mois.Margin = new System.Windows.Forms.Padding(4);
            this.liste_mois.Name = "liste_mois";
            this.liste_mois.Size = new System.Drawing.Size(182, 38);
            this.liste_mois.TabIndex = 13;
            this.liste_mois.SelectedIndexChanged += new System.EventHandler(this.liste_mois_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(866, 85);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 24);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Mois:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_fermer);
            this.panel1.Controls.Add(this.bt_enregistrer);
            this.panel1.Controls.Add(this.bt_modifier);
            this.panel1.Controls.Add(this.bt_ajouter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1144, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 955);
            this.panel1.TabIndex = 3;
            // 
            // bt_fermer
            // 
            this.bt_fermer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_fermer.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fermer.Appearance.Options.UseFont = true;
            this.bt_fermer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_fermer.ImageOptions.Image")));
            this.bt_fermer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_fermer.Location = new System.Drawing.Point(6, 839);
            this.bt_fermer.Name = "bt_fermer";
            this.bt_fermer.Size = new System.Drawing.Size(148, 83);
            this.bt_fermer.TabIndex = 16;
            this.bt_fermer.Text = "Fermer";
            this.bt_fermer.Click += new System.EventHandler(this.bt_fermer_Click);
            // 
            // bt_enregistrer
            // 
            this.bt_enregistrer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_enregistrer.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_enregistrer.Appearance.Options.UseFont = true;
            this.bt_enregistrer.Enabled = false;
            this.bt_enregistrer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_enregistrer.ImageOptions.Image")));
            this.bt_enregistrer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_enregistrer.Location = new System.Drawing.Point(6, 340);
            this.bt_enregistrer.Name = "bt_enregistrer";
            this.bt_enregistrer.Size = new System.Drawing.Size(148, 83);
            this.bt_enregistrer.TabIndex = 8;
            this.bt_enregistrer.Text = "Enregistrer";
            this.bt_enregistrer.Click += new System.EventHandler(this.bt_enregistrer_Click);
            // 
            // bt_modifier
            // 
            this.bt_modifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_modifier.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_modifier.Appearance.Options.UseFont = true;
            this.bt_modifier.Enabled = false;
            this.bt_modifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_modifier.ImageOptions.Image")));
            this.bt_modifier.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_modifier.Location = new System.Drawing.Point(6, 157);
            this.bt_modifier.Name = "bt_modifier";
            this.bt_modifier.Size = new System.Drawing.Size(148, 83);
            this.bt_modifier.TabIndex = 14;
            this.bt_modifier.Text = "Modifier";
            this.bt_modifier.Click += new System.EventHandler(this.bt_modifier_Click);
            // 
            // bt_ajouter
            // 
            this.bt_ajouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_ajouter.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ajouter.Appearance.Options.UseFont = true;
            this.bt_ajouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_ajouter.ImageOptions.Image")));
            this.bt_ajouter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_ajouter.Location = new System.Drawing.Point(6, 40);
            this.bt_ajouter.Name = "bt_ajouter";
            this.bt_ajouter.Size = new System.Drawing.Size(148, 83);
            this.bt_ajouter.TabIndex = 11;
            this.bt_ajouter.Text = "Ajouter";
            this.bt_ajouter.Click += new System.EventHandler(this.bt_ajouter_Click);
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 955);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Absence ...";
            this.Load += new System.EventHandler(this.Form15_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DateTimePicker dt_au;
        private System.Windows.Forms.DateTimePicker dt_du;
        private System.Windows.Forms.CheckBox chk_periodique;
        public System.Windows.Forms.TextBox txt_observation;
        public System.Windows.Forms.TextBox txt_nbrABS;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lb_nbrABS;
        public System.Windows.Forms.ComboBox cb_type;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public System.Windows.Forms.ComboBox cb_horaire;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public System.Windows.Forms.Button bt_recherche;
        private DevExpress.XtraEditors.LabelControl lb_nom_prenom;
        public System.Windows.Forms.TextBox txt_matricule;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public System.Windows.Forms.TextBox txt_annee;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public System.Windows.Forms.ComboBox liste_mois;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Panel panel1;
        public DevExpress.XtraEditors.SimpleButton bt_fermer;
        public DevExpress.XtraEditors.SimpleButton bt_enregistrer;
        public DevExpress.XtraEditors.SimpleButton bt_modifier;
        public DevExpress.XtraEditors.SimpleButton bt_ajouter;
    }
}