using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTab;
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
    public partial class FrmMain : RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 流程类型设置
        /// <summary>
        /// 流程类型设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtnFlowSet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string currentClickName = ((BarButtonItem)e.Item).Caption;
            if (this.tabControlMain.TabPages.Count > 0)
            {
                foreach (XtraTabPage page in this.tabControlMain.TabPages)
                {
                    if (page.Text.Equals(currentClickName))
                    {
                        this.tabControlMain.SelectedTabPage = page;
                        return;
                    }
                }
            }

            #region 手工创建控件
            XtraTabPage xPage = new XtraTabPage();
            xPage.Name = "xPageFlowType";
            xPage.Text = "流程类型设置";
            xPage.ShowCloseButton = DefaultBoolean.True;
            UCFlowType ucFlowType = new UCFlowType();
            ucFlowType.Dock = DockStyle.Fill;
            xPage.Controls.Add(ucFlowType);
            //xPage.Controls.Add(leftGroupControl);

            tabControlMain.TabPages.Add(xPage);
            tabControlMain.SelectedTabPage = xPage;//显示该页 
            #endregion
        } 
        #endregion

        #region 员工信息设置
        /// <summary>
        /// 员工信息设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtnEmpSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            string currentClickName = ((BarButtonItem)e.Item).Caption;
            if (this.tabControlMain.TabPages.Count > 0)
            {
                foreach (XtraTabPage page in this.tabControlMain.TabPages)
                {
                    if (page.Text.Equals(currentClickName))
                    {
                        this.tabControlMain.SelectedTabPage = page;
                        return;
                    }
                }
            }

            #region 手工创建控件
            XtraTabPage xPage = new XtraTabPage();
            xPage.Name = "xPageEmp";
            xPage.Text = "员工设置";
            xPage.ShowCloseButton = DefaultBoolean.True;

            UCEmp ucEmp = new UCEmp();
            ucEmp.Dock = DockStyle.Fill;
            xPage.Controls.Add(ucEmp);
            //xPage.Controls.Add(leftGroupControl);
            tabControlMain.TabPages.Add(xPage);
            tabControlMain.SelectedTabPage = xPage;//显示该页 
            #endregion
        } 
        #endregion

        #region 基础信息设置
        /// <summary>
        /// 基础信息设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtnBasic_ItemClick(object sender, ItemClickEventArgs e)
        {
            string currentClickName = ((BarButtonItem)e.Item).Caption;
            if (this.tabControlMain.TabPages.Count > 0)
            {
                foreach (XtraTabPage page in this.tabControlMain.TabPages)
                {
                    if (page.Text.Equals(currentClickName))
                    {
                        this.tabControlMain.SelectedTabPage = page;
                        return;
                    }
                }
            }

            #region 手工创建控件
            XtraTabPage xPage = new XtraTabPage();
            xPage.Name = "xPageBasic";
            xPage.Text = "基础信息设置";
            xPage.ShowCloseButton = DefaultBoolean.True;
            UCBasic ucBasic = new UCBasic();
            ucBasic.Dock = DockStyle.Fill;
            xPage.Controls.Add(ucBasic);
            //xPage.Controls.Add(leftGroupControl);
            tabControlMain.TabPages.Add(xPage);
            tabControlMain.SelectedTabPage = xPage;//显示该页 
            #endregion
        } 
        #endregion

        #region 窗体Load事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; 

            //xtabcontrol的关闭图标显示
            this.tabControlMain.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next)
           | DevExpress.XtraTab.TabButtons.Close)
           | DevExpress.XtraTab.TabButtons.Default)));
            //this.tabControlMain.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.tabControlMain.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders;//显示关闭按钮

            if (this.tabControlMain.TabPages.Count > 0)
            {
                this.tabControlMain.TabPages[0].ShowCloseButton = DefaultBoolean.False;//首页不显示关闭按钮
            }
        }
        #endregion

        #region tabpage的关闭事件
        /// <summary>
        /// tabpage的关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlMain_CloseButtonClick(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text
            foreach (XtraTabPage page in tabControlMain.TabPages)//遍历得到和关闭的选项卡一样的Text
            {
                if (page.Text == name)
                {
                    tabControlMain.TabPages.Remove(page);
                    page.Dispose();
                    return;
                }
            }
        }
        #endregion

        #region 窗体关闭事件
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();//只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，另外若有托管线程（非主线程），也无法干净地退出；

            Application.Exit();//强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出；

            //Application.ExitThread();//强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题；

            //System.Environment.Exit(0);//这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。

        }
        #endregion

        #region 生产流程卡
        /// <summary>
        /// 生产流程卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtnProduce_ItemClick(object sender, ItemClickEventArgs e)
        {
            string currentClickName = ((BarButtonItem)e.Item).Caption;
            if (this.tabControlMain.TabPages.Count > 0)
            {
                foreach (XtraTabPage page in this.tabControlMain.TabPages)
                {
                    if (page.Text.Equals(currentClickName))
                    {
                        this.tabControlMain.SelectedTabPage = page;
                        return;
                    }
                }
            }

            #region 手工创建控件
            XtraTabPage xPage = new XtraTabPage();
            xPage.Name = "xPageProduce";
            xPage.Text = "生产流程卡";
            xPage.ShowCloseButton = DefaultBoolean.True;

            UCProduce ucProduce = new UCProduce();
            ucProduce.Dock = DockStyle.Fill;
            xPage.Controls.Add(ucProduce);
            //xPage.Controls.Add(leftGroupControl);
            tabControlMain.TabPages.Add(xPage);
            tabControlMain.SelectedTabPage = xPage;//显示该页 
            #endregion
        } 
        #endregion

        #region 系统报表
        /// <summary>
        /// 系统报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtnReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBaoBiao frmBaoBiao = new FrmBaoBiao();
            frmBaoBiao.ShowDialog();
        } 
        #endregion

       
    }
}
