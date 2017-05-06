namespace AiegleSalary.UI
{
    partial class FrmBaoBiao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaoBiao));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFlowType = new System.Windows.Forms.ComboBox();
            this.btnOrderDetail = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameOrEID = new System.Windows.Forms.TextBox();
            this.btnEmpSalary = new DevExpress.XtraEditors.SimpleButton();
            this.dgvData = new AiegleSalary.UI.MyDataGridView();
            this.btnEmpSalaryAll = new DevExpress.XtraEditors.SimpleButton();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(1172, 55);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束日期";
            // 
            // cbFlowType
            // 
            this.cbFlowType.FormattingEnabled = true;
            this.cbFlowType.Location = new System.Drawing.Point(412, 62);
            this.cbFlowType.Name = "cbFlowType";
            this.cbFlowType.Size = new System.Drawing.Size(121, 22);
            this.cbFlowType.TabIndex = 5;
            // 
            // btnOrderDetail
            // 
            this.btnOrderDetail.Location = new System.Drawing.Point(550, 64);
            this.btnOrderDetail.Name = "btnOrderDetail";
            this.btnOrderDetail.Size = new System.Drawing.Size(91, 23);
            this.btnOrderDetail.TabIndex = 7;
            this.btnOrderDetail.Text = "订单明细表";
            this.btnOrderDetail.Click += new System.EventHandler(this.btnOrderDetail_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "员工姓名或工号";
            // 
            // txtNameOrEID
            // 
            this.txtNameOrEID.Location = new System.Drawing.Point(763, 65);
            this.txtNameOrEID.Name = "txtNameOrEID";
            this.txtNameOrEID.Size = new System.Drawing.Size(110, 22);
            this.txtNameOrEID.TabIndex = 9;
            // 
            // btnEmpSalary
            // 
            this.btnEmpSalary.Location = new System.Drawing.Point(894, 64);
            this.btnEmpSalary.Name = "btnEmpSalary";
            this.btnEmpSalary.Size = new System.Drawing.Size(102, 23);
            this.btnEmpSalary.TabIndex = 10;
            this.btnEmpSalary.Text = "员工薪资汇总表";
            this.btnEmpSalary.Click += new System.EventHandler(this.btnEmpSalary_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvData.Location = new System.Drawing.Point(0, 100);
            this.dgvData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgvData.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvData.MergeColumnNames")));
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(1172, 558);
            this.dgvData.TabIndex = 12;
            // 
            // btnEmpSalaryAll
            // 
            this.btnEmpSalaryAll.Location = new System.Drawing.Point(1002, 64);
            this.btnEmpSalaryAll.Name = "btnEmpSalaryAll";
            this.btnEmpSalaryAll.Size = new System.Drawing.Size(102, 23);
            this.btnEmpSalaryAll.TabIndex = 14;
            this.btnEmpSalaryAll.Text = "员工薪资汇总表";
            this.btnEmpSalaryAll.Click += new System.EventHandler(this.btnEmpSalaryAll_Click);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(73, 62);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(124, 22);
            this.dtpStartTime.TabIndex = 36;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(282, 62);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(124, 22);
            this.dtpEndTime.TabIndex = 37;
            // 
            // FrmBaoBiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 658);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.btnEmpSalaryAll);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnEmpSalary);
            this.Controls.Add(this.txtNameOrEID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOrderDetail);
            this.Controls.Add(this.cbFlowType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbonControl1);
            this.MaximizeBox = false;
            this.Name = "FrmBaoBiao";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBaoBiao";
            this.Load += new System.EventHandler(this.FrmBaoBiao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFlowType;
        private DevExpress.XtraEditors.SimpleButton btnOrderDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameOrEID;
        private DevExpress.XtraEditors.SimpleButton btnEmpSalary;
        private MyDataGridView dgvData;
        private DevExpress.XtraEditors.SimpleButton btnEmpSalaryAll;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
    }
}