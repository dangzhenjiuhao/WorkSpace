using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiegleSalary.Model
{
    public class WPCardDisplayModel
    {
        //public int ID { get; set; }
        public string DealerName { get; set; }
        public string OrderID { get; set; }
        public string OrderDate { get; set; }
        public string TotalArea { get; set; }
        public string MArea { get; set; }
        public string BArea { get; set; }
        public Nullable<System.DateTime> APDate { get; set; }
    }
}
