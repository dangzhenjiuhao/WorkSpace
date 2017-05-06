using AiegleSalary.Bll;
using AiegleSalary.Model;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AiegleSalary.UI
{
    public partial class FrmBaoBiao : RibbonForm
    {
        public FrmBaoBiao()
        {
            InitializeComponent();
        }

        T_FlowTypeBll flowTypeBll = new T_FlowTypeBll();
        T_WPCardBll wpCardBll = new T_WPCardBll();
        T_BasicWPBll basicWPBll = new T_BasicWPBll();
        T_EmpSalaryBll empSalaryBll = new T_EmpSalaryBll();


        OrderDataBll orderDataBll = new OrderDataBll();

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {


            #region OldVersion
            //DateTime startTime = dtpStartTime.Value;
            //DateTime endTime = dtpEndTime.Value;
            //int cbSelected = Convert.ToInt32(cbFlowType.SelectedValue);

            //if (DateTime.Compare(startTime, endTime) > 0)
            //{
            //    MessageBox.Show("出错了,开始时间不能大于结束时间");
            //    return;
            //}


            //var basicList = basicWPBll.GetListBy(bs => bs.FlowID == cbSelected);

            //if (basicList != null && basicList.Count > 0)
            //{
            //    var list = wpCardBll.GetListBy(wp =>
            //            wp.APDate >= startTime && wp.APDate <= endTime && wp.ListType == cbSelected).Join(basicList, wp => wp.wpCode, bs => bs.WPCode, (wp, bs) => new OrderDetails()
            //            {
            //                ApDate = wp.APDate.ToString(),
            //                OrderID = wp.OrderID,
            //                GXName = bs.GongXu + "-" + bs.GXContent,
            //                GXWpCode = wp.wpCode,
            //                Qty = wp.Qty,
            //                Price = bs.Price,
            //                AllCount = wp.Qty * bs.Price,
            //                EmpName = wp.A2,
            //                EmpSalary = wp.A4
            //            });
            //    //var list = wpCardBll.GetListBy(wp => wp.APDate >= startTime && wp.APDate <= endTime && wp.ListType == cbSelected);
            //    List<OrderDetails> orderList = new List<OrderDetails>();
            //    foreach (var item in list)
            //    {
            //        orderList.Add(new OrderDetails
            //        {
            //            ApDate = item.ApDate,
            //            OrderID = item.OrderID,
            //            GXName = item.GXName,
            //            GXWpCode = item.GXWpCode,
            //            Qty = item.Qty,
            //            Price = item.Price,
            //            AllCount = item.AllCount,
            //            EmpName = item.EmpName,
            //            EmpSalary = item.EmpSalary
            //        });
            //    } 
            //

            //    //dgvData.
            //    dgvData.Columns.Clear();
            //    AddColumn("ApDate", "完工日期");
            //    AddColumn("OrderID", "分单号");
            //    AddColumn("GXName", "工序名称");
            //    AddColumn("GXWpCode", "工序编码");
            //    AddColumn("Qty", "数量");
            //    AddColumn("Price", "单价");
            //    AddColumn("AllCount", "合计");
            //    AddColumn("EmpName", "人员");
            //    AddColumn("EmpSalary", "薪资");
            //    this.dgvData.AutoGenerateColumns = false;
            //    dgvData.DataSource = orderList; 
            //}
            #endregion

            if (string.Compare(dtpStartTime.Value.ToShortDateString(), dtpEndTime.Value.ToShortDateString()) > 0)
            {
                MessageBox.Show("出错了,开始时间不能大于结束时间");
                return;
            }

            string startTime = dtpStartTime.Value.ToShortDateString();
            string endTime = dtpEndTime.Value.ToShortDateString();
            DataSet dSet = orderDataBll.GetOrderDetailsListByCondition(startTime, endTime, Convert.ToInt32(cbFlowType.SelectedValue));
            if (dSet!=null)
            {
                dgvData.DataSource = dSet.Tables[0]; 
            }
        }

        private void FrmBaoBiao_Load(object sender, EventArgs e)
        {
            cbFlowType.DataSource = flowTypeBll.GetListBy(flow => 1 == 1);
            cbFlowType.DisplayMember = "FlowName";
            cbFlowType.ValueMember = "FlowID";

        }

        public void AddColumn(string columnName,string headerText)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            column.Name = columnName;
            column.HeaderText = headerText;
            column.DataPropertyName = columnName;
            column.Visible = true;
            this.dgvData.Columns.Add(column);
        }

        /// <summary>
        /// 获取所有员工的汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpSalaryAll_Click(object sender, EventArgs e)
        {


            if (string.Compare(dtpStartTime.Value.ToShortDateString(), dtpEndTime.Value.ToShortDateString()) > 0)
            {
                MessageBox.Show("出错了,开始时间不能大于结束时间");
                return;
            }
            
            string startTime = dtpStartTime.Value.ToShortDateString();
            string endTime = dtpEndTime.Value.ToShortDateString();
            int cbSelected = Convert.ToInt32(cbFlowType.SelectedValue);

            DataSet dSet = orderDataBll.GetEmpSalaryListByCondition(startTime, endTime, txtNameOrEID.Text.Trim());
            if (dSet != null)
            {
                dgvData.DataSource = dSet.Tables[0];
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpSalary_Click(object sender, EventArgs e)
        {
            if (string.Compare(dtpStartTime.Value.ToShortDateString(), dtpEndTime.Value.ToShortDateString()) > 0)
            {
                MessageBox.Show("出错了,开始时间不能大于结束时间");
                return;
            }

            string startTime = dtpStartTime.Value.ToShortDateString();
            string endTime = dtpEndTime.Value.ToShortDateString();

            DataSet dSet = orderDataBll.GetEmpSalaryDetailByCondition(startTime, endTime, txtNameOrEID.Text.Trim());
            if (dSet != null)
            {
                dgvData.DataSource = dSet.Tables[0];
            }
        }
    }
}
