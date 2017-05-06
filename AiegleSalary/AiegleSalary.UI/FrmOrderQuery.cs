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
    public partial class FrmOrderQuery : RibbonForm
    {

        T_WPCardBll wPCardBll = new T_WPCardBll();
        OrderDataBll orderDataBll = new OrderDataBll();
        T_FlowTypeBll flowTypeBll = new T_FlowTypeBll();

        public FrmOrderQuery()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string orderID = txtOrder.Text.Trim();
            if (string.IsNullOrEmpty(orderID))
            {
                MessageBox.Show("请输入要查询的订单号!");
                return;
            }
            int flowType = Convert.ToInt32(cbType.SelectedValue);
            
            if (this.dgvWPCard.Rows.Count > 0)
            {
                this.dgvWPCard.DataSource = null;
            }

            List<WPCardDisplayModel> wpCardList = wPCardBll.GetListBy(wp => wp.OrderID == orderID && wp.ListType == flowType).ToList().Select(wp => new WPCardDisplayModel
            {
                DealerName = wp.DealerName,
                OrderID = wp.OrderID,
                OrderDate = wp.OrderDate,
                TotalArea = wp.TotalArea,
                MArea = wp.MArea,
                BArea = wp.BArea,
                APDate = wp.APDate
            }).ToList().GroupBy(wp => new { wp.DealerName, wp.OrderID, wp.OrderDate, wp.TotalArea, wp.MArea, wp.BArea, wp.APDate }).Select(p => new WPCardDisplayModel
            {
                DealerName = p.Key.DealerName,
                OrderID = p.Key.OrderID,
                OrderDate = p.Key.OrderDate,
                TotalArea = p.Key.TotalArea,
                MArea = p.Key.MArea,
                BArea = p.Key.BArea,
                APDate = p.Key.APDate
            }).ToList();

            if (wpCardList != null && wpCardList.Count > 0)
            {
                
                this.dgvWPCard.DataSource = wpCardList;
            }
            if (wpCardList == null || wpCardList.Count == 0)
            {
                MessageBox.Show("无此订单数据");

            }
        }

        #region 窗体load事件
        /// <summary>
        /// 窗体load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOrderQuery_Load(object sender, EventArgs e)
        {
            var typeList = flowTypeBll.GetListBy(f => 1 == 1);
            cbType.DisplayMember = "FlowName";
            cbType.ValueMember = "FlowID";
            cbType.DataSource = typeList;
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
                bool result = orderDataBll.DeleteOrderData(orderID, flowType);
                if (result)
                {
                    MessageBox.Show("删除成功!");
                    //this.dgvEmpSalary.DataSource = null;
                    this.dgvWPCard.DataSource = null;
                }
                else
                {
                    MessageBox.Show("删除失败,失败原因:数据库可能无此订单数据!");

                }
            }
        }
        #endregion

        #region 读取数据
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrder.Text.Trim()))
            {
                MessageBox.Show("订单号不能为空!");
            }
            else
            {
                int selectedValue = Convert.ToInt32(cbType.SelectedValue);
                string orderId = txtOrder.Text.Trim();
                var queryList = wPCardBll.GetListBy(wp => wp.OrderID == orderId && wp.ListType == selectedValue);
                if (queryList != null && queryList.Count > 0)
                {
                    FrmReadOrderData frmReadOrderData = new FrmReadOrderData();
                    frmReadOrderData.TransQueryData = queryList;
                    frmReadOrderData.ShowDialog();
                }
                else
                {
                    MessageBox.Show("没有找到此订单数据,请输入正确的订单号!");
                }
            }
            
        } 
        #endregion
    }
}
