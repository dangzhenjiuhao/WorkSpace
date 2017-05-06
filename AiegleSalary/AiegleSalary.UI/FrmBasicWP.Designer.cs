namespace AiegleSalary.UI
{
    partial class FrmBasicWP
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtGongXu = new DevExpress.XtraEditors.TextEdit();
            this.txtWPCode = new DevExpress.XtraEditors.TextEdit();
            this.txtGXContent = new DevExpress.XtraEditors.TextEdit();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cbFlowType = new System.Windows.Forms.ComboBox();
            this.txtCountDefaultValue = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGongXu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWPCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGXContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountDefaultValue.Properties)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(597, 55);
            // 
            // btnN
            // 
            this.btnN.Location = new System.Drawing.Point(463, 300);
            this.btnN.Name = "btnN";
            this.btnN.Size = new System.Drawing.Size(87, 27);
            this.btnN.TabIndex = 13;
            this.btnN.Text = "取消";
            this.btnN.Click += new System.EventHandler(this.btnN_Click);
            // 
            // btnY
            // 
            this.btnY.Location = new System.Drawing.Point(351, 300);
            this.btnY.Name = "btnY";
            this.btnY.Size = new System.Drawing.Size(87, 27);
            this.btnY.TabIndex = 14;
            this.btnY.Text = "提交";
            this.btnY.Click += new System.EventHandler(this.btnY_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(350, 100);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "单位：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(326, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "操作内容：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(67, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "工序：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(75, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "编码:";
            // 
            // txtGongXu
            // 
            this.txtGongXu.Location = new System.Drawing.Point(128, 103);
            this.txtGongXu.Name = "txtGongXu";
            this.txtGongXu.Size = new System.Drawing.Size(166, 20);
            this.txtGongXu.TabIndex = 5;
            // 
            // txtWPCode
            // 
            this.txtWPCode.Location = new System.Drawing.Point(128, 68);
            this.txtWPCode.Name = "txtWPCode";
            this.txtWPCode.Size = new System.Drawing.Size(166, 20);
            this.txtWPCode.TabIndex = 6;
            // 
            // txtGXContent
            // 
            this.txtGXContent.Location = new System.Drawing.Point(403, 69);
            this.txtGXContent.Name = "txtGXContent";
            this.txtGXContent.Size = new System.Drawing.Size(166, 20);
            this.txtGXContent.TabIndex = 15;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(403, 97);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(166, 20);
            this.txtUnit.TabIndex = 17;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(128, 139);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(166, 20);
            this.txtPrice.TabIndex = 20;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(350, 142);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "备注：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(67, 142);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "单价：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(403, 139);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(166, 90);
            this.txtRemark.TabIndex = 21;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(43, 177);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 22;
            this.labelControl7.Text = "所属流程：";
            // 
            // txtSort
            // 
            this.txtSort.Location = new System.Drawing.Point(128, 212);
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(166, 20);
            this.txtSort.TabIndex = 25;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(55, 215);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(48, 14);
            this.labelControl8.TabIndex = 24;
            this.labelControl8.Text = "排序号：";
            // 
            // cbFlowType
            // 
            this.cbFlowType.FormattingEnabled = true;
            this.cbFlowType.Location = new System.Drawing.Point(128, 174);
            this.cbFlowType.Name = "cbFlowType";
            this.cbFlowType.Size = new System.Drawing.Size(168, 22);
            this.cbFlowType.TabIndex = 35;
            // 
            // txtCountDefaultValue
            // 
            this.txtCountDefaultValue.Location = new System.Drawing.Point(128, 248);
            this.txtCountDefaultValue.Name = "txtCountDefaultValue";
            this.txtCountDefaultValue.Size = new System.Drawing.Size(166, 20);
            this.txtCountDefaultValue.TabIndex = 38;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(31, 251);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(72, 14);
            this.labelControl9.TabIndex = 37;
            this.labelControl9.Text = "件数初始值：";
            // 
            // FrmBasicWP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 337);
            this.Controls.Add(this.txtCountDefaultValue);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.cbFlowType);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtGXContent);
            this.Controls.Add(this.btnN);
            this.Controls.Add(this.btnY);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtGongXu);
            this.Controls.Add(this.txtWPCode);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmBasicWP";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBasicWP";
            this.Load += new System.EventHandler(this.FrmBasicWP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGongXu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWPCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGXContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountDefaultValue.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.SimpleButton btnN;
        private DevExpress.XtraEditors.SimpleButton btnY;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtGongXu;
        private DevExpress.XtraEditors.TextEdit txtWPCode;
        private DevExpress.XtraEditors.TextEdit txtGXContent;
        private DevExpress.XtraEditors.TextEdit txtUnit;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtSort;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.ComboBox cbFlowType;
        private DevExpress.XtraEditors.TextEdit txtCountDefaultValue;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}