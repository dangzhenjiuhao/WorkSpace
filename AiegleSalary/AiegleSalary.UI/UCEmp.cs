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
using AiegleSalary.Model;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AiegleSalary.UI
{
    public partial class UCEmp : UserControl
    {
        public UCEmp()
        {
            InitializeComponent();
        }

        T_EmpBll empBll = new T_EmpBll();

        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCEmp_Load(object sender, EventArgs e)
        {
            FlushData();
        } 
        #endregion

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
            var userList = empBll.GetListBy(e => 1 == 1);
            //gridView1.OptionsView.ShowIndicator = false;//不显示最左边一列空白列
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;//设置单元格不能选择（如果不设置，则点击到的单元格在整行选择情况下的背景色不变）

            SetColumnName("编号", "ID", this.gridView1, "ID");
            SetColumnName("短工号", "FID", this.gridView1, "FID");
            SetColumnName("长工号", "EID", this.gridView1, "EID");
            SetColumnName("名称", "EmpName", this.gridView1, "EmpName");
            SetColumnName("部门", "Dept", this.gridView1, "Dept");
            SetColumnName("职称", "POS", this.gridView1, "POS");
            SetColumnName("汇算比率", "CheckRate", this.gridView1, "CheckRate");

            this.gridControl1.DataSource = userList;
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
            FrmEmp frmEmp = new FrmEmp();
            frmEmp.FlushData = FlushData;
            frmEmp.IsAdd = true;
            frmEmp.ShowDialog();
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
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
                    string eID = this.gridView1.GetRowCellValue(rows[0], "EID").ToString();

                    int result = empBll.DelBy(t => t.EID == eID);
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
                string eID = this.gridView1.GetRowCellValue(rows[0], "EID").ToString();
                T_Emp selectedModel = empBll.GetModel(m => m.EID == eID);
                FrmEmp frmEmp = new FrmEmp();
                frmEmp.FlushData = FlushData;
                frmEmp.TransEmp = selectedModel;
                frmEmp.IsAdd = false;
                frmEmp.ShowDialog();
            }
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
                    string eID = this.gridView1.GetRowCellValue(hInfo.RowHandle, "EID").ToString();
                    T_Emp selectedModel = empBll.GetModel(m => m.EID == eID);
                    FrmEmp frmEmp = new FrmEmp();
                    frmEmp.FlushData = FlushData;
                    frmEmp.TransEmp = selectedModel;
                    frmEmp.IsAdd = false;
                    frmEmp.ShowDialog();
                }
            }
        }
        #endregion
    }
}
