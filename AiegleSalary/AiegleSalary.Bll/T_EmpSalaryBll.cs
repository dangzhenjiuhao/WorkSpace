using AiegleSalary.Dal;
using AiegleSalary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Bll
{
    public class T_EmpSalaryBll : BaseService<T_EmpSalary>
    {
        public T_EmpSalaryBll()
        {
            dal = new T_EmpSalaryDal();
        }
    }
}
