using AiegleSalary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Dal
{
    public class EFDbContextHelper
    {
        public static DbContext Context;

        static EFDbContextHelper()
        {

            if (Context == null)
            {
                Context = new AiegleSalaryEntities();
            }
        }

        //public static DbContext GetContext()
        //{
        //    DbContext context = CallContext.GetData("WFEntites") as DbContext;
        //    if (context == null)
        //    {
        //        context = new WFEntities();
        //        CallContext.SetData("WFEntites",context);
        //    }
        //    return context;
        //}
    }
}
