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
using AiegleSalary.Model;
using AiegleSalary.Bll;

namespace AiegleSalary.UI
{
    public partial class UCProduce : UserControl
    {
        public UCProduce()
        {
            InitializeComponent();
        }

        T_BasicWPBll basicWPBll = new T_BasicWPBll();
        T_FlowTypeBll flowTypeBll = new T_FlowTypeBll();
        T_EmpBll empBll = new T_EmpBll();
        T_EmpSalaryBll empSalaryBll = new T_EmpSalaryBll();
        T_WPCardBll wPCardBll = new T_WPCardBll();

        //---------------------------------------------------
        //private DataGridViewTextBoxEditingControl EditingControl;
        //---------------------------------------------------

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool orderDataFlag = SetOrderData();
            if (!orderDataFlag)
            {
                return;
            }
            //---------------------------------
            btnSave.Enabled = true;
            List<bool> needInsertResult = new List<bool>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                string users = row.Cells["EmpSign"].EditedFormattedValue.ToString();
                string salary = row.Cells["EmpSalary"].EditedFormattedValue.ToString();
                string allMoney = row.Cells["AllMoney"].EditedFormattedValue.ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(row.Cells["Count"].EditedFormattedValue)) && !string.IsNullOrEmpty(users) && !string.IsNullOrEmpty(salary))
                {

                    double jianshu = Convert.ToDouble(row.Cells["Count"].EditedFormattedValue.ToString());
                    string wpCode = row.Cells["WPCode"].EditedFormattedValue.ToString();
                    string a1 = row.Cells["EmpSign"].EditedFormattedValue.ToString();
                    string a2 = row.Cells["EmpName"].EditedFormattedValue.ToString();
                    string empSalary = row.Cells["EmpSalary"].EditedFormattedValue.ToString();
                    string empIds = row.Cells["EmpIds"].EditedFormattedValue.ToString();
                    T_WPCard wpCard = new T_WPCard
                    {
                        DealerName = txtZMD.Text,
                        OrderID = txtOrder.Text,
                        OrderDate = txtOrderDate.Text,//
                        TotalArea = txtZPF.Text,
                        MArea = txtZhuPF.Text,
                        BArea = txtBeiBan.Text,
                        wpCode = wpCode,
                        APDate = dpWriteDate.Value,//
                        Qty = jianshu,//??
                        Salary = Convert.ToDouble(allMoney),//总工资
                        PricePer = null,
                        AppStatus = 0,
                        ListType = Convert.ToInt32(cbType.SelectedValue),
                        A1 = a1,
                        A2 = a2,
                        A3 = allMoney,
                        A4 = empSalary,
                        A5 = empIds,
                        MQty = Convert.ToInt32(jianshu)//??
                    };
                    wpCard = wPCardBll.AddReturnModel(wpCard); //添加记录
                    if (wpCard != null && wpCard.ID > 0)
                    {
                        string[] empIdsArray = row.Cells["empIds"].EditedFormattedValue.ToString().Split('.');
                        string[] salarys = salary.Split('/');
                        for (int i = 0; i < empIdsArray.Length; i++)
                        {
                            string empId = empIdsArray[i];
                            var emps = empBll.GetListBy(en => en.EID == empId);
                            if (emps != null && emps.Count > 0)
                            {
                                var emp = emps.FirstOrDefault();
                                T_EmpSalary t = new T_EmpSalary
                                {
                                    OrderID = txtOrder.Text,
                                    WPCode = wpCode,
                                    EID = emp.EID,
                                    EName = emp.EmpName,
                                    Salary = Convert.ToDouble(salarys[i]),
                                    ListType = Convert.ToInt32(cbType.SelectedValue)
                                };
                                t = empSalaryBll.AddReturnModel(t);//添加员工工资 

                                if (t != null && t.ID > 0)
                                {
                                    needInsertResult.Add(true);
                                    //--------------------------------------------------------------
                                }
                                else
                                {
                                    needInsertResult.Add(false);
                                }
                            }

                        }
                    }
                    
                }


            }
            if (!needInsertResult.Contains(false))
            {
                MessageBox.Show("保存成功!");
                btnSave.Enabled = false;
                Reset();
                txtOrder.Text = "";
                FlushData(Convert.ToInt32(cbType.SelectedValue));

            }
            else
            {
                MessageBox.Show("保存失败!");
                empSalaryBll.DelBy(emp => emp.OrderID == txtOrder.Text.Trim());
                wPCardBll.DelBy(wp => wp.OrderID == txtOrder.Text.Trim());
            }

            txtOrder.Focus();
        } 
        #endregion

        #region 自定义控件加载事件
        /// <summary>
        /// 自定义控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCProduce_Load(object sender, EventArgs e)
        {
            var typeList = flowTypeBll.GetListBy(f => 1 == 1);
            cbType.DisplayMember = "FlowName";
            cbType.ValueMember = "FlowID";
            cbType.DataSource = typeList;
            FlushData((int)cbType.SelectedValue);
            ForeachRows();
            

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
        private void SetColumnName(string columnName, string fieldName, GridView gridView, string name ,bool flag,bool allowEdit)
        {
            GridColumn column = new GridColumn();
            column.Caption = columnName;
            column.FieldName = fieldName;
            column.Name = name;
            column.Visible = flag;
            column.OptionsColumn.AllowEdit = allowEdit;
            gridView.Columns.Add(column);
        }
        #endregion

        #region 刷新数据
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void FlushData(int selectValue = 1)
        {
            var dataList = basicWPBll.GetListBy(b => b.FlowID == selectValue).OrderBy(b => b.Sort);
            List<DisplayModel> list = new List<DisplayModel>();
            foreach (var b in dataList)
            {
                DisplayModel model = new DisplayModel()
                {
                    GongXu = b.GongXu,
                    GXContent = b.GXContent,
                    WPCode = b.WPCode,
                    Unit = b.Unit,
                    Price = b.Price,
                    Count = b.CountDefaultValue == 0 ? "" : b.CountDefaultValue.ToString(),
                    AllUnitCount = "\\"
                };
                list.Add(model);
            }
            dgvData.DataSource = list;
            this.dgvData.MergeColumnNames.Add("GongXu");
            //this.dgvData.MergeColumnNames.Add("AllUnitCount");
        }
        #endregion

        #region 根据件数初始值计算总金额
        /// <summary>
        /// 根据件数初始值计算总金额
        /// </summary>
        public void ForeachRows()
        {
            for (int i = 0; i < this.dgvData.Rows.Count; i++)
            {
                var currentRow = this.dgvData.Rows[i];
                string currentValue = currentRow.Cells["Count"].EditedFormattedValue.ToString();
                if (string.IsNullOrEmpty(currentValue))
                {
                    continue;
                }

                if (currentValue.IsNumeric2())
                {
                    double value = Convert.ToDouble(currentValue);
                    double price = Convert.ToDouble(currentRow.Cells["Price"].EditedFormattedValue);
                    string tempAllMomey = Convert.ToDouble(value * price).ToString("0.00");
                    currentRow.Cells["AllMoney"].Value = Convert.ToDouble(tempAllMomey);
                }
            }
        } 
        #endregion

        #region 流程类型改变事件
        /// <summary>
        /// 流程类型改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectValue = (int)cbType.SelectedValue;
            FlushData(selectValue);
            //var dataList = basicWPBll.GetListBy(b => b.FlowID == selectValue).OrderBy(b=>b.Sort);
            ////List<DisplayModel> list = new List<DisplayModel>();
            ////foreach (var b in dataList)
            ////{
            ////    DisplayModel model = new DisplayModel()
            ////    {
            ////        GongXu = b.GongXu,
            ////        OperationContent = b.GXContent,
            ////        Code = b.WPCode,
            ////        Unit = b.Unit,
            ////        Price = b.Price
            ////    };
            ////    list.Add(model);
            ////}
            //this.dgvData.DataSource = dataList;
        } 
        #endregion

        #region 重写键盘弹起事件
        /// <summary>
        /// 重写键盘弹起事件
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnKeyUp(KeyEventArgs e)
        //{
        //    if (e.KeyCode == System.Windows.Forms.Keys.Enter)
        //    {
        //        e.Handled = true;
        //    }
        //}
        #endregion

        #region 处理命令事件
        /// <summary>
        /// 处理命令事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    switch (keyData)
        //    {
        //        case System.Windows.Forms.Keys.Enter:
        //            if (SetOrderData())
        //            {
        //                GetAllMoney();
        //                GetEmpSign();
        //            }
        //            return true;       
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        #endregion

        #region 获取用户名
        /// <summary>
        /// 获取用户名
        /// </summary>
        private void GetEmpSign()
        {
            //string jianShu =dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"].EditedFormattedValue.ToString();
            //if (string.IsNullOrEmpty(jianShu))
            //{
            //    MessageBox.Show("请先输入件数!");
            //    dgvData.CurrentCell = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"];
            //    return;
            //}

            if (dgvData.CurrentCell == dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpSign"])
            {
                if (string.IsNullOrEmpty(dgvData.CurrentCell.EditedFormattedValue.ToString()))
                {
                    int currentNullNext = dgvData.CurrentCell.RowIndex + 1;
                    if (currentNullNext <= dgvData.Rows.Count - 1)
                    {
                        dgvData.CurrentCell = dgvData.Rows[currentNullNext].Cells["EmpSign"];
                    }
                    return;
                }




                DataGridViewCell currentCell = dgvData.CurrentCell;
                string currentValue = (string)currentCell.EditedFormattedValue;

                if (string.IsNullOrEmpty(currentValue))
                {
                    return;
                }
                if (currentValue.Contains("."))
                {
                    string[] users = currentValue.Split('.');
                    List<T_Emp> empList = new List<T_Emp>();
                    for (int i = 0; i < users.Length; i++)
                    {
                        string currentUserName = users[i];
                        var model = empBll.GetModel(e => e.EID == currentUserName || e.FID == currentUserName || e.EmpName == currentUserName);
                        if (model!=null)
                        {
                            empList.Add(model);
                        }
                        else
                        {
                            MessageBox.Show("没有找到员工: " + currentUserName);
                            return;
                        }
                    }

                    //var empList = empBll.GetListBy(e => users.Contains(e.EID) || users.Contains(e.FID) || users.Contains(e.EmpName));
                    if (empList.Count > 0)
                    {
                        string empNames = string.Empty;
                        string empIds = string.Empty;
                        double empCheckRate = 0;
                        foreach (var emp in empList)
                        {
                            empNames += emp.EmpName + ".";
                            empIds += emp.EID + ".";
                            empCheckRate += Convert.ToDouble(emp.CheckRate);
                        }

                        if (empCheckRate >= 0)
                        {

                            //获取总金额
                            double allMomey = Convert.ToDouble(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["AllMoney"].EditedFormattedValue);
                            double perSalary = allMomey / empCheckRate;
                            string empSalary = string.Empty;
                            foreach (var item in empList)
                            {
                                empSalary += (Convert.ToDouble(item.CheckRate * perSalary)).ToString("0.00") + "/";
                            }
                            dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpSalary"].Value = empSalary.Substring(0, empSalary.Length - 1);
                            //设置ID
                            dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpIds"].Value = empIds.Substring(0, empIds.Length - 1);
                        }

                        dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpName"].Value = empNames.Substring(0, empNames.Length - 1);

                        int currentNext = dgvData.CurrentCell.RowIndex + 1;
                        if (currentNext <= dgvData.Rows.Count-1)
                        {
                            dgvData.CurrentCell = dgvData.Rows[currentNext].Cells["EmpSign"];
                        }
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("输入错误,请重新输入!");
                    }
                }
                else
                {
                    var empList = empBll.GetListBy(e => e.FID == currentValue || e.EID == currentValue || e.EmpName == currentValue);
                    if (empList != null && empList.Count > 0)
                    {
                        dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpName"].Value = empList[0].EmpName;
                        dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpSalary"].Value = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["AllMoney"].EditedFormattedValue;
                        //设置ID
                        dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpIds"].Value = empList[0].EID;

                        int currentNext = dgvData.CurrentCell.RowIndex + 1;
                        if (currentNext <= dgvData.Rows.Count-1)
                        {
                            dgvData.CurrentCell = dgvData.Rows[currentNext].Cells["EmpSign"];
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入错误,请重新输入!");
                    }
                }
            }
        }
        #endregion

        #region 获取并设置总金额
        /// <summary>
        /// 获取并设置总金额
        /// </summary>
        private void GetAllMoney()
        {
            if (dgvData.CurrentCell == dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"])
            {
                DataGridViewCell currentCell = dgvData.CurrentCell;
                string currentValue = currentCell.EditedFormattedValue.ToString();
                if (string.IsNullOrEmpty(currentValue))
                {
                    int currentNext = dgvData.CurrentCell.RowIndex + 1;
                    if (currentNext <= dgvData.Rows.Count - 1)
                    {
                        dgvData.CurrentCell = dgvData.Rows[currentNext].Cells["Count"];
                    }
                    else
                    {
                        dgvData.CurrentCell = dgvData.Rows[0].Cells["EmpSign"];
                    }
                    return;
                }

                if (currentValue.IsDouble() && Convert.ToDouble(currentValue) > 0)
                {
                    double value = Convert.ToDouble(currentValue);
                    double price = Convert.ToDouble(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Price"].EditedFormattedValue);
                    string tempAllMomey = Convert.ToDouble(value * price).ToString("0.00");
                    dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["AllMoney"].Value = Convert.ToDouble(tempAllMomey);
                    //dgvData.CurrentCell = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpSign"];

                    //如果先输入员工,然后再输入件数,那么执行.获取员工薪资
                    if (!string.IsNullOrEmpty(Convert.ToString(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpIds"].EditedFormattedValue)))
                    {
                        //GetEmpSign();
                    }


                    int currentNext = dgvData.CurrentCell.RowIndex + 1;
                    if (currentNext <= dgvData.Rows.Count-1)
                    {
                        dgvData.CurrentCell = dgvData.Rows[currentNext].Cells["Count"];
                    }
                    else
                    {
                        dgvData.CurrentCell = dgvData.Rows[0].Cells["EmpSign"];
                    }

                    //------如果当前项是转运,那么将其它所有转运的件数都设置为此值----------
                    //if (dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["GongXu"].EditedFormattedValue.Equals("转运"))
                    //{
                        
                    //}
                }
                else
                {
                    MessageBox.Show("请输入数字!");
                }

            }
        }
        #endregion

        #region 设置订单数据
        /// <summary>
        /// 设置订单数据
        /// </summary>
        private bool SetOrderData()
        {
            if (string.IsNullOrEmpty(txtOrder.Text))
            {
                MessageBox.Show("单号不能为空");
                return false;
            }
            else
            {
                int cbSelectValue = Convert.ToInt32(cbType.SelectedValue);
                var hasCardList = wPCardBll.GetListBy(w => w.OrderID == txtOrder.Text.Trim() && w.ListType == cbSelectValue);
                var hasEmpSalaryList = empSalaryBll.GetListBy(es => es.OrderID == txtOrder.Text.Trim() && es.ListType == cbSelectValue);
                if (hasCardList != null && hasCardList.Count > 0 || hasEmpSalaryList != null && hasEmpSalaryList.Count > 0)
                {
                    MessageBox.Show("数据库中已存在此订单的数据!");
                    Reset();
                    return false;
                }
                
            }

            OrderDataBll orderDataBll = new OrderDataBll();

            var data = orderDataBll.GetOrderData(txtOrder.Text, Convert.ToInt32(cbType.SelectedValue));
            if (data != null)
            {
                btnSave.Enabled = true;
                txtZPF.Text = data.TotalArea.ToString();
                txtBeiBan.Text = data.TotalBackArea.ToString();
                txtZMD.Text = data.Name;
                txtOrderDate.Text = data.OrderDate;

                txtZhuPF.Text = (data.TotalArea - data.TotalBackArea).ToString();
                return true;
            }
            else
            {
                MessageBox.Show("无法从远程数据源抓取此订单,请确认输入的单号是否正确!");
                return false;
            }
        }
        #endregion

        #region datagridview的键盘按下事件,如果是回车键则触发
        /// <summary>
        /// datagridview的键盘按下事件,如果是回车键则触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_KeyPress(object sender, KeyPressEventArgs e)
        {
            var currentColumn = dgvData.CurrentCell.OwningColumn;
            if (currentColumn.Name == "Count")
            {
                GetAllMoney();
            }
            if (currentColumn.Name == "EmpSign")
            {
                GetEmpSign();
            }
            
        } 
        #endregion

        #region 文本框的键盘事件
        /// <summary>
        /// 文本框的键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                
                SetOrderData();
            }
        } 
        #endregion

        #region 重置文本框内容
        /// <summary>
        /// 重置文本框内容
        /// </summary>
        private void Reset()
        {
            btnSave.Enabled = false;
            txtZPF.Clear();
            txtBeiBan.Clear();

            txtZMD.Clear();
            txtOrderDate.Clear();
            txtZhuPF.Clear();
        } 
        #endregion

        #region 根据订单ID查询数据
        /// <summary>
        /// 根据订单ID查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            FrmOrderQuery frmOrderQuery = new FrmOrderQuery();
            frmOrderQuery.ShowDialog();
        } 
        #endregion

        #region 格式化显示数据
        /// <summary>
        /// 格式化显示数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ("AllUnitCount".Equals(dgvData.Columns[e.ColumnIndex].Name))
            {
                if (e.Value == null)
                {
                    return;
                }

                if ("封边".Equals(dgvData.Rows[e.RowIndex].Cells["GongXu"].EditedFormattedValue.ToString()))
                {
                    e.Value = "";
                }
                if ("排钻".Equals(dgvData.Rows[e.RowIndex].Cells["GongXu"].EditedFormattedValue.ToString()))
                {
                    if (Convert.ToInt32(cbType.SelectedValue)==1)
                    {
                        e.Value = "";
                    }
                    
                }
                
            }

            //if ("Count".Equals(dgvData.Columns[e.ColumnIndex].Name))
            //{
            //    int flowType = Convert.ToInt32(cbType.SelectedValue);
            //    if (flowType == 1 && "拉槽".Equals(dgvData.Rows[e.RowIndex].Cells["GongXu"].EditedFormattedValue.ToString()))
            //    {
            //        e.Value = "不填写";
            //    }
            //}
        }
        #endregion

        #region 单元格离开事件
        /// <summary>
        /// 单元格离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentCell == dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpSign"])
            {
                if (string.IsNullOrEmpty(dgvData.CurrentCell.EditedFormattedValue.ToString()))
                {
                    dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpName"].Value = "";
                    dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpIds"].Value = "";
                }
            }

            if (dgvData.CurrentCell == dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"])
            {
                if (string.IsNullOrEmpty(dgvData.CurrentCell.EditedFormattedValue.ToString()))
                {
                    dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["AllMoney"].Value = 0;
                    dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["EmpSalary"].Value = "";
                }
                else
                {
                    double value = double.Parse(dgvData.CurrentCell.EditedFormattedValue.ToString());
                    double price = Convert.ToDouble(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Price"].EditedFormattedValue);
                    string tempAllMomey = Convert.ToDouble(value * price).ToString("0.00");
                    dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["AllMoney"].Value = Convert.ToDouble(tempAllMomey);
                    //int currentNext = dgvData.CurrentCell.RowIndex + 1;
                    //if (currentNext <= dgvData.Rows.Count)
                    //{
                    //    dgvData.CurrentCell = dgvData.Rows[currentNext].Cells["Count"];
                    //    return;
                    //}


                    //-----------设置第一个单位为平方的值之后所有单位为平方的值都为此值----------
                    #region 设置第一个单位为平方的值之后所有单位为平方的值都为此值
                    if (Convert.ToInt32(cbType.SelectedValue) == 1 && "平方".Equals(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Unit"].EditedFormattedValue.ToString()))
                    {
                        //MessageBox.Show(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"].EditedFormattedValue.ToString());
                        string pinFan = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"].EditedFormattedValue.ToString();
                        int currentRow = dgvData.CurrentCell.RowIndex;
                        if (currentRow < dgvData.Rows.Count - 1)
                        {
                            for (int i = currentRow + 1; i < dgvData.Rows.Count; i++)
                            {
                                if ("平方".Equals(dgvData.Rows[i].Cells["Unit"].EditedFormattedValue.ToString()))
                                {
                                    dgvData.Rows[i].Cells["Count"].Value = pinFan;
                                    double pinFanValue = double.Parse(dgvData.Rows[i].Cells["Count"].EditedFormattedValue.ToString());
                                    double pinFanPrice = Convert.ToDouble(dgvData.Rows[i].Cells["Price"].EditedFormattedValue);
                                    string pinFanAllMomey = Convert.ToDouble(pinFanValue * pinFanPrice).ToString("0.00");
                                    dgvData.Rows[i].Cells["AllMoney"].Value = Convert.ToDouble(pinFanAllMomey);
                                }
                            }
                        }
                    }
                    #endregion



                    //-----------工序为转运的件数一致----------
                    #region 工序为转运的件数一致
                    if (Convert.ToInt32(cbType.SelectedValue) == 1 && "转运".Equals(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["GongXu"].EditedFormattedValue.ToString()))
                    {
                        //MessageBox.Show(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"].EditedFormattedValue.ToString());
                        string zyCount = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"].EditedFormattedValue.ToString();
                        int zycurrentRow = dgvData.CurrentCell.RowIndex;
                        if (zycurrentRow < dgvData.Rows.Count - 1)
                        {
                            for (int i = zycurrentRow + 1; i < dgvData.Rows.Count; i++)
                            {
                                if ("转运".Equals(dgvData.Rows[i].Cells["GongXu"].EditedFormattedValue.ToString()))
                                {
                                    dgvData.Rows[i].Cells["Count"].Value = zyCount;
                                    double zyValue = double.Parse(dgvData.Rows[i].Cells["Count"].EditedFormattedValue.ToString());
                                    double zyPrice = Convert.ToDouble(dgvData.Rows[i].Cells["Price"].EditedFormattedValue);
                                    string zyAllMomey = Convert.ToDouble(zyValue * zyPrice).ToString("0.00");
                                    dgvData.Rows[i].Cells["AllMoney"].Value = Convert.ToDouble(zyAllMomey);
                                }
                            }
                        }
                    }
                    #endregion

                    //-----------功能件生产流程卡(功能件开料\直线封边\排钻\修色\包装)件数一致----------
                    #region 功能件生产流程卡(功能件开料\直线封边\排钻\修色\包装)件数一致
                    if (Convert.ToInt32(cbType.SelectedValue) == 2 && "功能件开料".Equals(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["GXContent"].EditedFormattedValue.ToString()))
                    {
                        //MessageBox.Show(dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"].EditedFormattedValue.ToString());
                        string klCount = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Count"].EditedFormattedValue.ToString();
                        int klcurrentRow = dgvData.CurrentCell.RowIndex;
                        if (klcurrentRow < dgvData.Rows.Count - 1)
                        {
                            for (int i = klcurrentRow + 1; i < dgvData.Rows.Count; i++)
                            {
                                if ("直线封边".Equals(dgvData.Rows[i].Cells["GXContent"].EditedFormattedValue.ToString())
                                     || "排钻".Equals(dgvData.Rows[i].Cells["GXContent"].EditedFormattedValue.ToString())
                                     || "修色".Equals(dgvData.Rows[i].Cells["GXContent"].EditedFormattedValue.ToString())
                                     || "包装".Equals(dgvData.Rows[i].Cells["GXContent"].EditedFormattedValue.ToString()))
                                {
                                    dgvData.Rows[i].Cells["Count"].Value = klCount;
                                    double klValue = double.Parse(dgvData.Rows[i].Cells["Count"].EditedFormattedValue.ToString());
                                    double klPrice = Convert.ToDouble(dgvData.Rows[i].Cells["Price"].EditedFormattedValue);
                                    string klAllMomey = Convert.ToDouble(klValue * klPrice).ToString("0.00");
                                    dgvData.Rows[i].Cells["AllMoney"].Value = Convert.ToDouble(klAllMomey);
                                }
                            }
                        }
                    }
                    #endregion

                }
            }

        } 
        #endregion

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            txtOrder.Text = "";
            FlushData(Convert.ToInt32(cbType.SelectedValue));
        }

    }
}
