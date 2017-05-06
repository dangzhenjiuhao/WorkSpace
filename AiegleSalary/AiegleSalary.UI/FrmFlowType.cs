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
    public delegate void FlushDataDelegate();
    public partial class FrmFlowType : RibbonForm
    {
        public FrmFlowType()
        {
            InitializeComponent();
        }
        T_FlowTypeBll flowTypeBll = new T_FlowTypeBll();

        public bool IsAdd { get; set; }
        public T_FlowType TransFlowType { get; set; }
        public FlushDataDelegate FlushData { get; set; }
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
                    T_FlowType model = new T_FlowType
                    {
                        FlowName = txtName.Text.Trim(),
                        Remark = txtRemark.Text.Trim()
                    };

                    result = flowTypeBll.Add(model);

                }
                else
                {

                    this.TransFlowType.FlowName = txtName.Text;
                    this.TransFlowType.Remark = txtRemark.Text;


                    result = flowTypeBll.ModifyBy(TransFlowType, f => f.FlowID == TransFlowType.FlowID, new string[] { "FlowName", "Remark" });

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

        private void FrmFlowType_Load(object sender, EventArgs e)
        {
            if (!IsAdd)
            {
                if (this.TransFlowType != null)
                {
                    txtName.Text = this.TransFlowType.FlowName;
                    txtRemark.Text = this.TransFlowType.Remark;
                }
            }
        }
    }
}
