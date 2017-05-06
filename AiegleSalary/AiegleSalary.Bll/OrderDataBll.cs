using AiegleSalary.Dal;
using AiegleSalary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiegleSalary.Bll
{
    public class OrderDataBll
    {
        OrderDataDal dal = new OrderDataDal();

        #region 获取订单数据
        /// <summary>
        /// 获取订单数据
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="listIndex"></param>
        /// <returns></returns>
        public OrderData GetOrderData(string orderNo, int listIndex)
        {
            return dal.GetOrderData(orderNo, listIndex);
        }
        #endregion

        #region 删除订单数据
        /// <summary>
        /// 删除订单数据
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="flowType"></param>
        /// <returns></returns>
        public bool DeleteOrderData(string orderID,int flowType)
        {
            return dal.DeleteOrderData(orderID, flowType);
        }
        #endregion

        public DataSet GetEmpSalaryListByCondition(string startTime, string endTime,string eID)
        {
            return dal.GetEmpSalaryListByCondition(startTime, endTime, eID);
        }

        public DataSet GetOrderDetailsListByCondition(string startTime, string endTime, int flowType)
        {
            return dal.GetOrderDetailsListByCondition(startTime, endTime,flowType);
        }

        public DataSet GetEmpSalaryDetailByCondition(string startTime, string endTime, string eID)
        {
            return dal.GetEmpSalaryDetailByCondition(startTime, endTime, eID);
        }
    }
}
