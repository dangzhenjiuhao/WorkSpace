using AiegleSalary.Dal;
using AiegleSalary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Bll
{
    public class T_WPCardBll : BaseService<T_WPCard>
    {
        public T_WPCardBll()
        {
            dal = new T_WPCardDal();
        }
    }
}
