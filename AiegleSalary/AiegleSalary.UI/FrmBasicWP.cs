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
    public partial class FrmBasicWP : RibbonForm
    {
        public FrmBasicWP()
        {
            InitializeComponent();
        }
        T_FlowTypeBll flowTypeBll = new T_FlowTypeBll();
        T_BasicWPBll basicWPBll = new T_BasicWPBll();

        //----------------------------------------------------
        public bool IsAdd { get; set; }
        public T_BasicWP TransBasicWP { get; set; }
        public FlushDataDelegate FlushData { get; set; }
        //----------------------------------------------------

        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBasicWP_Load(object sender, EventArgs e)
        {
            var typeList = flowTypeBll.GetListBy(f => 1 == 1);
            cbFlowType.DisplayMember = "FlowName";
            cbFlowType.ValueMember = "FlowID";
            cbFlowType.DataSource = typeList;

            if (!IsAdd)
            {
                if (TransBasicWP!=null)
                {
                    txtWPCode.Enabled = false;
                    txtWPCode.Text = this.TransBasicWP.WPCode;
                    txtGongXu.Text = this.TransBasicWP.GongXu;
                    txtGXContent.Text = this.TransBasicWP.GXContent;
                    txtUnit.Text = this.TransBasicWP.Unit;
                    txtPrice.Text = Convert.ToString(this.TransBasicWP.Price);
                    txtRemark.Text = this.TransBasicWP.ReMark;
                    cbFlowType.SelectedValue = this.TransBasicWP.FlowID;
                    txtSort.Text = Convert.ToString(this.TransBasicWP.Sort);
                    txtCountDefaultValue.Text = Convert.ToString(this.TransBasicWP.CountDefaultValue); 
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
                    string price = txtPrice.Text.Trim();
                    string sort = txtSort.Text.Trim();
                    string countDefaultValue = txtCountDefaultValue.Text.Trim();

                    if (string.IsNullOrEmpty(price) || !price.IsDouble())
                    {
                        MessageBox.Show("单价不能为空且必需为数字!");
                        return;
                    }
                    if (string.IsNullOrEmpty(sort) || !sort.IsNumeric2())
                    {
                        MessageBox.Show("排序号不能为空且必需为整数!");
                        return;
                    }
                    if (!countDefaultValue.IsNumeric2())
                    {
                        MessageBox.Show("初始值可以为空,但如果不为空,那么必需为整数!");
                        return;
                    }

                    var wpCodeList = basicWPBll.GetListBy(wp => wp.WPCode == txtWPCode.Text.Trim());
                    if (wpCodeList != null && wpCodeList.Count > 0)
                    {
                        MessageBox.Show("数据库中已存在此编码:" + txtWPCode.Text.Trim());
                        return;
                    }


                    T_BasicWP model = new T_BasicWP
                    {
                        WPCode = txtWPCode.Text.Trim(),
                        ReMark = txtRemark.Text.Trim(),
                        GongXu = txtGongXu.Text.Trim(),
                        GXContent = txtGXContent.Text.Trim(),
                        Unit = txtUnit.Text.Trim(),
                        Price = Convert.ToDouble(txtPrice.Text.Trim()),
                        FlowID = Convert.ToInt32(cbFlowType.SelectedValue),
                        Sort = Convert.ToInt32(txtSort.Text.Trim()),
                        CountDefaultValue = string.IsNullOrEmpty(countDefaultValue) ? 0 : Convert.ToInt32(countDefaultValue)
                    };

                    result = basicWPBll.Add(model);

                }
                else
                {
                    TransBasicWP = basicWPBll.GetModel(wp => wp.ID == TransBasicWP.ID);
                    //this.TransBasicWP.WPCode = txtWPCode.Text.Trim();
                    this.TransBasicWP.ReMark = txtRemark.Text.Trim();
                    this.TransBasicWP.GongXu = txtGongXu.Text.Trim();
                    this.TransBasicWP.GXContent = txtGXContent.Text.Trim();
                    this.TransBasicWP.Unit = txtUnit.Text.Trim();
                    this.TransBasicWP.Price = Convert.ToDouble(txtPrice.Text.Trim());
                    this.TransBasicWP.FlowID = Convert.ToInt32(cbFlowType.SelectedValue);
                    this.TransBasicWP.Sort = Convert.ToInt32(txtSort.Text.Trim());
                    this.TransBasicWP.CountDefaultValue = string.IsNullOrEmpty(txtCountDefaultValue.Text.Trim()) ? 0 : Convert.ToInt32(txtCountDefaultValue.Text.Trim());
                    result = basicWPBll.ModifyBy(TransBasicWP,wp=>wp.WPCode==TransBasicWP.WPCode, new String[] { "GongXu", "GXContent", "Unit", "Price", "ReMark", "FlowID", "Sort", "CountDefaultValue" });
                    //result = basicWPBll.Modify(TransBasicWP);
                    
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
