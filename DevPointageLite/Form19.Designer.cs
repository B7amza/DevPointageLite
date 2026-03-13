namespace DevPointageLite
{
    partial class Form19
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form19));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chk_periodique = new System.Windows.Forms.CheckBox();
            this.txt_nbrABS = new System.Windows.Forms.TextBox();
            this.lb_nbrABS = new DevExpress.XtraEditors.LabelControl();
            this.txt_lib_conge = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_modifier = new DevExpress.XtraEditors.SimpleButton();
            this.bt_fermer = new DevExpress.XtraEditors.SimpleButton();
            this.bt_enregistrer = new DevExpress.XtraEditors.SimpleButton();
            this.bt_ajouter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chk_periodique);
            this.groupControl1.Controls.Add(this.txt_nbrABS);
            this.groupControl1.Controls.Add(this.lb_nbrABS);
            this.groupControl1.Controls.Add(this.txt_lib_conge);
            this.groupControl1.Controls.Add(this.txt_code);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(735, 369);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Congé Information ...";
            // 
            // chk_periodique
            // 
            this.chk_periodique.AutoSize = true;
            this.chk_periodique.Checked = true;
            this.chk_periodique.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_periodique.Location = new System.Drawing.Point(138, 184);
            this.chk_periodique.Name = "chk_periodique";
            this.chk_periodique.Size = new System.Drawing.Size(65, 20);
            this.chk_periodique.TabIndex = 2;
            this.chk_periodique.Text = "Congé";
            this.chk_periodique.UseVisualStyleBackColor = true;
            this.chk_periodique.CheckedChanged += new System.EventHandler(this.chk_periodique_CheckedChanged);
            // 
            // txt_nbrABS
            // 
            this.txt_nbrABS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nbrABS.Location = new System.Drawing.Point(138, 231);
            this.txt_nbrABS.Name = "txt_nbrABS";
            this.txt_nbrABS.Size = new System.Drawing.Size(104, 32);
            this.txt_nbrABS.TabIndex = 3;
            // 
            // lb_nbrABS
            // 
            this.lb_nbrABS.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nbrABS.Appearance.Options.UseFont = true;
            this.lb_nbrABS.Location = new System.Drawing.Point(16, 234);
            this.lb_nbrABS.Name = "lb_nbrABS";
            this.lb_nbrABS.Size = new System.Drawing.Size(96, 24);
            this.lb_nbrABS.TabIndex = 32;
            this.lb_nbrABS.Text = "Nbr Jours :";
            // 
            // txt_lib_conge
            // 
            this.txt_lib_conge.Enabled = false;
            this.txt_lib_conge.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lib_conge.Location = new System.Drawing.Point(138, 126);
            this.txt_lib_conge.Name = "txt_lib_conge";
            this.txt_lib_conge.Size = new System.Drawing.Size(571, 32);
            this.txt_lib_conge.TabIndex = 1;
            // 
            // txt_code
            // 
            this.txt_code.Enabled = false;
            this.txt_code.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code.Location = new System.Drawing.Point(138, 67);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(182, 32);
            this.txt_code.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 134);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(125, 24);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Designation  :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(36, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Code :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.bt_modifier);
            this.panel1.Controls.Add(this.bt_fermer);
            this.panel1.Controls.Add(this.bt_enregistrer);
            this.panel1.Controls.Add(this.bt_ajouter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 116);
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
            this.bt_modifier.Location = new System.Drawing.Point(184, 21);
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
            this.bt_fermer.Location = new System.Drawing.Point(596, 21);
            this.bt_fermer.Name = "bt_fermer";
            this.bt_fermer.Size = new System.Drawing.Size(148, 83);
            this.bt_fermer.TabIndex = 12;
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
            this.bt_enregistrer.Location = new System.Drawing.Point(349, 21);
            this.bt_enregistrer.Name = "bt_enregistrer";
            this.bt_enregistrer.Size = new System.Drawing.Size(148, 83);
            this.bt_enregistrer.TabIndex = 4;
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
            this.bt_ajouter.Location = new System.Drawing.Point(14, 21);
            this.bt_ajouter.Name = "bt_ajouter";
            this.bt_ajouter.Size = new System.Drawing.Size(148, 83);
            this.bt_ajouter.TabIndex = 10;
            this.bt_ajouter.Text = "Ajouter";
            this.bt_ajouter.Click += new System.EventHandler(this.bt_ajouter_Click);
            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 502);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form19";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Type de Congé...";
            this.Load += new System.EventHandler(this.Form19_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        public System.Windows.Forms.TextBox txt_lib_conge;
        public System.Windows.Forms.TextBox txt_code;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        public DevExpress.XtraEditors.SimpleButton bt_modifier;
        public DevExpress.XtraEditors.SimpleButton bt_fermer;
        public DevExpress.XtraEditors.SimpleButton bt_enregistrer;
        public DevExpress.XtraEditors.SimpleButton bt_ajouter;
        public System.Windows.Forms.TextBox txt_nbrABS;
        public System.Windows.Forms.CheckBox chk_periodique;
        public DevExpress.XtraEditors.LabelControl lb_nbrABS;
    }
}