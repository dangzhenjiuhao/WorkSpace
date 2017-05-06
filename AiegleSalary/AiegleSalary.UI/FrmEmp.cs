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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiegleSalary.UI
{
    public partial class FrmEmp : RibbonForm
    {
        public FrmEmp()
        {
            InitializeComponent();
        }

        T_EmpBll empBll = new T_EmpBll();

        //----------------------------------------------------
        public bool IsAdd { get; set; }
        public T_Emp TransEmp { get; set; }
        public FlushDataDelegate FlushData { get; set; }
        //----------------------------------------------------

        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEmp_Load(object sender, EventArgs e)
        {
            if (!IsAdd)
            {
                if (TransEmp!=null)
                {
                    txtEID.Enabled = false;
                    txtEID.Text = this.TransEmp.EID;
                    txtFID.Text = this.TransEmp.FID;
                    txtEmpName.Text = this.TransEmp.EmpName;
                    txtDept.Text = this.TransEmp.Dept;
                    txtPOS.Text = this.TransEmp.POS;
                    txtCheckRate.Text = Convert.ToString(this.TransEmp.CheckRate); 
                }
                
            }
        }
        #endregion

        private void btnN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                if (IsAdd)
                {
                    string checkRate = txtCheckRate.Text.Trim();
                    if (string.IsNullOrEmpty(checkRate) || !checkRate.IsDouble())
                    {
                        MessageBox.Show("比率不能为空且必需为数字!");
                        return;
                    }

                    var wpEIDList = empBll.GetListBy(emp => emp.EID == txtEID.Text.Trim());
                    if (wpEIDList != null && wpEIDList.Count > 0)
                    {
                        MessageBox.Show("数据库中已存在此编码:" + txtEID.Text.Trim());
                        return;
                    }

                    T_Emp model = new T_Emp
                    {
                        EID = txtEID.Text.Trim(),
                        FID = txtFID.Text.Trim(),
                        EmpName = txtEmpName.Text.Trim(),
                        Dept = txtDept.Text.Trim(),
                        POS = txtPOS.Text.Trim(),
                        CheckRate = Convert.ToDouble(txtCheckRate.Text.Trim())
                    };

                    result = empBll.Add(model);

                }
                else
                {
                    //this.TransBasicWP.WPCode = txtWPCode.Text.Trim();
                    this.TransEmp = empBll.GetModel(m => m.EID == this.TransEmp.EID);
                    this.TransEmp.FID = txtFID.Text.Trim();
                    this.TransEmp.EmpName = txtEmpName.Text.Trim();
                    this.TransEmp.Dept = txtDept.Text.Trim();
                    this.TransEmp.POS = txtPOS.Text.Trim();
                    this.TransEmp.CheckRate = Convert.ToDouble(txtCheckRate.Text.Trim());

                    result = empBll.ModifyBy(TransEmp, emp => emp.EID == TransEmp.EID, new string[]{
                    "FID","EmpName","Dept","POS","CheckRate"
                });

                }
                if (result > 0)
                {
                    MessageBox.Show("Yes");
                    FlushData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错了!出错信息:" + ex.Message);                
            }
        }
    }
}
