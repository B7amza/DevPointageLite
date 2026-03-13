namespace DevPointageLite
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.dt_au = new System.Windows.Forms.DateTimePicker();
            this.dt_du = new System.Windows.Forms.DateTimePicker();
            this.cb_horaire_travail = new System.Windows.Forms.ComboBox();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cb_pointage = new System.Windows.Forms.ComboBox();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.cb_affectation = new System.Windows.Forms.ComboBox();
            this.cb_fonction = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cb_sexe = new System.Windows.Forms.ComboBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_prenom = new System.Windows.Forms.TextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txt_adresse = new System.Windows.Forms.TextBox();
            this.txt_tel = new System.Windows.Forms.TextBox();
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.txt_matricule = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_modifier = new DevExpress.XtraEditors.SimpleButton();
            this.bt_fermer = new DevExpress.XtraEditors.SimpleButton();
            this.bt_enregistrer = new DevExpress.XtraEditors.SimpleButton();
            this.bt_ajouter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl13);
            this.groupControl3.Controls.Add(this.labelControl12);
            this.groupControl3.Controls.Add(this.dt_au);
            this.groupControl3.Controls.Add(this.dt_du);
            this.groupControl3.Controls.Add(this.cb_horaire_travail);
            this.groupControl3.Controls.Add(this.labelControl11);
            this.groupControl3.Location = new System.Drawing.Point(12, 473);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(916, 100);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "Plage Horaire...";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(668, 61);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(36, 24);
            this.labelControl13.TabIndex = 25;
            this.labelControl13.Text = "Au :";
            this.labelControl13.Visible = false;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(471, 61);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(38, 24);
            this.labelControl12.TabIndex = 22;
            this.labelControl12.Text = "Du :";
            this.labelControl12.Visible = false;
            // 
            // dt_au
            // 
            this.dt_au.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_au.Location = new System.Drawing.Point(710, 62);
            this.dt_au.Name = "dt_au";
            this.dt_au.Size = new System.Drawing.Size(119, 23);
            this.dt_au.TabIndex = 24;
            this.dt_au.Visible = false;
            // 
            // dt_du
            // 
            this.dt_du.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_du.Location = new System.Drawing.Point(515, 62);
            this.dt_du.Name = "dt_du";
            this.dt_du.Size = new System.Drawing.Size(119, 23);
            this.dt_du.TabIndex = 23;
            this.dt_du.Visible = false;
            // 
            // cb_horaire_travail
            // 
            this.cb_horaire_travail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_horaire_travail.Enabled = false;
            this.cb_horaire_travail.FormattingEnabled = true;
            this.cb_horaire_travail.Location = new System.Drawing.Point(186, 61);
            this.cb_horaire_travail.Name = "cb_horaire_travail";
            this.cb_horaire_travail.Size = new System.Drawing.Size(260, 24);
            this.cb_horaire_travail.TabIndex = 11;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(5, 62);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(175, 24);
            this.labelControl11.TabIndex = 4;
            this.labelControl11.Text = "Periode de Travail :";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cb_pointage);
            this.groupControl2.Controls.Add(this.cb_type);
            this.groupControl2.Controls.Add(this.cb_affectation);
            this.groupControl2.Controls.Add(this.cb_fonction);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.labelControl10);
            this.groupControl2.Location = new System.Drawing.Point(12, 266);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(918, 200);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Details ...";
            // 
            // cb_pointage
            // 
            this.cb_pointage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_pointage.Enabled = false;
            this.cb_pointage.FormattingEnabled = true;
            this.cb_pointage.Items.AddRange(new object[] {
            "Oui",
            "Non"});
            this.cb_pointage.Location = new System.Drawing.Point(147, 153);
            this.cb_pointage.Name = "cb_pointage";
            this.cb_pointage.Size = new System.Drawing.Size(300, 24);
            this.cb_pointage.TabIndex = 10;
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.Enabled = false;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "Active",
            "Bloque"});
            this.cb_type.Location = new System.Drawing.Point(534, 57);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(300, 24);
            this.cb_type.TabIndex = 8;
            // 
            // cb_affectation
            // 
            this.cb_affectation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_affectation.Enabled = false;
            this.cb_affectation.FormattingEnabled = true;
            this.cb_affectation.Location = new System.Drawing.Point(147, 104);
            this.cb_affectation.Name = "cb_affectation";
            this.cb_affectation.Size = new System.Drawing.Size(300, 24);
            this.cb_affectation.TabIndex = 9;
            // 
            // cb_fonction
            // 
            this.cb_fonction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_fonction.Enabled = false;
            this.cb_fonction.FormattingEnabled = true;
            this.cb_fonction.Location = new System.Drawing.Point(147, 55);
            this.cb_fonction.Name = "cb_fonction";
            this.cb_fonction.Size = new System.Drawing.Size(300, 24);
            this.cb_fonction.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(453, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 24);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Type :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(14, 151);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(91, 24);
            this.labelControl8.TabIndex = 3;
            this.labelControl8.Text = "Pointage :";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(14, 53);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(88, 24);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "Fonction :";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(14, 100);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(109, 24);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Affectation :";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cb_sexe);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.txt_prenom);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txt_adresse);
            this.groupControl1.Controls.Add(this.txt_tel);
            this.groupControl1.Controls.Add(this.txt_nom);
            this.groupControl1.Controls.Add(this.txt_matricule);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(916, 251);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Personnel Information ...";
            // 
            // cb_sexe
            // 
            this.cb_sexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sexe.Enabled = false;
            this.cb_sexe.FormattingEnabled = true;
            this.cb_sexe.Items.AddRange(new object[] {
            "Male",
            "Féminin"});
            this.cb_sexe.Location = new System.Drawing.Point(534, 156);
            this.cb_sexe.Name = "cb_sexe";
            this.cb_sexe.Size = new System.Drawing.Size(300, 24);
            this.cb_sexe.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(453, 156);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 24);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Sexe :";
            // 
            // txt_prenom
            // 
            this.txt_prenom.Enabled = false;
            this.txt_prenom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_prenom.Location = new System.Drawing.Point(534, 97);
            this.txt_prenom.Name = "txt_prenom";
            this.txt_prenom.Size = new System.Drawing.Size(300, 32);
            this.txt_prenom.TabIndex = 3;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(453, 100);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(81, 24);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Prenom :";
            // 
            // txt_adresse
            // 
            this.txt_adresse.Enabled = false;
            this.txt_adresse.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_adresse.Location = new System.Drawing.Point(146, 206);
            this.txt_adresse.Name = "txt_adresse";
            this.txt_adresse.Size = new System.Drawing.Size(688, 32);
            this.txt_adresse.TabIndex = 6;
            // 
            // txt_tel
            // 
            this.txt_tel.Enabled = false;
            this.txt_tel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tel.Location = new System.Drawing.Point(146, 148);
            this.txt_tel.MaxLength = 10;
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Size = new System.Drawing.Size(182, 32);
            this.txt_tel.TabIndex = 4;
            // 
            // txt_nom
            // 
            this.txt_nom.Enabled = false;
            this.txt_nom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom.Location = new System.Drawing.Point(146, 100);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(300, 32);
            this.txt_nom.TabIndex = 2;
            // 
            // txt_matricule
            // 
            this.txt_matricule.Enabled = false;
            this.txt_matricule.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_matricule.Location = new System.Drawing.Point(146, 45);
            this.txt_matricule.Name = "txt_matricule";
            this.txt_matricule.Size = new System.Drawing.Size(182, 32);
            this.txt_matricule.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(14, 214);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(83, 24);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Address :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(5, 151);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(135, 24);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "N° Telephone :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(14, 100);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 24);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Nom :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(14, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Matricule :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.bt_modifier);
            this.panel1.Controls.Add(this.bt_fermer);
            this.panel1.Controls.Add(this.bt_enregistrer);
            this.panel1.Controls.Add(this.bt_ajouter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 594);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 116);
            this.panel1.TabIndex = 6;
            // 
            // bt_modifier
            // 
            this.bt_modifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_modifier.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_modifier.Appearance.Options.UseFont = true;
            this.bt_modifier.Enabled = false;
            this.bt_modifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_modifier.ImageOptions.Image")));
            this.bt_modifier.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_modifier.Location = new System.Drawing.Point(268, 21);
            this.bt_modifier.Name = "bt_modifier";
            this.bt_modifier.Size = new System.Drawing.Size(148, 83);
            this.bt_modifier.TabIndex = 13;
            this.bt_modifier.Text = "Modifier";
            this.bt_modifier.Click += new System.EventHandler(this.bt_modifier_Click);
            // 
            // bt_fermer
            // 
            this.bt_fermer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_fermer.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fermer.Appearance.Options.UseFont = true;
            this.bt_fermer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_fermer.ImageOptions.Image")));
            this.bt_fermer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_fermer.Location = new System.Drawing.Point(680, 21);
            this.bt_fermer.Name = "bt_fermer";
            this.bt_fermer.Size = new System.Drawing.Size(148, 83);
            this.bt_fermer.TabIndex = 15;
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
            this.bt_enregistrer.Location = new System.Drawing.Point(433, 21);
            this.bt_enregistrer.Name = "bt_enregistrer";
            this.bt_enregistrer.Size = new System.Drawing.Size(148, 83);
            this.bt_enregistrer.TabIndex = 12;
            this.bt_enregistrer.Text = "Enregistrer";
            this.bt_enregistrer.Click += new System.EventHandler(this.bt_enregistrer_Click);
            // 
            // bt_ajouter
            // 
            this.bt_ajouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_ajouter.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ajouter.Appearance.Options.UseFont = true;
            this.bt_ajouter.Enabled = false;
            this.bt_ajouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_ajouter.ImageOptions.Image")));
            this.bt_ajouter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.bt_ajouter.Location = new System.Drawing.Point(98, 21);
            this.bt_ajouter.Name = "bt_ajouter";
            this.bt_ajouter.Size = new System.Drawing.Size(148, 83);
            this.bt_ajouter.TabIndex = 14;
            this.bt_ajouter.Text = "Ajouter";
            this.bt_ajouter.Click += new System.EventHandler(this.bt_ajouter_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 710);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personnel...";
            this.Load += new System.EventHandler(this.Form10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
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

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private System.Windows.Forms.DateTimePicker dt_au;
        private System.Windows.Forms.DateTimePicker dt_du;
        public System.Windows.Forms.ComboBox cb_horaire_travail;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        public System.Windows.Forms.ComboBox cb_pointage;
        public System.Windows.Forms.ComboBox cb_type;
        public System.Windows.Forms.ComboBox cb_affectation;
        public System.Windows.Forms.ComboBox cb_fonction;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public System.Windows.Forms.ComboBox cb_sexe;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public System.Windows.Forms.TextBox txt_prenom;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public System.Windows.Forms.TextBox txt_adresse;
        public System.Windows.Forms.TextBox txt_tel;
        public System.Windows.Forms.TextBox txt_nom;
        public System.Windows.Forms.TextBox txt_matricule;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        public DevExpress.XtraEditors.SimpleButton bt_modifier;
        public DevExpress.XtraEditors.SimpleButton bt_fermer;
        public DevExpress.XtraEditors.SimpleButton bt_enregistrer;
        public DevExpress.XtraEditors.SimpleButton bt_ajouter;
    }
}