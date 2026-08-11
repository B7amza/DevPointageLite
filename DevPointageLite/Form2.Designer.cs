namespace DevPointageLite
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pn_continer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.bt_principale = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator2 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_stucture = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_fonction = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_typeconge = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_TempsEmployee = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_HoraireTravail = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_gererPointeuse = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_gererUtilisateur = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_impData = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_employe = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator3 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.bt_absence = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator5 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.bt_Telecharger = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator4 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.bt_pointageM = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.bt_PointageJR = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
            this.lbActive = new DevExpress.XtraBars.BarButtonItem();
            this.lbDActivation = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_continer
            // 
            this.pn_continer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_continer.Location = new System.Drawing.Point(406, 39);
            this.pn_continer.Name = "pn_continer";
            this.pn_continer.Size = new System.Drawing.Size(1092, 942);
            this.pn_continer.TabIndex = 0;
            this.pn_continer.Click += new System.EventHandler(this.pn_continer_Click);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.bt_principale,
            this.accordionControlSeparator2,
            this.accordionControlElement1,
            this.bt_employe,
            this.accordionControlSeparator3,
            this.bt_absence,
            this.accordionControlSeparator5,
            this.bt_Telecharger,
            this.accordionControlSeparator4,
            this.bt_pointageM,
            this.bt_PointageJR});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(406, 942);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            this.accordionControl1.Click += new System.EventHandler(this.accordionControl1_Click);
            // 
            // bt_principale
            // 
            this.bt_principale.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_principale.Appearance.Default.Options.UseFont = true;
            this.bt_principale.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_principale.ImageOptions.Image")));
            this.bt_principale.Name = "bt_principale";
            this.bt_principale.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_principale.Text = "HOME";
            this.bt_principale.Click += new System.EventHandler(this.bt_principale_Click);
            // 
            // accordionControlSeparator2
            // 
            this.accordionControlSeparator2.Name = "accordionControlSeparator2";
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.bt_stucture,
            this.bt_fonction,
            this.bt_typeconge,
            this.bt_TempsEmployee,
            this.bt_HoraireTravail,
            this.bt_gererPointeuse,
            this.bt_gererUtilisateur,
            this.bt_impData});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Base";
            this.accordionControlElement1.Click += new System.EventHandler(this.accordionControlElement1_Click);
            // 
            // bt_stucture
            // 
            this.bt_stucture.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_stucture.Appearance.Default.Options.UseFont = true;
            this.bt_stucture.Name = "bt_stucture";
            this.bt_stucture.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_stucture.Text = "Affectation";
            this.bt_stucture.Click += new System.EventHandler(this.bt_stucture_Click);
            // 
            // bt_fonction
            // 
            this.bt_fonction.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fonction.Appearance.Default.Options.UseFont = true;
            this.bt_fonction.Name = "bt_fonction";
            this.bt_fonction.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_fonction.Text = "Fonction";
            this.bt_fonction.Click += new System.EventHandler(this.bt_piece_Click_1);
            // 
            // bt_typeconge
            // 
            this.bt_typeconge.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_typeconge.Appearance.Default.Options.UseFont = true;
            this.bt_typeconge.Name = "bt_typeconge";
            this.bt_typeconge.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_typeconge.Text = "Type Congé";
            this.bt_typeconge.Click += new System.EventHandler(this.bt_typeconge_Click);
            // 
            // bt_TempsEmployee
            // 
            this.bt_TempsEmployee.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.bt_TempsEmployee.Appearance.Default.Options.UseFont = true;
            this.bt_TempsEmployee.Name = "bt_TempsEmployee";
            this.bt_TempsEmployee.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_TempsEmployee.Text = "Temps Employee";
            this.bt_TempsEmployee.Click += new System.EventHandler(this.bt_TempsEmployee_Click);
            // 
            // bt_HoraireTravail
            // 
            this.bt_HoraireTravail.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.bt_HoraireTravail.Appearance.Default.Options.UseFont = true;
            this.bt_HoraireTravail.Name = "bt_HoraireTravail";
            this.bt_HoraireTravail.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_HoraireTravail.Text = "Horaire Travail";
            this.bt_HoraireTravail.Click += new System.EventHandler(this.bt_HoraireTravail_Click);
            // 
            // bt_gererPointeuse
            // 
            this.bt_gererPointeuse.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_gererPointeuse.Appearance.Default.Options.UseFont = true;
            this.bt_gererPointeuse.Name = "bt_gererPointeuse";
            this.bt_gererPointeuse.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_gererPointeuse.Text = "Gerer Pointeuse";
            this.bt_gererPointeuse.Click += new System.EventHandler(this.bt_gererPointeuse_Click);
            // 
            // bt_gererUtilisateur
            // 
            this.bt_gererUtilisateur.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_gererUtilisateur.Appearance.Default.Options.UseFont = true;
            this.bt_gererUtilisateur.Name = "bt_gererUtilisateur";
            this.bt_gererUtilisateur.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_gererUtilisateur.Text = "Gerer Utilisateurs";
            this.bt_gererUtilisateur.Click += new System.EventHandler(this.bt_gererUtilisateur_Click);
            // 
            // bt_impData
            // 
            this.bt_impData.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.bt_impData.Appearance.Default.Options.UseFont = true;
            this.bt_impData.Name = "bt_impData";
            this.bt_impData.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_impData.Text = "Importer Donnée";
            this.bt_impData.Click += new System.EventHandler(this.bt_impData_Click);
            // 
            // bt_employe
            // 
            this.bt_employe.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_employe.Appearance.Default.Options.UseFont = true;
            this.bt_employe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_employe.ImageOptions.Image")));
            this.bt_employe.Name = "bt_employe";
            this.bt_employe.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_employe.Text = "Employee";
            this.bt_employe.Click += new System.EventHandler(this.bt_employe_Click);
            // 
            // accordionControlSeparator3
            // 
            this.accordionControlSeparator3.Name = "accordionControlSeparator3";
            // 
            // bt_absence
            // 
            this.bt_absence.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bt_absence.Appearance.Default.Options.UseFont = true;
            this.bt_absence.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_absence.ImageOptions.Image")));
            this.bt_absence.Name = "bt_absence";
            this.bt_absence.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_absence.Text = "Absence";
            this.bt_absence.Click += new System.EventHandler(this.bt_absence_Click);
            // 
            // accordionControlSeparator5
            // 
            this.accordionControlSeparator5.Name = "accordionControlSeparator5";
            // 
            // bt_Telecharger
            // 
            this.bt_Telecharger.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Telecharger.Appearance.Default.Options.UseFont = true;
            this.bt_Telecharger.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_Telecharger.ImageOptions.Image")));
            this.bt_Telecharger.Name = "bt_Telecharger";
            this.bt_Telecharger.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_Telecharger.Text = "Telecharger";
            this.bt_Telecharger.Click += new System.EventHandler(this.bt_client_Click);
            // 
            // accordionControlSeparator4
            // 
            this.accordionControlSeparator4.Name = "accordionControlSeparator4";
            // 
            // bt_pointageM
            // 
            this.bt_pointageM.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bt_pointageM.Appearance.Default.Options.UseFont = true;
            this.bt_pointageM.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_pointageM.ImageOptions.Image")));
            this.bt_pointageM.Name = "bt_pointageM";
            this.bt_pointageM.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_pointageM.Text = "Pointage";
            this.bt_pointageM.Click += new System.EventHandler(this.bt_pointageM_Click);
            // 
            // bt_PointageJR
            // 
            this.bt_PointageJR.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bt_PointageJR.Appearance.Default.Options.UseFont = true;
            this.bt_PointageJR.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_PointageJR.ImageOptions.Image")));
            this.bt_PointageJR.Name = "bt_PointageJR";
            this.bt_PointageJR.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.bt_PointageJR.Text = "Pointage JR";
            this.bt_PointageJR.Click += new System.EventHandler(this.bt_PointageJR_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem1,
            this.lbActive,
            this.lbDActivation,
            this.barHeaderItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHypertextLabel1});
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1498, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lbActive);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lbDActivation);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barHeaderItem1);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "فعل النسخة التجريبية";
            this.barEditItem1.Edit = this.repositoryItemHypertextLabel1;
            this.barEditItem1.Id = 0;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemHypertextLabel1
            // 
            this.repositoryItemHypertextLabel1.Name = "repositoryItemHypertextLabel1";
            // 
            // lbActive
            // 
            this.lbActive.Caption = "فعل النسخة التجريبية";
            this.lbActive.Id = 1;
            this.lbActive.Name = "lbActive";
            this.lbActive.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.lbActive_ItemClick);
            // 
            // lbDActivation
            // 
            this.lbDActivation.Caption = "طلب كود التفعيل";
            this.lbDActivation.Id = 2;
            this.lbDActivation.Name = "lbDActivation";
            this.lbDActivation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.lbDActivation_ItemClick);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Created By DevCoreDZ";
            this.barHeaderItem1.Id = 3;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem1,
            this.lbActive,
            this.lbDActivation,
            this.barHeaderItem1});
            this.fluentFormDefaultManager1.MaxItemId = 4;
            this.fluentFormDefaultManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHypertextLabel1});
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 981);
            this.ControlContainer = this.pn_continer;
            this.Controls.Add(this.pn_continer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "Form2";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Pointage Mono ...v2601";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer pn_continer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_principale;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_employe;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_Telecharger;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_stucture;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_fonction;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_gererPointeuse;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_pointageM;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_absence;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_PointageJR;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_typeconge;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel repositoryItemHypertextLabel1;
        private DevExpress.XtraBars.BarButtonItem lbActive;
        private DevExpress.XtraBars.BarButtonItem lbDActivation;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_gererUtilisateur;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_impData;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_TempsEmployee;
        private DevExpress.XtraBars.Navigation.AccordionControlElement bt_HoraireTravail;
    }
}

