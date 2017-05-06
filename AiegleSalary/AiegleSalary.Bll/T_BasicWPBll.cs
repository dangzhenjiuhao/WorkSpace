using AiegleSalary.Dal;
using AiegleSalary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Bll
{
    public class T_BasicWPBll : BaseService<T_BasicWP>
    {
        public T_BasicWPBll()
        {
            dal = new T_BasicWPDal();
        }
    }
}
