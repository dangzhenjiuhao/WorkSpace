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
    public partial class FrmUpdateSalary : RibbonForm
    {
        public FrmUpdateSalary()
        {
            InitializeComponent();
        }

        

        T_BasicWPBll basicWPBll = new T_BasicWPBll();
        T_FlowTypeBll flowTypeBll = new T_FlowTypeBll();
        T_EmpBll empBll = new T_EmpBll();
        T_EmpSalaryBll empSalaryBll = new T_EmpSalaryBll();
        T_WPCardBll wPCardBll = new T_WPCardBll();

        private void FrmUpdateSalary_Load(object sender, EventArgs e)
        {
            var typeList = flowTypeBll.GetListBy(f => 1 == 1);
            cbType.DisplayMember = "FlowName";
            cbType.ValueMember = "FlowID";
            cbType.DataSource = typeList;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string wpCode = txtWPCode.Text.Trim();
            int flowId = (int)cbType.SelectedValue;
            DateTime startTime = Convert.ToDateTime(dtpStartTime.Value.ToString("yyyy-MM-dd"));
            DateTime endTime = Convert.ToDateTime(dtpEndTime.Value.ToString("yyyy-MM-dd"));

            var wpCardList = wPCardBll.GetListBy(wp => wp.wpCode == wpCode && wp.ListType == flowId && wp.APDate >= startTime && wp.APDate <= endTime).OrderBy(wp=>wp.APDate).ToList();
            dgvWPCard.DataSource = wpCardList;

            List<T_EmpSalary> empList = new List<T_EmpSalary>();

            foreach (var item in wpCardList)
            {
                var subEmpList = empSalaryBll.GetListBy(emp => emp.OrderID == item.OrderID && emp.WPCode == item.wpCode && emp.ListType == item.ListType).ToList();
                empList.AddRange(subEmpList);
            }
            dgvEmpSalary.DataSource = empList;
            MessageBox.Show(empList.Count + "");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            string wpCode = txtWPCode.Text.Trim();

            if (string.IsNullOrEmpty(wpCode))
	        {
                MessageBox.Show("请输入要修改的工序代码/及流程ID/开始日期/结束日期");
		        return;
	        }


            int flowId = (int)cbType.SelectedValue;
            DateTime startTime = Convert.ToDateTime(dtpStartTime.Value.ToString("yyyy-MM-dd"));
            DateTime endTime = Convert.ToDateTime(dtpEndTime.Value.ToString("yyyy-MM-dd"));

            var wpCardList = wPCardBll.GetListBy(wp => wp.wpCode == wpCode && wp.ListType == flowId && wp.APDate >= startTime && wp.APDate <= endTime).OrderBy(wp => wp.APDate).ToList();
            //dgvWPCard.DataSource = wpCardList;


            T_BasicWP model = basicWPBll.GetModel(b => b.WPCode == wpCode);
            //MessageBox.Show(wpCardList.Count + "");

            foreach (var item in wpCardList)
            {
                double? salary = item.Qty * model.Price;
                string a4 = string.Empty;
                double? rateCount = 0;
                double? perSalary = 0;
                Dictionary<string, double?> dic = new Dictionary<string, double?>();

                if (item.A5.Contains("."))
                {
                    

                    string[] ids = item.A5.Split('.');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        string empid = ids[i];
                        T_Emp po = empBll.GetModel(emp => emp.EID == empid);
                        rateCount += po.CheckRate;
                    }
                    //将总金额分成多少份
                    perSalary = salary / rateCount;

                    //计算每个人的薪资
                    for (int i = 0; i < ids.Length; i++)
                    {
                        string empid = ids[i];
                        T_Emp po = empBll.GetModel(emp => emp.EID == empid);
                        a4 += perSalary * po.CheckRate + "/";
                    }
                    a4 = a4.Substring(0, a4.Length - 1);

                }
                else
                {
                    //T_Emp po = empBll.GetModel(emp => emp.EID == item.A5);
                    //rateCount = po.CheckRate;
                    //perSalary = salary / rateCount;
                    a4 = salary.ToString();
                }
                item.Salary = Convert.ToDouble(Convert.ToDouble(salary).ToString("#0.000"));
                item.A3 = salary.ToString();
                item.A4 = a4;

                int result = wPCardBll.Modify(item);

                if (result > 0)
                {
                    List<T_EmpSalary> empSalaryModelList = empSalaryBll.GetListBy(empSalary => empSalary.OrderID == item.OrderID && empSalary.WPCode == item.wpCode && empSalary.ListType == item.ListType);

                    if (empSalaryModelList!=null && empSalaryModelList.Count==1)
                    {
                        empSalaryModelList[0].Salary = Convert.ToDouble(Convert.ToDouble(salary).ToString("#0.000"));
                        empSalaryBll.Modify(empSalaryModelList[0]);
                    }
                    else
                    {
                        foreach (var empSalaryModel in empSalaryModelList)
                        {
                            T_Emp tempModel = empBll.GetModel(emp => emp.EID == empSalaryModel.EID);
                            empSalaryModel.Salary = Convert.ToDouble(Convert.ToDouble(perSalary * tempModel.CheckRate).ToString("#0.000"));
                            empSalaryBll.Modify(empSalaryModel);
                        }
                    }

                    
                }
            }

            MessageBox.Show("Test");
        }
    }
}
