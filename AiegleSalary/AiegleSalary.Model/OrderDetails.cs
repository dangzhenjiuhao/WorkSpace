using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiegleSalary.Model
{
    public class OrderDetails
    {
        public DateTime ApDate { get; set; }

        public string OrderID { get; set; }

        public string GXName { get; set; }
        public string GXWpCode { get; set; }
        public double? Qty { get; set; }

        public double? Price { get; set; }
        public string AllCount { get; set; }
        public string EmpName { get; set; }
        public string EmpSalary { get; set; }
    }
}
