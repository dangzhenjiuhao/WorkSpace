namespace AiegleSalary.UI
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barbtnFlowSet = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnEmpSet = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnBasic = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnOrderManage = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnEmpManage = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnProduce = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.tabDefault = new DevExpress.XtraTab.XtraTabPage();
            this.tabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.xPageDefault = new DevExpress.XtraTab.XtraTabPage();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barbtnReport = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barbtnFlowSet,
            this.barbtnEmpSet,
            this.barbtnBasic,
            this.barbtnOrderManage,
            this.barbtnEmpManage,
            this.barbtnProduce,
            this.barbtnReport});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1125, 151);
            // 
            // barbtnFlowSet
            // 
            this.barbtnFlowSet.Caption = "流程类型设置";
            this.barbtnFlowSet.Glyph = ((System.Drawing.Image)(resources.GetObject("barbtnFlowSet.Glyph")));
            this.barbtnFlowSet.Id = 1;
            this.barbtnFlowSet.Name = "barbtnFlowSet";
            this.barbtnFlowSet.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barbtnFlowSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnFlowSet_ItemClick);
            // 
            // barbtnEmpSet
            // 
            this.barbtnEmpSet.Caption = "员工设置";
            this.barbtnEmpSet.Glyph = ((System.Drawing.Image)(resources.GetObject("barbtnEmpSet.Glyph")));
            this.barbtnEmpSet.Id = 2;
            this.barbtnEmpSet.Name = "barbtnEmpSet";
            this.barbtnEmpSet.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barbtnEmpSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnEmpSet_ItemClick);
            // 
            // barbtnBasic
            // 
            this.barbtnBasic.Caption = "基础信息设置";
            this.barbtnBasic.Glyph = ((System.Drawing.Image)(resources.GetObject("barbtnBasic.Glyph")));
            this.barbtnBasic.Id = 3;
            this.barbtnBasic.Name = "barbtnBasic";
            this.barbtnBasic.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barbtnBasic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnBasic_ItemClick);
            // 
            // barbtnOrderManage
            // 
            this.barbtnOrderManage.Caption = "订单信息管理";
            this.barbtnOrderManage.Glyph = ((System.Drawing.Image)(resources.GetObject("barbtnOrderManage.Glyph")));
            this.barbtnOrderManage.Id = 4;
            this.barbtnOrderManage.Name = "barbtnOrderManage";
            this.barbtnOrderManage.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barbtnEmpManage
            // 
            this.barbtnEmpManage.Caption = "员工薪资管理";
            this.barbtnEmpManage.Glyph = ((System.Drawing.Image)(resources.GetObject("barbtnEmpManage.Glyph")));
            this.barbtnEmpManage.Id = 5;
            this.barbtnEmpManage.Name = "barbtnEmpManage";
            this.barbtnEmpManage.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barbtnProduce
            // 
            this.barbtnProduce.Caption = "生产流程卡";
            this.barbtnProduce.Glyph = ((System.Drawing.Image)(resources.GetObject("barbtnProduce.Glyph")));
            this.barbtnProduce.Id = 6;
            this.barbtnProduce.Name = "barbtnProduce";
            this.barbtnProduce.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barbtnProduce.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnProduce_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "基础数据设置";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtnProduce);
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtnReport);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "生产流程卡";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnFlowSet);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnEmpSet);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnBasic);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "基础数据设置";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnOrderManage);
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnEmpManage);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "信息管理";
            // 
            // tabDefault
            // 
            this.tabDefault.Name = "tabDefault";
            this.tabDefault.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefault.Size = new System.Drawing.Size(989, 501);
            this.tabDefault.Text = "首页";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 151);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedTabPage = this.xPageDefault;
            this.tabControlMain.Size = new System.Drawing.Size(1125, 424);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xPageDefault});
            this.tabControlMain.CloseButtonClick += new System.EventHandler(this.tabControlMain_CloseButtonClick);
            // 
            // xPageDefault
            // 
            this.xPageDefault.Name = "xPageDefault";
            this.xPageDefault.Size = new System.Drawing.Size(1123, 396);
            this.xPageDefault.Text = "首页";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            // 
            // barbtnReport
            // 
            this.barbtnReport.Caption = "系统报表";
            this.barbtnReport.Glyph = ((System.Drawing.Image)(resources.GetObject("barbtnReport.Glyph")));
            this.barbtnReport.Id = 7;
            this.barbtnReport.Name = "barbtnReport";
            this.barbtnReport.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barbtnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnReport_ItemClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 575);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barbtnFlowSet;
        private DevExpress.XtraBars.BarButtonItem barbtnEmpSet;
        private DevExpress.XtraBars.BarButtonItem barbtnBasic;
        private DevExpress.XtraBars.BarButtonItem barbtnOrderManage;
        private DevExpress.XtraBars.BarButtonItem barbtnEmpManage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraTab.XtraTabPage tabDefault;
        private DevExpress.XtraTab.XtraTabControl tabControlMain;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraTab.XtraTabPage xPageDefault;
        private DevExpress.XtraBars.BarButtonItem barbtnProduce;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barbtnReport;
    }
}