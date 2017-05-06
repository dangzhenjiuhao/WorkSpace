using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Model
{
    public class DisplayModel
    {
        /// <summary>
        /// 工序
        /// </summary>
        public string GongXu { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string GXContent { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string WPCode { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 总件数
        /// </summary>
        public string AllUnitCount { get; set; }
        /// <summary>
        /// 件数/面积
        /// </summary>
        public string Count { get; set; }

        
        /// <summary>
        /// 操作人员签名
        /// </summary>
        public string EmpSign { get; set; }
        /// <summary>
        /// 操作人员姓名
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public double AllMoney { get; set; }
        /// <summary>
        /// 工人薪资
        /// </summary>
        public string EmpSalary { get; set; }



        //-----------------------------------
        public Nullable<double> Price { get; set; }
        //public Nullable<double> CheckRate { get; set; }

        public string EmpIds { get; set; }
        
    }
}
