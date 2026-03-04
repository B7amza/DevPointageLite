namespace DevPointageLite
{
    partial class Form17
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableau = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.entet2 = new System.Windows.Forms.DataGridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.bt_imprimer = new System.Windows.Forms.Button();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cb_horaire_travail = new System.Windows.Forms.ComboBox();
            this.ch_matricule = new System.Windows.Forms.CheckBox();
            this.ch_structure = new System.Windows.Forms.CheckBox();
            this.ch_tous = new System.Windows.Forms.CheckBox();
            this.date_jour = new System.Windows.Forms.DateTimePicker();
            this.bt_recherche = new System.Windows.Forms.Button();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lb_nom_prenom = new DevExpress.XtraEditors.LabelControl();
            this.txt_matricule = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cb_structure = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_apercu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableau)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableau
            // 
            this.tableau.AllowUserToAddRows = false;
            this.tableau.AllowUserToDeleteRows = false;
            this.tableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableau.Location = new System.Drawing.Point(12, 265);
            this.tableau.MultiSelect = false;
            this.tableau.Name = "tableau";
            this.tableau.ReadOnly = true;
            this.tableau.RowHeadersWidth = 10;
            this.tableau.RowTemplate.Height = 24;
            this.tableau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableau.Size = new System.Drawing.Size(396, 579);
            this.tableau.TabIndex = 9;
            this.tableau.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableau_CellClick);
            this.tableau.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tableau_Scroll);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 863);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1417, 52);
            this.panel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.entet2);
            this.panel1.Location = new System.Drawing.Point(415, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 579);
            this.panel1.TabIndex = 7;
            // 
            // entet2
            // 
            this.entet2.AllowUserToAddRows = false;
            this.entet2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.entet2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.entet2.ColumnHeadersHeight = 25;
            this.entet2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.entet2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15});
            this.entet2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entet2.Location = new System.Drawing.Point(0, 0);
            this.entet2.MultiSelect = false;
            this.entet2.Name = "entet2";
            this.entet2.ReadOnly = true;
            this.entet2.RowHeadersVisible = false;
            this.entet2.RowHeadersWidth = 10;
            this.entet2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.entet2.RowTemplate.Height = 24;
            this.entet2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.entet2.Size = new System.Drawing.Size(990, 579);
            this.entet2.TabIndex = 0;
            this.entet2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.entet2_CellClick);
            this.entet2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.entet2_Scroll);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.bt_imprimer);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cb_horaire_travail);
            this.groupControl1.Controls.Add(this.ch_matricule);
            this.groupControl1.Controls.Add(this.ch_structure);
            this.groupControl1.Controls.Add(this.ch_tous);
            this.groupControl1.Controls.Add(this.date_jour);
            this.groupControl1.Controls.Add(this.bt_apercu);
            this.groupControl1.Controls.Add(this.bt_recherche);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lb_nom_prenom);
            this.groupControl1.Controls.Add(this.txt_matricule);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.cb_structure);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Location = new System.Drawing.Point(12, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(799, 232);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Filtre Par ...";
            // 
            // bt_imprimer
            // 
            this.bt_imprimer.Image = global::DevPointageLite.Properties.Resources.print2;
            this.bt_imprimer.Location = new System.Drawing.Point(716, 147);
            this.bt_imprimer.Name = "bt_imprimer";
            this.bt_imprimer.Size = new System.Drawing.Size(75, 72);
            this.bt_imprimer.TabIndex = 29;
            this.bt_imprimer.UseVisualStyleBackColor = true;
            this.bt_imprimer.Click += new System.EventHandler(this.bt_imprimer_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(36, 187);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(97, 24);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "Horaire T :";
            // 
            // cb_horaire_travail
            // 
            this.cb_horaire_travail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_horaire_travail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_horaire_travail.FormattingEnabled = true;
            this.cb_horaire_travail.Items.AddRange(new object[] {
            "Oui",
            "Non"});
            this.cb_horaire_travail.Location = new System.Drawing.Point(166, 184);
            this.cb_horaire_travail.Name = "cb_horaire_travail";
            this.cb_horaire_travail.Size = new System.Drawing.Size(312, 32);
            this.cb_horaire_travail.TabIndex = 27;
            this.cb_horaire_travail.SelectedIndexChanged += new System.EventHandler(this.cb_horaire_travail_SelectedIndexChanged);
            // 
            // ch_matricule
            // 
            this.ch_matricule.AutoSize = true;
            this.ch_matricule.Location = new System.Drawing.Point(18, 144);
            this.ch_matricule.Name = "ch_matricule";
            this.ch_matricule.Size = new System.Drawing.Size(18, 17);
            this.ch_matricule.TabIndex = 26;
            this.ch_matricule.UseVisualStyleBackColor = true;
            this.ch_matricule.CheckedChanged += new System.EventHandler(this.ch_matricule_CheckedChanged);
            // 
            // ch_structure
            // 
            this.ch_structure.AutoSize = true;
            this.ch_structure.Location = new System.Drawing.Point(18, 90);
            this.ch_structure.Name = "ch_structure";
            this.ch_structure.Size = new System.Drawing.Size(18, 17);
            this.ch_structure.TabIndex = 25;
            this.ch_structure.UseVisualStyleBackColor = true;
            this.ch_structure.CheckedChanged += new System.EventHandler(this.ch_structure_CheckedChanged);
            // 
            // ch_tous
            // 
            this.ch_tous.AutoSize = true;
            this.ch_tous.Location = new System.Drawing.Point(393, 43);
            this.ch_tous.Name = "ch_tous";
            this.ch_tous.Size = new System.Drawing.Size(57, 20);
            this.ch_tous.TabIndex = 24;
            this.ch_tous.Text = "Tous";
            this.ch_tous.UseVisualStyleBackColor = true;
            this.ch_tous.CheckedChanged += new System.EventHandler(this.ch_tous_CheckedChanged);
            // 
            // date_jour
            // 
            this.date_jour.Location = new System.Drawing.Point(135, 40);
            this.date_jour.Name = "date_jour";
            this.date_jour.Size = new System.Drawing.Size(200, 23);
            this.date_jour.TabIndex = 23;
            // 
            // bt_recherche
            // 
            this.bt_recherche.Enabled = false;
            this.bt_recherche.Location = new System.Drawing.Point(276, 135);
            this.bt_recherche.Name = "bt_recherche";
            this.bt_recherche.Size = new System.Drawing.Size(28, 32);
            this.bt_recherche.TabIndex = 21;
            this.bt_recherche.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Enabled = false;
            this.labelControl2.Location = new System.Drawing.Point(46, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(94, 24);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Structure :";
            // 
            // lb_nom_prenom
            // 
            this.lb_nom_prenom.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_prenom.Appearance.Options.UseFont = true;
            this.lb_nom_prenom.Location = new System.Drawing.Point(375, 137);
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
            this.txt_matricule.Location = new System.Drawing.Point(166, 134);
            this.txt_matricule.Name = "txt_matricule";
            this.txt_matricule.Size = new System.Drawing.Size(104, 32);
            this.txt_matricule.TabIndex = 17;
            this.txt_matricule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_matricule_KeyDown);
            this.txt_matricule.Leave += new System.EventHandler(this.txt_matricule_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Enabled = false;
            this.labelControl1.Location = new System.Drawing.Point(46, 137);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 24);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Matricule :";
            // 
            // cb_structure
            // 
            this.cb_structure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_structure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_structure.Enabled = false;
            this.cb_structure.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_structure.FormattingEnabled = true;
            this.cb_structure.Items.AddRange(new object[] {
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
            this.cb_structure.Location = new System.Drawing.Point(171, 81);
            this.cb_structure.Margin = new System.Windows.Forms.Padding(4);
            this.cb_structure.Name = "cb_structure";
            this.cb_structure.Size = new System.Drawing.Size(315, 31);
            this.cb_structure.TabIndex = 13;
            this.cb_structure.SelectedIndexChanged += new System.EventHandler(this.cb_structure_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(18, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(87, 24);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Date Du :";
            // 
            // Column3
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column3.HeaderText = "Entreé";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column4.HeaderText = "";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Retard (m)";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column8.HeaderText = "";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column9.HeaderText = "Sortie";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Heurs Supp (H)";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Observation";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 160;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "12";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            this.Column12.Width = 125;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "H.Tr";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            this.Column13.Width = 125;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Prix.H";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            this.Column14.Width = 125;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Prix.Trv";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            this.Column15.Width = 125;
            // 
            // bt_apercu
            // 
            this.bt_apercu.Image = global::DevPointageLite.Properties.Resources.search2;
            this.bt_apercu.Location = new System.Drawing.Point(637, 147);
            this.bt_apercu.Name = "bt_apercu";
            this.bt_apercu.Size = new System.Drawing.Size(75, 72);
            this.bt_apercu.TabIndex = 22;
            this.bt_apercu.UseVisualStyleBackColor = true;
            this.bt_apercu.Click += new System.EventHandler(this.bt_apercu_Click);
            // 
            // Form17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 915);
            this.Controls.Add(this.tableau);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControl1);
            this.Name = "Form17";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Pointage Journalier ...";
            this.Load += new System.EventHandler(this.Form17_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableau)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tableau;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView entet2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public System.Windows.Forms.Button bt_imprimer;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public System.Windows.Forms.ComboBox cb_horaire_travail;
        private System.Windows.Forms.CheckBox ch_matricule;
        private System.Windows.Forms.CheckBox ch_structure;
        private System.Windows.Forms.CheckBox ch_tous;
        private System.Windows.Forms.DateTimePicker date_jour;
        public System.Windows.Forms.Button bt_apercu;
        public System.Windows.Forms.Button bt_recherche;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lb_nom_prenom;
        public System.Windows.Forms.TextBox txt_matricule;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public System.Windows.Forms.ComboBox cb_structure;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
    }
}