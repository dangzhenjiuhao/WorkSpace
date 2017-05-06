using AiegleSalary.Bll;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiegleSalary.UI
{
    public partial class FrmOrder : RibbonForm
    {
        public FrmOrder()
        {
            InitializeComponent();
        }

        T_EmpSalaryBll empSalaryBll = new T_EmpSalaryBll();
        T_WPCardBll wPCardBll = new T_WPCardBll();
        OrderDataBll orderDataBll = new OrderDataBll();
        T_FlowTypeBll flowTypeBll = new T_FlowTypeBll();

        #region 查询订单数据
        /// <summary>
        /// 查询订单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string orderID = txtOrder.Text.Trim();
            if (string.IsNullOrEmpty(orderID))
            {
                MessageBox.Show("请输入要查询的订单号!");
                return;
            }
            int flowType = Convert.ToInt32(cbType.SelectedValue);
            FlushData(orderID, flowType);
        } 
        #endregion

        #region 删除此订单数据
        /// <summary>
        /// 删除此订单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除此订单数据吗?", "删除提示", MessageBoxButtons.OKCancel);
             if (dr == DialogResult.OK)//如果点击“确定”按钮
             {
                 string orderID = txtOrder.Text.Trim();
                 int flowType = Convert.ToInt32(cbType.SelectedValue);
                 if (string.IsNullOrEmpty(orderID))
                 {
                     MessageBox.Show("请输入要删除的订单号!");
                     return;
                 }
                 bool result = orderDataBll.DeleteOrderData(orderID,flowType);
                 if (result)
                 {
                     MessageBox.Show("删除成功!");
                     this.dgvEmpSalary.DataSource = null;
                     this.dgvWPCard.DataSource = null;
                 }
                 else
                 {
                     MessageBox.Show("删除失败,失败原因:数据库可能无此订单数据!");
                     
                 }
             }
        } 
        #endregion

        #region 刷新数据
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void FlushData(string orderID,int flowType)
        {
            //this.dgvEmpSalary.Rows.Clear();
            //this.dgvWPCard.Rows.Clear();
            if (this.dgvEmpSalary.Rows.Count > 0)
            {
                this.dgvEmpSalary.DataSource = null;
            }
            if (this.dgvWPCard.Rows.Count > 0)
            {
                this.dgvWPCard.DataSource = null;
            }


            var empSalaryList = empSalaryBll.GetListBy(emp => emp.OrderID == orderID && emp.ListType == flowType);
            var wpCardList = wPCardBll.GetListBy(wp => wp.OrderID == orderID && wp.ListType == flowType);
            if (empSalaryList != null && empSalaryList.Count > 0)
            {
                this.dgvEmpSalary.DataSource = empSalaryList;
            }
            if (wpCardList != null && wpCardList.Count > 0)
            {
                this.dgvWPCard.DataSource = wpCardList;
            }
            if ((empSalaryList == null || empSalaryList.Count==0) && (wpCardList == null || wpCardList.Count == 0))
            {
                MessageBox.Show("无此订单数据");
                
            }

        }
        #endregion

        #region 窗体load事件
        /// <summary>
        /// 窗体load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            var typeList = flowTypeBll.GetListBy(f => 1 == 1);
            cbType.DisplayMember = "FlowName";
            cbType.ValueMember = "FlowID";
            cbType.DataSource = typeList;
        } 
        #endregion
    }
}
