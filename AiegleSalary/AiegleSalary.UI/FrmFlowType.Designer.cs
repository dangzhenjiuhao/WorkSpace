namespace AiegleSalary.UI
{
    partial class FrmFlowType
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnN = new DevExpress.XtraEditors.SimpleButton();
            this.btnY = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Size = new System.Drawing.Size(438, 55);
            // 
            // btnN
            // 
            this.btnN.Location = new System.Drawing.Point(300, 187);
            this.btnN.Name = "btnN";
            this.btnN.Size = new System.Drawing.Size(87, 27);
            this.btnN.TabIndex = 13;
            this.btnN.Text = "取消";
            this.btnN.Click += new System.EventHandler(this.btnN_Click);
            // 
            // btnY
            // 
            this.btnY.Location = new System.Drawing.Point(182, 187);
            this.btnY.Name = "btnY";
            this.btnY.Size = new System.Drawing.Size(87, 27);
            this.btnY.TabIndex = 14;
            this.btnY.Text = "提交";
            this.btnY.Click += new System.EventHandler(this.btnY_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(91, 102);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "备注：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(58, 63);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "流程类型名称:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(168, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(166, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(168, 98);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(166, 63);
            this.txtRemark.TabIndex = 7;
            // 
            // FrmFlowType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 234);
            this.Controls.Add(this.btnN);
            this.Controls.Add(this.btnY);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmFlowType";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFlowType";
            this.Load += new System.EventHandler(this.FrmFlowType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.SimpleButton btnN;
        private DevExpress.XtraEditors.SimpleButton btnY;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
    }
}