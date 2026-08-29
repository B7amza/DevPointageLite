namespace DevPointageLite
{
    partial class RibbonForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonForm1));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bt_employe = new DevExpress.XtraBars.BarButtonItem();
            this.bt_Telecharger = new DevExpress.XtraBars.BarButtonItem();
            this.bt_absence = new DevExpress.XtraBars.BarButtonItem();
            this.bt_pointageM = new DevExpress.XtraBars.BarButtonItem();
            this.bt_PointageJR = new DevExpress.XtraBars.BarButtonItem();
            this.bt_principale = new DevExpress.XtraBars.BarButtonItem();
            this.bt_stucture = new DevExpress.XtraBars.BarButtonItem();
            this.bt_fonction = new DevExpress.XtraBars.BarButtonItem();
            this.bt_typeconge = new DevExpress.XtraBars.BarButtonItem();
            this.bt_TempsEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.bt_HoraireTravail = new DevExpress.XtraBars.BarButtonItem();
            this.bt_gererPointeuse = new DevExpress.XtraBars.BarButtonItem();
            this.bt_gererUtilisateur = new DevExpress.XtraBars.BarButtonItem();
            this.bt_impData = new DevExpress.XtraBars.BarButtonItem();
            this.lbActive = new DevExpress.XtraBars.BarButtonItem();
            this.lbDActivation = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.pn_continer = new System.Windows.Forms.Panel();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bt_backup = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bt_employe,
            this.bt_Telecharger,
            this.bt_absence,
            this.bt_pointageM,
            this.bt_PointageJR,
            this.bt_principale,
            this.bt_stucture,
            this.bt_fonction,
            this.bt_typeconge,
            this.bt_TempsEmployee,
            this.bt_HoraireTravail,
            this.bt_gererPointeuse,
            this.bt_gererUtilisateur,
            this.bt_impData,
            this.lbActive,
            this.lbDActivation,
            this.barStaticItem1,
            this.bt_backup});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 20;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.QuickToolbarItemLinks.Add(this.lbActive);
            this.ribbon.QuickToolbarItemLinks.Add(this.lbDActivation);
            this.ribbon.Size = new System.Drawing.Size(1355, 193);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bt_employe
            // 
            this.bt_employe.Caption = "Employee";
            this.bt_employe.Id = 1;
            this.bt_employe.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_employe.ImageOptions.LargeImage")));
            this.bt_employe.Name = "bt_employe";
            this.bt_employe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_employe_ItemClick);
            // 
            // bt_Telecharger
            // 
            this.bt_Telecharger.Caption = "Telecharger";
            this.bt_Telecharger.Id = 2;
            this.bt_Telecharger.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_Telecharger.ImageOptions.LargeImage")));
            this.bt_Telecharger.Name = "bt_Telecharger";
            this.bt_Telecharger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_Telecharger_ItemClick);
            // 
            // bt_absence
            // 
            this.bt_absence.Caption = "Absence";
            this.bt_absence.Id = 3;
            this.bt_absence.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_absence.ImageOptions.LargeImage")));
            this.bt_absence.Name = "bt_absence";
            this.bt_absence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_absence_ItemClick);
            // 
            // bt_pointageM
            // 
            this.bt_pointageM.Caption = "Pointage";
            this.bt_pointageM.Id = 4;
            this.bt_pointageM.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_pointageM.ImageOptions.LargeImage")));
            this.bt_pointageM.Name = "bt_pointageM";
            this.bt_pointageM.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_pointageM_ItemClick);
            // 
            // bt_PointageJR
            // 
            this.bt_PointageJR.Caption = "Pointage JR";
            this.bt_PointageJR.Id = 5;
            this.bt_PointageJR.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_PointageJR.ImageOptions.LargeImage")));
            this.bt_PointageJR.Name = "bt_PointageJR";
            this.bt_PointageJR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_PointageJR_ItemClick);
            // 
            // bt_principale
            // 
            this.bt_principale.Caption = "HOME";
            this.bt_principale.Id = 6;
            this.bt_principale.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_principale.ImageOptions.LargeImage")));
            this.bt_principale.Name = "bt_principale";
            this.bt_principale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_principale_ItemClick);
            // 
            // bt_stucture
            // 
            this.bt_stucture.Caption = "Affectation";
            this.bt_stucture.Id = 7;
            this.bt_stucture.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_stucture.ImageOptions.LargeImage")));
            this.bt_stucture.Name = "bt_stucture";
            this.bt_stucture.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_stucture_ItemClick);
            // 
            // bt_fonction
            // 
            this.bt_fonction.Caption = "Fonction";
            this.bt_fonction.Id = 8;
            this.bt_fonction.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_fonction.ImageOptions.LargeImage")));
            this.bt_fonction.Name = "bt_fonction";
            this.bt_fonction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_fonction_ItemClick);
            // 
            // bt_typeconge
            // 
            this.bt_typeconge.Caption = "Type Congé";
            this.bt_typeconge.Id = 9;
            this.bt_typeconge.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_typeconge.ImageOptions.LargeImage")));
            this.bt_typeconge.Name = "bt_typeconge";
            this.bt_typeconge.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_typeconge_ItemClick);
            // 
            // bt_TempsEmployee
            // 
            this.bt_TempsEmployee.Caption = "Temps Employee";
            this.bt_TempsEmployee.Id = 10;
            this.bt_TempsEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_TempsEmployee.ImageOptions.LargeImage")));
            this.bt_TempsEmployee.Name = "bt_TempsEmployee";
            this.bt_TempsEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_TempsEmployee_ItemClick);
            // 
            // bt_HoraireTravail
            // 
            this.bt_HoraireTravail.Caption = "Horaire Travail";
            this.bt_HoraireTravail.Id = 11;
            this.bt_HoraireTravail.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_HoraireTravail.ImageOptions.LargeImage")));
            this.bt_HoraireTravail.Name = "bt_HoraireTravail";
            this.bt_HoraireTravail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_HoraireTravail_ItemClick);
            // 
            // bt_gererPointeuse
            // 
            this.bt_gererPointeuse.Caption = "Gerer Pointeuse";
            this.bt_gererPointeuse.Id = 12;
            this.bt_gererPointeuse.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_gererPointeuse.ImageOptions.LargeImage")));
            this.bt_gererPointeuse.Name = "bt_gererPointeuse";
            this.bt_gererPointeuse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_gererPointeuse_ItemClick);
            // 
            // bt_gererUtilisateur
            // 
            this.bt_gererUtilisateur.Caption = "Gerer Utilisateur";
            this.bt_gererUtilisateur.Id = 13;
            this.bt_gererUtilisateur.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_gererUtilisateur.ImageOptions.LargeImage")));
            this.bt_gererUtilisateur.Name = "bt_gererUtilisateur";
            this.bt_gererUtilisateur.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_gererUtilisateur_ItemClick);
            // 
            // bt_impData
            // 
            this.bt_impData.Caption = "Importer Donnée";
            this.bt_impData.Id = 14;
            this.bt_impData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_impData.ImageOptions.LargeImage")));
            this.bt_impData.Name = "bt_impData";
            this.bt_impData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_impData_ItemClick);
            // 
            // lbActive
            // 
            this.lbActive.Caption = "فعل النسخة التجريبية";
            this.lbActive.Id = 15;
            this.lbActive.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("lbActive.ImageOptions.LargeImage")));
            this.lbActive.Name = "lbActive";
            this.lbActive.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.lbActive.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.lbActive_ItemClick);
            // 
            // lbDActivation
            // 
            this.lbDActivation.Caption = "طلب كود التفعيل";
            this.lbDActivation.Id = 16;
            this.lbDActivation.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("lbDActivation.ImageOptions.LargeImage")));
            this.lbDActivation.Name = "lbDActivation";
            this.lbDActivation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.lbDActivation_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 18;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Details";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bt_principale);
            this.ribbonPageGroup1.ItemLinks.Add(this.bt_employe);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Personnel";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bt_Telecharger);
            this.ribbonPageGroup2.ItemLinks.Add(this.bt_absence);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Telechargement";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bt_pointageM);
            this.ribbonPageGroup3.ItemLinks.Add(this.bt_PointageJR);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Report";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Base";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.bt_stucture);
            this.ribbonPageGroup4.ItemLinks.Add(this.bt_fonction);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Structure";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.bt_typeconge);
            this.ribbonPageGroup5.ItemLinks.Add(this.bt_TempsEmployee);
            this.ribbonPageGroup5.ItemLinks.Add(this.bt_HoraireTravail);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Horaire";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.bt_gererPointeuse);
            this.ribbonPageGroup6.ItemLinks.Add(this.bt_gererUtilisateur);
            this.ribbonPageGroup6.ItemLinks.Add(this.bt_impData);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Administration";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 717);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1355, 30);
            // 
            // pn_continer
            // 
            this.pn_continer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_continer.Location = new System.Drawing.Point(0, 193);
            this.pn_continer.Name = "pn_continer";
            this.pn_continer.Size = new System.Drawing.Size(1355, 524);
            this.pn_continer.TabIndex = 2;
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.bt_backup);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "ribbonPageGroup7";
            // 
            // bt_backup
            // 
            this.bt_backup.Caption = "BackUp BDD";
            this.bt_backup.Id = 19;
            this.bt_backup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.bt_backup.Name = "bt_backup";
            this.bt_backup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_backup_ItemClick);
            // 
            // RibbonForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 747);
            this.Controls.Add(this.pn_continer);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonForm1";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Gestion Pointage Mono ...v2601";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RibbonForm1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RibbonForm1_FormClosed);
            this.Load += new System.EventHandler(this.RibbonForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bt_employe;
        private DevExpress.XtraBars.BarButtonItem bt_Telecharger;
        private DevExpress.XtraBars.BarButtonItem bt_absence;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bt_pointageM;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bt_PointageJR;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private System.Windows.Forms.Panel pn_continer;
        private DevExpress.XtraBars.BarButtonItem bt_principale;
        private DevExpress.XtraBars.BarButtonItem bt_stucture;
        private DevExpress.XtraBars.BarButtonItem bt_fonction;
        private DevExpress.XtraBars.BarButtonItem bt_typeconge;
        private DevExpress.XtraBars.BarButtonItem bt_TempsEmployee;
        private DevExpress.XtraBars.BarButtonItem bt_HoraireTravail;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem bt_gererPointeuse;
        private DevExpress.XtraBars.BarButtonItem bt_gererUtilisateur;
        private DevExpress.XtraBars.BarButtonItem bt_impData;
        private DevExpress.XtraBars.BarButtonItem lbActive;
        private DevExpress.XtraBars.BarButtonItem lbDActivation;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem bt_backup;
    }
}