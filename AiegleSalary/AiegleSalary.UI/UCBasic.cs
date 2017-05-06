using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using AiegleSalary.Bll;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using AiegleSalary.Model;

namespace AiegleSalary.UI
{
    public partial class UCBasic : UserControl
    {
        public UCBasic()
        {
            InitializeComponent();
        }

        T_BasicWPBll basicWPBll = new T_BasicWPBll();

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
            var list = basicWPBll.GetListBy(f => 1 == 1,f=>f.FlowID,f=>f.Sort,true,true);
            //gridView1.OptionsView.ShowIndicator = false;//不显示最左边一列空白列
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;//设置单元格不能选择（如果不设置，则点击到的单元格在整行选择情况下的背景色不变）
            SetColumnName("编号", "ID", this.gridView1, "ID");
            SetColumnName("代码", "WPCode", this.gridView1, "WPCode");
            SetColumnName("工序", "GongXu", this.gridView1, "GongXu");
            SetColumnName("工序内容", "GXContent", this.gridView1, "GXContent");
            SetColumnName("单位", "Unit", this.gridView1, "Unit");
            SetColumnName("单价", "Price", this.gridView1, "Price");
            SetColumnName("备注", "ReMark", this.gridView1, "ReMark");
            SetColumnName("所尾流程ID", "FlowID", this.gridView1, "FlowID");
            SetColumnName("排序号", "Sort", this.gridView1, "Sort");
            SetColumnName("件数初始值", "CountDefaultValue", this.gridView1, "CountDefaultValue");

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
                    string WPCode = this.gridView1.GetRowCellValue(hInfo.RowHandle, "WPCode").ToString();
                    //MessageBox.Show(UId);
                    T_BasicWP selectedModel = basicWPBll.GetModel(m => m.WPCode == WPCode);
                    FrmBasicWP frmBasicWP = new FrmBasicWP();
                    frmBasicWP.FlushData = FlushData;
                    frmBasicWP.TransBasicWP = selectedModel;
                    frmBasicWP.IsAdd = false;
                    frmBasicWP.Show();
                }
            }
        }
        #endregion

        #region 控件加载事件
        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCBasic_Load(object sender, EventArgs e)
        {
            FlushData();
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
            FrmBasicWP frmBasicWP = new FrmBasicWP();
            frmBasicWP.FlushData = FlushData;
            frmBasicWP.IsAdd = true;
            frmBasicWP.ShowDialog();
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
                    string wpCode = this.gridView1.GetRowCellValue(rows[0], "WPCode").ToString();

                    int result = basicWPBll.DelBy(t => t.WPCode == wpCode);
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
                string WPCode = this.gridView1.GetRowCellValue(rows[0], "WPCode").ToString();
                T_BasicWP selectedModel = basicWPBll.GetModel(m => m.WPCode == WPCode);
                FrmBasicWP frmBasicWP = new FrmBasicWP();
                frmBasicWP.FlushData = FlushData;
                frmBasicWP.TransBasicWP = selectedModel;
                frmBasicWP.IsAdd = false;
                frmBasicWP.ShowDialog();
            }
        }
        #endregion

    }
}
