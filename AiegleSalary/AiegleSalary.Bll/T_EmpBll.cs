using AiegleSalary.Dal;
using AiegleSalary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Bll
{
    public class T_EmpBll : BaseService<T_Emp>
    {
        public T_EmpBll()
        {
            dal = new T_EmpDal();
        }
        
    }
}
