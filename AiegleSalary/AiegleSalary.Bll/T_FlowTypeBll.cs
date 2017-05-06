using AiegleSalary.Dal;
using AiegleSalary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Bll
{
    public class T_FlowTypeBll : BaseService<T_FlowType>
    {
        public T_FlowTypeBll()
        {
            dal = new T_FlowTypeDal();
        }
    }
}
