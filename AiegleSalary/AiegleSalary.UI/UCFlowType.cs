using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using AiegleSalary.Bll;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using AiegleSalary.Model;

namespace AiegleSalary.UI
{
    public partial class UCFlowType : UserControl
    {
        public UCFlowType()
        {
            InitializeComponent();
        }

        T_FlowTypeBll flowTypeBll = new T_FlowTypeBll();

        private void UCFlowType_Load(object sender, EventArgs e)
        {
            FlushData();
        }

        #region 自定义数据列
        /// <summary>
        /// 自定义数据列
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="fieldName"></param>
        /// <param name="gridView"></param>
        /// <param name="name"></param>
        private void SetColumnName(string columnName, string fieldName, GridView gridView, string name)
        {
            GridColumn column = new GridColumn();
            column.Caption = columnName;
            column.FieldName = fieldName;
            column.Name = name;
            column.Visible = true;
            gridView.Columns.Add(column);
        }
        #endregion

        #region 刷新数据
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void FlushData()
        {
            gridControl1.MainView = gridView1;
            gridView1.Columns.Clear();
            var list = flowTypeBll.GetListBy(f => 1 == 1);
            //gridView1.OptionsView.ShowIndicator = false;//不显示最左边一列空白列
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;//设置单元格不能选择（如果不设置，则点击到的单元格在整行选择情况下的背景色不变）

            SetColumnName("流程类型编号", "FlowID", this.gridView1, "FlowID");
            SetColumnName("流程类型名称", "FlowName", this.gridView1, "FlowName");
            SetColumnName("备注", "Remark", this.gridView1, "Remark");


            this.gridControl1.DataSource = list;
        }
        #endregion

        #region GridView明细行实现双击事件
        /// <summary>
        /// GridView明细行实现双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内
                if (hInfo.InRow)
                {
                    //MessageBox.Show(hInfo.RowHandle + "");
                    int flowID = Convert.ToInt32(this.gridView1.GetRowCellValue(hInfo.RowHandle, "FlowID").ToString());
                    //MessageBox.Show(UId);
                    T_FlowType selectedModel = flowTypeBll.GetModel(m => m.FlowID == flowID);
                    FrmFlowType frmFlowType = new FrmFlowType();
                    frmFlowType.FlushData = FlushData;
                    frmFlowType.TransFlowType = selectedModel;
                    frmFlowType.IsAdd = false;
                    frmFlowType.ShowDialog();
                }
            }
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmFlowType frmFlowType = new FrmFlowType();
            frmFlowType.FlushData = FlushData;
            frmFlowType.IsAdd = true;
            frmFlowType.ShowDialog();
        } 
        #endregion

        #region 删除流程类型
        /// <summary>
        /// 删除流程类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除选中的数据吗?", "删除提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                int[] rows = this.gridView1.GetSelectedRows();//获取选中的行
                if (rows != null && rows.Length > 0)
                {
                    int flowID = Convert.ToInt32(this.gridView1.GetRowCellValue(rows[0], "FlowID").ToString());

                    int result = flowTypeBll.DelBy(t => t.FlowID == flowID);
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功");
                        FlushData();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                } 
            }
        } 
        #endregion

        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int[] rows = this.gridView1.GetSelectedRows();//获取选中的行
            if (rows != null && rows.Length > 0)
            {
                int flowID = Convert.ToInt32(this.gridView1.GetRowCellValue(rows[0], "FlowID").ToString());
                T_FlowType selectedModel = flowTypeBll.GetModel(m => m.FlowID == flowID);
                FrmFlowType frmFlowType = new FrmFlowType();
                frmFlowType.FlushData = FlushData;
                frmFlowType.TransFlowType = selectedModel;
                frmFlowType.IsAdd = false;
                frmFlowType.ShowDialog();
            }
        } 
        #endregion

        
    }
}
